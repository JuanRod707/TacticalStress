using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Code.Helpers
{
    public class GridHelper
    {
        public static Coordinate FindNeighbour(Coordinate coord, Compass direction)
        {
            var x = coord.XCoord;
            var y = coord.YCoord;
            switch (direction)
            {
                case Compass.East:
                    return new Coordinate(x + 1, y);
                case Compass.SouthEast:
                    return new Coordinate(x + 1, y - 1);
                case Compass.South:
                    return new Coordinate(x, y - 1);
                case Compass.SouthWest:
                    return new Coordinate(x - 1, y - 1);
                case Compass.West:
                    return new Coordinate(x - 1, y);
                case Compass.NorthWest:
                    return new Coordinate(x - 1, y + 1);
                case Compass.North:
                    return new Coordinate(x, y + 1);
                case Compass.NorthEast:
                    return new Coordinate(x + 1, y + 1);
            }

            return new Coordinate(x, y);
        }

        public static IEnumerable<Coordinate> FindNeighbours(Coordinate coord, IEnumerable<Compass> directions)
        {
            var result = new List<Coordinate>();
            foreach (var d in directions)
            {
                result.Add(FindNeighbour(coord, d));
            }

            return result;
        }

        public static Compass FindDirectionToNeighbour(Coordinate coord, Coordinate nbr)
        {
            var x = coord.XCoord;
            var y = coord.YCoord;
            var nx = nbr.XCoord;
            var ny = nbr.YCoord;

            if (y % 2 != 0)
            {
                if (nx == x + 1 && ny == y)
                {
                    return Compass.East;
                }

                else if (nx == x + 1 && ny == y - 1)
                {
                    return Compass.SouthEast;
                }

                else if (nx == x && ny == y - 1)
                {
                    return Compass.South;
                }

                else if (nx == x - 1 && ny == y - 1)
                {
                    return Compass.SouthWest;
                }

                else if (nx == x - 1 && ny == y)
                {
                    return Compass.West;
                }

                else if (nx == x - 1 && ny == y + 1)
                {
                    return Compass.NorthWest;
                }

                else if (nx == x && ny == y + 1)
                {
                    return Compass.North;
                }

                else if (nx == x + 1 && ny == y + 1)
                {
                    return Compass.NorthEast;
                }
            }

            return Compass.East;
        }

        public static IEnumerable<Coordinate> Find8Neighbours(Coordinate coord)
        {
            var dirsToCheck = new[]
            {
                Compass.West, Compass.NorthWest, Compass.North, Compass.NorthEast, Compass.East, Compass.SouthEast,
                Compass.South, Compass.SouthWest
            };

            return dirsToCheck.Select(dir => FindNeighbour(coord, dir)).ToList();
        }

        public static IEnumerable<Coordinate> Find4Neighbours(Coordinate coord)
        {
            var dirsToCheck = new[]
            {
                Compass.West, Compass.North, Compass.East, Compass.South
            };

            return dirsToCheck.Select(dir => FindNeighbour(coord, dir)).ToList();
        }

        public static Compass GetOpposite(Compass direction)
        {
            switch (direction)
            {
                case Compass.East:
                    return Compass.West;

                case Compass.SouthEast:
                    return Compass.NorthWest;

                case Compass.South:
                    return Compass.North;

                case Compass.SouthWest:
                    return Compass.NorthEast;

                case Compass.West:
                    return Compass.East;

                case Compass.NorthWest:
                    return Compass.SouthEast;

                case Compass.North:
                    return Compass.South;

                case Compass.NorthEast:
                    return Compass.SouthWest;
            }

            return Compass.West;
        }

        public static bool AreOpposite(Compass dir1, Compass dir2)
        {
            return GetOpposite(dir1) == dir2;
        }

        public static bool IsBorderTile(Coordinate coord, int SizeX, int SizeY)
        {
            var isBorderX = coord.XCoord == 0 || coord.XCoord == SizeX - 1;
            var isBorderY = coord.YCoord == 0 || coord.YCoord == SizeY - 1;

            return isBorderY | isBorderX;
        }
    }
}