using System.Collections.Generic;
using System.Linq;
using Assets.Code.Pathfinding;
using UnityEngine;

namespace Assets.Code.Map
{
    public class MapGen : MonoBehaviour
    {
        public int SizeX;
        public int SizeZ;
        public int WallChance;
        public float CellDimension;
        public bool SimpleNavigation;
        public GameObject FloorCell;
        public GameObject WallCell;
        public Transform CellContainer;

        private List<Cell> cellList;
        Map map;
        int xCoord = 0;
        int zCoord = 0;

        public NavMap NavigationMap { get; private set; }

        void Start ()
        {
            map = new Map(SizeX, SizeZ, WallChance);
            cellList = new List<Cell>();
            GenerateNavigationMap();
            CellPlacementRoutine();
        }
	
        private void CellPlacementRoutine()
        {
            foreach (var cellData in map.Cells)
            {
                GameObject cellPrefab = cellData.Passable ? FloorCell : WallCell;
                var cell = Instantiate(cellPrefab, new Vector3(cellData.Coordinate.XCoord * CellDimension, 0f
                    , cellData.Coordinate.YCoord * CellDimension), Quaternion.identity).GetComponent<Cell>();
                cell.transform.SetParent(CellContainer);

                cell.Initialize(this, NavigationMap.GetNavNode(cellData.Coordinate), cellData);
                cellList.Add(cell);
            }
        }

        private void GenerateNavigationMap()
        {
            NavigationMap = new NavMap();
            NavigationMap.GenerateNavMap(map, SimpleNavigation);
        }

        public Cell FindCell(Coordinate coord)
        {
            return cellList.First(c => c.Coordinate.Is(coord));
        }
    }
}