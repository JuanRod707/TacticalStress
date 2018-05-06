using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Code.Map
{
    public class CellData
    {
        public Coordinate Coordinate { get; private set; }

        public bool Passable { get; set; }

        public CellData(int x, int z)
        {
            Coordinate = new Coordinate(x, z);
        }
    }
}
