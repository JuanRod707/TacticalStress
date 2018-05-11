using System.Collections.Generic;
using System.Linq;
using Code.Directors;
using Code.Helpers;
using Code.Map;
using Code.Pathfinding;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Code.Tactical
{
    public class TacticalCommanderView : MonoBehaviour
    {
        public Camera View;
        public LayerMask FloorLayer;
        public LayerMask ActorLayer;
        public MapGen map;
        public GameObject Selector;
        public ModeSwitcher ModeSwitcher;
        public LineRenderer MovementLine;

        TacticalController selectedActor;

        private IEnumerable<Transform> calculatedPath;

        void Update()
        {
            calculatedPath = CalculatePath();
            DrawMovementLine();

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
                selectedActor.ChangeControlMode();

                if (selectedActor.enabled)
                {
                    ModeSwitcher.SwitchToTacticalMode();
                }
                else
                {
                    ModeSwitcher.SwitchToActionMode(selectedActor.ManualControl);
                }
            }   
        }

        void CommandSelect()
        {
            if (selectedActor != null && selectedActor.enabled)
            {
                return;
            }

            var hit = MouseOverSpace(ActorLayer);
            if (hit.DidHit)
            {
                selectedActor = hit.HitInfo.collider.GetComponent<TacticalController>();
                Selector.SetActive(true);
                Selector.transform.SetParent(selectedActor.MoveBody);
                Selector.transform.localPosition = Vector3.zero;
            }
        }

        void CommandMove()
        {
            if (selectedActor == null || !selectedActor.enabled)
            {
                return;
            }

            if (calculatedPath == null)
                return;

            selectedActor.SetPath(calculatedPath);
        }

        IEnumerable<Transform> CalculatePath()
        {
            if (selectedActor == null)
                return null;

            var hit = MouseOverSpace(FloorLayer);
            if (hit.DidHit)
            {
                var cell = hit.HitInfo.collider.GetComponentInParent<Cell>();
                if (cell.NavNode == selectedActor.GetCurrentNavNode)
                {
                    return null;
                }

                var path = Pathfinder.FindBestPath(selectedActor.GetCurrentNavNode, cell.NavNode,
                    map.NavigationMap.Graph);

                return path.Select(n => map.FindCell(n.Coord).transform).ToList();
            }

            return null;
        }

        void Deselect()
        {
            if (selectedActor == null || !selectedActor.enabled)
            {
                return;
            }

            selectedActor = null;
            Selector.SetActive(false);

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

        void DrawMovementLine()
        {
            if (calculatedPath == null)
                return;
            MovementLine.positionCount = calculatedPath.Count();

            for (int i=0;i < calculatedPath.Count(); i++)
            {
                MovementLine.SetPosition(i, calculatedPath.ToArray()[i].position);
            }
        }
    }
}
