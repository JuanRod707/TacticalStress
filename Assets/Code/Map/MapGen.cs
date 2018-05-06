using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Code.Map;
using Code.Pathfinding;

public class MapGen : MonoBehaviour
{
    public int SizeX;
    public int SizeZ;
    public float CellDimension;
    public GameObject FloorCell;
    public GameObject WallCell;
    public Transform CellContainer;

    private List<Cell> cellList;
    private NavMap navigationMap;
    Map map;
    int xCoord = 0;
    int zCoord = 0;

    private float TileRotation;
    
	void Start ()
	{
        map = new Map(SizeX, SizeZ);
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

            cell.Initialize(this, navigationMap.GetNavNode(cellData.Coordinate));
            cellList.Add(cell);
        }
    }

    private void GenerateNavigationMap()
    {
        navigationMap = new NavMap();
        navigationMap.GenerateNavMap(map);
    }

    public Cell FindCell(Coordinate coord)
    {
        return cellList.First(c => c.Coordinate.Is(coord));
    }
}