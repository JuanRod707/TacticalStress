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
        public float PanSpeed;
        public LayerMask FloorLayer;
        public LayerMask ActorLayer;
        public MapGen map;
        public GameObject Selector;
        public ModeSwitcher ModeSwitcher;

        TacticalController selectedActor;

        void Update()
        {
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

            var hit = ClickSpace(ActorLayer);
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

            var hit = ClickSpace(FloorLayer);
            if (hit.DidHit)
            {
                var cell = hit.HitInfo.collider.GetComponentInParent<Cell>();
                var path = Pathfinder.FindBestPath(selectedActor.GetCurrentNavNode, cell.NavNode,
                    map.NavigationMap.Graph);

                selectedActor.SetPath(path.Select(n => map.FindCell(n.Coord).transform).ToList());
            }
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

        PhysicalHit ClickSpace(LayerMask lookForItems)
        {
            var ray = View.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 200f, lookForItems))
            {
                return new PhysicalHit(true, hit);
            }

            return new PhysicalHit(false, hit);
        }
    }
}
