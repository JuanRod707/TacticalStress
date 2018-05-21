using System;
using System.Linq;
using Code.Helpers;
using UnityEngine;

namespace Code.Infrastructure.Repositories
{
    public class RiflePartsRepository : MonoBehaviour
    {
        public GameObject[] Bodies;
        public GameObject[] Mags;
        public GameObject[] Stocks;
        public GameObject[] Barrels;

        public GameObject GetBody(int itemId)
        {
            try
            {
                return Bodies[itemId];
            }
            catch (IndexOutOfRangeException)
            {
                return Bodies.First();
            }
        }

        public GameObject GetMag(int itemId)
        {
            try
            {
                return Mags[itemId];
            }
            catch (IndexOutOfRangeException)
            {
                return Mags.First();
            }
        }

        public GameObject GetStock(int itemId)
        {
            try
            {
                return Stocks[itemId];
            }
            catch (IndexOutOfRangeException)
            {
                return Stocks.First();
            }
        }

        public GameObject GetBarrel(int itemId)
        {
            try
            {
                return Barrels[itemId];
            }
            catch (IndexOutOfRangeException)
            {
                return Barrels.First();
            }
        }

        public GameObject GetRandomBody()
        {
            return Bodies.PickOne();
        }

        public GameObject GetRandomMag()
        {
            return Mags.PickOne();
        }

        public GameObject GetRandomStock()
        {
            return Stocks.PickOne();
        }

        public GameObject GetRandomBarrel()
        {
            return Barrels.PickOne();
        }
    }
}
