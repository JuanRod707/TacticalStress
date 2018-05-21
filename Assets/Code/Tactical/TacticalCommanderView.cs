using System.Collections.Generic;
using System.Linq;
using Code.Actors;
using Code.Directors;
using Code.Helpers;
using Code.Infrastructure.Map;
using Code.Infrastructure.Pathfinding;
using Code.Tactical.VisualElements;
using UnityEngine;

namespace Code.Tactical
{
    public class TacticalCommanderView : MonoBehaviour
    {
        public Camera View;
        public LayerMask FloorLayer;
        public LayerMask ActorLayer;
        public MapGen map;
        public GameObject Selector;
        public GameObject MovementTargetMarker;
        public ModeSwitcher ModeSwitcher;
        public ActorStats[] Squad;

        public MovementLine MovementLine;
        public MovementMarker MovementMarker;

        public MovementLine DestinationLine;
        public MovementMarker DestinationMarker;

        TacticalController selectedActor;

        private IEnumerable<Transform> calculatedPath;
        private Cell targettedCell;

        private bool SelectedActorReady
        {
            get { return selectedActor != null && selectedActor.ReadyToMove; }
        }

        void Update()
        {
            CheckCellUnderMouse();

            if (SelectedActorReady && calculatedPath != null)
            {
                MovementLine.Show(calculatedPath);
                MovementMarker.Show(calculatedPath);
            }

            if (Input.GetMouseButtonDown(0))
            {
                CommandMove();
                CommandSelect();
            }

            if (Input.GetMouseButtonDown(1))
            {
                Deselect();
            }


            if (Input.GetKeyDown(KeyCode.Space) && selectedActor != null)
            {
                SwitchMode();
            }   
        }

        void CommandSelect()
        {
            if (selectedActor != null)
            {
                return;
            }

            var hit = MouseOverSpace(ActorLayer);
            if (hit.DidHit)
            {
                selectedActor = hit.HitInfo.collider.GetComponent<TacticalController>();
                selectedActor.Select(DestinationLine, DestinationMarker);
                Selector.SetActive(true);
                Selector.transform.SetParent(selectedActor.MoveBody);
                Selector.transform.localPosition = Vector3.zero;
            }
        }

        void CommandMove()
        {
            if (SelectedActorReady)
            {
                if (calculatedPath == null)
                    return;

                selectedActor.SetPath(calculatedPath);
                HideVisualElements();
            }
        }

        IEnumerable<Transform> CalculatePath()
        {
            if (SelectedActorReady && targettedCell != null)
            {
                var path = Pathfinder.FindBestPath(selectedActor.GetCurrentNavNode, targettedCell.NavNode,
                    map.NavigationMap.Graph);

                if (path == null)
                {
                    return null;
                }

                return path.Select(n => map.FindCell(n.Coord).transform).ToList();
            }

            return null;
        }

        void Deselect()
        {
            if (SelectedActorReady)
            {
                selectedActor = null;
                Selector.SetActive(false);
                HideVisualElements();
            }
        }

        void HideVisualElements()
        {
            MovementMarker.Hide();
            MovementLine.Hide();
        }

        void CheckCellUnderMouse()
        {
            var hit = MouseOverSpace(FloorLayer);
            if (hit.DidHit)
            {
                var newCell = hit.HitInfo.collider.GetComponentInParent<Cell>();
                if (targettedCell != newCell)
                {
                    targettedCell = newCell;
                    calculatedPath = CalculatePath();
                }
            }
        }

        PhysicalHit MouseOverSpace(LayerMask lookForItems)
        {
            var ray = View.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 200f, lookForItems))
            {
                return new PhysicalHit(true, hit);
            }

            return new PhysicalHit(false, hit);
        }

        void SwitchMode()
        {
            if (selectedActor == null)
                return;

            if (SelectedActorReady)
            {
                ModeSwitcher.SwitchToActionMode(selectedActor.ManualControl);
                HideVisualElements();
                selectedActor.ChangeControlMode();
            }
            else if(!selectedActor.enabled)
            {
                ModeSwitcher.SwitchToTacticalMode();
                selectedActor.ChangeControlMode();
            }
        }

        public void EndTurn()
        {
            foreach (var actor in Squad)
            {
                actor.ResetTimeUnits();
            }
        }
    }
}
