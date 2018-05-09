using System.Linq;
using Code.Helpers;
using Code.Map;
using UnityEngine;

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

        TacticalController selectedActor;

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                CommandMove();
                CommandSelect();
            }

            if (Input.GetKeyDown(KeyCode.Space) && selectedActor != null)
            {
                selectedActor.ChangeControlMode();
            }

            MoveCamera();
        }

        void MoveCamera()
        {
            var moveVector = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
            View.transform.position = View.transform.position + (moveVector * PanSpeed);
        }

        public void CommandSelect()
        {
            var hit = ClickSpace(ActorLayer);
            if (hit.DidHit)
            {
                selectedActor = hit.HitInfo.collider.GetComponent<TacticalController>();
                Selector.SetActive(true);
                Selector.transform.SetParent(selectedActor.MoveBody);
                Selector.transform.localPosition = Vector3.zero;
            }
        }

        public void CommandMove()
        {
            if (selectedActor == null)
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
