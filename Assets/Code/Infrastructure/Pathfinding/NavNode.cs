using System.Collections.Generic;
using System.Linq;
using Code.Infrastructure.Map;

namespace Code.Infrastructure.Pathfinding
{
    public class NavNode
    {
        public List<NavNode> Neighbours;

        public Coordinate Coord { get; set; }

        public NavNode(int x, int y)
        {
            Coord = new Coordinate(x, y);
            Neighbours = new List<NavNode>();
        }

        public NavNode(Coordinate coord)
        {
            Coord = new Coordinate(coord.XCoord, coord.YCoord);
            Neighbours = new List<NavNode>();
        }

        public void SetAllNeighbours(IEnumerable<NavNode> nodes)
        {
            Neighbours = nodes.ToList();
        }

        public void AddNeighbour(NavNode node)
        {
            Neighbours.Add(node);
        }
    }
}
