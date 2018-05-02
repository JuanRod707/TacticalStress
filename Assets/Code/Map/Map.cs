using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Code.Map
{
    public class Map
    {
        public int SizeX;
        public int SizeY;
        public int Floors;

        public CellData FindCell(Coordinate coord)
        {
            return new CellData();
        }
    }
}
