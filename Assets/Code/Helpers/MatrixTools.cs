using System.Collections.Generic;
using System.Linq;
using Code.Map;
using UnityEngine;

namespace Code.Helpers
{
    internal class MatrixTools<T>
    {
        protected T[,] board;

        protected int size
        {
            get { return board.GetLength(0); }
        }

        protected Coordinate GetRandomAdjacent(Coordinate coord)
        {
            var rndX = Random.Range(-1, 1);
            var rndY = Random.Range(-1, 1);
            var newCoord = new Coordinate(coord.XCoord + rndX, coord.YCoord + rndY);

            while (!IsValidTile(newCoord))
            {
                rndX = Random.Range(-1, 1);
                rndY = Random.Range(-1, 1);
                newCoord = new Coordinate(coord.XCoord + rndX, coord.YCoord + rndY);
            }

            return new Coordinate(coord.XCoord + rndX, coord.YCoord + rndY);
        }

        protected bool IsValidTile(Coordinate coord)
        {
            return coord.XCoord >= 0 && coord.XCoord < size && coord.YCoord >= 0 && coord.YCoord < size;
        }

        protected Coordinate GetRandomTile()
        {
            var rndX = Random.Range(0, size - 1);
            var rndY = Random.Range(0, size - 1);
            return new Coordinate(rndX, rndY);
        }

        protected T FindTile(Coordinate coord)
        {
            if (IsValidTile(coord))
            {
                return board[coord.XCoord, coord.YCoord];
            }

            return default(T);
        }

        protected IEnumerable<T> GetAllNeighbours(Coordinate coord)
        {
            var allAdjacent = GridHelper.Find4Neighbours(coord);
            return allAdjacent.Select(x => FindTile(x));
        }
    }
}