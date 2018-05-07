using System.Linq;
using Code.Map;
using UnityEngine;

namespace Code.Tactical
{
    public class TacticalCommanderView : MonoBehaviour
    {
        public TacticalController SelectedActor;
        public Camera View;
        public float PanSpeed;
        public LayerMask FloorLayer;
        public LayerMask ActorLayer;
        public MapGen map;

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                CommandMove();
            }

            MoveCamera();
        }

        void MoveCamera()
        {
            var moveVector = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
            View.transform.position = View.transform.position + (moveVector * PanSpeed);
        }

        public void CommandMove()
        {
            var ray = View.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 200f, FloorLayer))
            {
                var cell = hit.collider.GetComponentInParent<Cell>();
                var path = Pathfinder.FindBestPath(SelectedActor.GetCurrentNavNode, cell.NavNode,
                    map.NavigationMap.Graph);

                SelectedActor.SetPath(path.Select(n => map.FindCell(n.Coord).transform).ToList());
            }
        }
    }
}
