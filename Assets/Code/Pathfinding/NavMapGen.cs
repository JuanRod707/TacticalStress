using UnityEngine;
using Assets.Code.Map;
using Code.Helpers;

namespace Code.Pathfinding
{
    public class NavMapGen : MonoBehaviour
    {
        public GameObject NodePrefab;
        public int HeightDifTolerance;
        public int WaterLevel;

        private NavNode[,] NavigationNodes;

        public NavNode[,] Graph
        {
            get { return NavigationNodes; }
        }

        public void GenerateNavMap(Map map)
        {
            NavigationNodes = new NavNode[map.SizeX, map.SizeY];

            for (int x = 0; x < map.SizeX; x++)
            {
                for (int y = 0; y < map.SizeY; y++)
                {
                    var coord = new Coordinate(x, y);
                    var tile = map.FindCell(coord);

                    var node = Instantiate(NodePrefab, tile.transform.position, Quaternion.identity);
                    node.transform.SetParent(this.transform);
                    var nodeInfo = node.GetComponent<NavNode>();
                    nodeInfo.Coord = coord;
                    nodeInfo.Passable = IsTilePassable(tile);
                    NavigationNodes[x, y] = nodeInfo;
                }
            }

            for (int x = 0; x < map.SizeX; x++)
            {
                for (int y = 0; y < map.SizeY; y++)
                {
                    var node = NavigationNodes[x, y];
                    if (node.Passable)
                    {
                        var nbs = GridHelper.FindAllNeighbours(node.Coord);
                        foreach (var n in nbs)
                        {
                            if (BoardManager.IsCoordValid(n))
                            {
                                var candidate = NavigationNodes[n.XCoord, n.YCoord];
                                if (candidate.Passable)
                                {
                                    node.Neighbours.Add(candidate);
                                }
                            }
                        }

                        node.DrawLines();
                    }
                    else
                    {
                        node.gameObject.SetActive(false);
                    }
                }
            }
        }

        public NavNode GetNavNode(Coordinate coord)
        {
            return NavigationNodes[coord.XCoord, coord.YCoord];
        }

        private bool IsTilePassable(CellData cell)
        {
            return true;
        }
    }
}