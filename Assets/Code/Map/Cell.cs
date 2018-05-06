using UnityEngine;

namespace Code.Map
{
    public class Cell : MonoBehaviour
    {
        public Vector3 DebugLinesOffset;
        public bool ShowNavMesh;

        private NavNode navNode;
        private MapGen map;

        public Coordinate Coordinate { get; private set; }
        
        void Update()
        {
            if (ShowNavMesh)
            {
                DrawLines();
            }
        }

        public void Initialize(MapGen map, NavNode node)
        {
            this.map = map;
            navNode = node;
            Coordinate = new Coordinate(node.Coord.XCoord, node.Coord.YCoord);
        }

        void DrawLines()
        {
            foreach (var n in navNode.Neighbours)
            {
                var targetCell = map.FindCell(n.Coord);
                Debug.DrawLine(transform.position + DebugLinesOffset, targetCell.transform.position + DebugLinesOffset);
            }
        }
    }
}
