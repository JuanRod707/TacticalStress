using Code.Infrastructure.Pathfinding;
using UnityEngine;

namespace Code.Infrastructure.Map
{
    public class Cell : MonoBehaviour
    {
        public Vector3 DebugLinesOffset;
        public bool ShowNavMesh;

        private MapGen map;

        public NavNode NavNode { get; private set; }
        public CellData CellData { get; private set; }
        public Coordinate Coordinate { get; private set; }
        
        void Update()
        {
            if (ShowNavMesh)
            {
                DrawLines();
            }
        }

        public void Initialize(MapGen map, NavNode node, CellData data)
        {
            this.map = map;
            NavNode = node;
            CellData = data;
            Coordinate = new Coordinate(node.Coord.XCoord, node.Coord.YCoord);
        }

        void DrawLines()
        {
            foreach (var n in NavNode.Neighbours)
            {
                var targetCell = map.FindCell(n.Coord);
                Debug.DrawLine(transform.position + DebugLinesOffset, targetCell.transform.position + DebugLinesOffset);
            }
        }
    }
}
