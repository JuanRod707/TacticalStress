using System.Collections.Generic;
using Assets.Code.Map;
using Code.Helpers;

namespace Code.Map
{
    public class Map
    {
        public int SizeX;
        public int SizeZ;
        public int Floors;

        List<CellData> cells;
        private CellData[,] matrix;

        public IEnumerable<CellData> Cells { get { return cells; } }
        
        public Map(int sizeX, int sizeZ)
        {
            SizeX = sizeX;
            SizeZ = sizeZ;
            matrix = new CellData[sizeX, sizeZ];
            cells = new List<CellData>();

            for (int x = 0; x < sizeX; x++)
            {
                for (int z = 0; z < sizeZ; z++)
                {
                    var cell = new CellData(x, z);
                    RandomizePassable(cell);
                    matrix[x, z] = cell;
                    cells.Add(cell);
                }
            }
        }

        public CellData FindCell(Coordinate coord)
        {
            return matrix[coord.XCoord, coord.YCoord];
        }

        void RandomizePassable(CellData cell)
        {
            if(!GridHelper.IsBorderTile(cell.Coordinate, SizeX, SizeZ))
            {
                var roll = RandomService.GetRandom(0, 100);
                if (roll > 5)
                {
                    cell.Passable = true;
                }
            }
        }
    }
}
