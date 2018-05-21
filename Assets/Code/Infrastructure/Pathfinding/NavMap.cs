using System.Collections.Generic;
using System.Linq;
using Code.Helpers;
using Code.Infrastructure.Map;
using UnityEngine;

namespace Code.Infrastructure.Pathfinding
{
    public class NavMap
    {
        public GameObject NodePrefab;
        public int HeightDifTolerance;
        public int WaterLevel;

        private List<NavNode> navigationNodes;

        public IEnumerable<NavNode> Graph
        {
            get { return navigationNodes; }
        }

        public void GenerateNavMap(Map.Map map, bool generateOnly4Neighbours)
        {
            navigationNodes = new List<NavNode>();

            foreach (var cell in map.Cells)
            {
                navigationNodes.Add(new NavNode(cell.Coordinate));
            }

            foreach (var cell in map.Cells.Where(c => c.Passable))
            {
                var node = GetNavNode(cell.Coordinate);
                var nbs = generateOnly4Neighbours ? GridHelper.Find4Neighbours(node.Coord) : GridHelper.Find8Neighbours(node.Coord);
                foreach (var nb in nbs.Where(c => c.IsValidInMatrix(map.SizeX, map.SizeZ)))
                {
                    var candidate = GetNavNode(nb);
                    var nbCell = map.Cells.First(x => x.Coordinate.Is(nb));
                    if (nbCell.Passable)
                    {
                        node.Neighbours.Add(candidate);
                    }
                }
            }
        }

        public NavNode GetNavNode(Coordinate coord)
        {
            return navigationNodes.First(n => n.Coord.Is(coord.XCoord, coord.YCoord));
        }
    }
}