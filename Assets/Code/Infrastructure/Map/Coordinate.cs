﻿using System;
using UnityEngine;

namespace Code.Infrastructure.Map
{
    [Serializable]
    public struct Coordinate
    {
        public int XCoord;
        public int YCoord;

        public Coordinate(int x, int y)
        {
            XCoord = x;
            YCoord = y;
        }

        public override string ToString()
        {
            return string.Format("({0}, {1})", XCoord, YCoord);
        }

        public int DistanceTo(Coordinate coord)
        {
            var side1 = coord.XCoord - XCoord;
            var side2 = coord.YCoord - YCoord;
            return (int) Mathf.Sqrt(side1*side1 + side2*side2);
        }

        public bool IsValidInMatrix(int x, int y)
        {
            var isValidX = XCoord >= 0 && XCoord < x;
            var isValidY = YCoord >= 0 && YCoord < y;

            return isValidX & isValidY;
        }

        public bool Is(int x, int y)
        {
            return XCoord == x && YCoord == y;
        }

        public bool Is(Coordinate coord)
        {
            return Is(coord.XCoord, coord.YCoord);
        }
    }
}
