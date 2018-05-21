using System;
using System.Linq;
using Assets.Code.Weapons;
using Code.Helpers;
using UnityEngine;

namespace Code.Infrastructure.Repositories
{
    public class RiflePartsRepository : MonoBehaviour
    {
        public AssemblyPart[] Bodies;
        public AssemblyPart[] Mags;
        public AssemblyPart[] Stocks;
        public AssemblyPart[] Barrels;

        public GameObject GetBody(string itemId)
        {
            try
            {
                return Bodies.First(x => x.AssemblyPartId.Equals(itemId)).gameObject;
            }
            catch (IndexOutOfRangeException)
            {
                return Bodies.First().gameObject;
            }
        }

        public GameObject GetMag(string itemId)
        {
            try
            {
                return Mags.First(x => x.AssemblyPartId.Equals(itemId)).gameObject;
            }
            catch (IndexOutOfRangeException)
            {
                return Mags.First().gameObject;
            }
        }

        public GameObject GetStock(string itemId)
        {
            try
            {
                return Stocks.First(x => x.AssemblyPartId.Equals(itemId)).gameObject;
            }
            catch (IndexOutOfRangeException)
            {
                return Stocks.First().gameObject;
            }
        }

        public GameObject GetBarrel(string itemId)
        {
            try
            {
                return Barrels.First(x => x.AssemblyPartId.Equals(itemId)).gameObject;
            }
            catch (IndexOutOfRangeException)
            {
                return Barrels.First().gameObject;
            }
        }

        public GameObject GetRandomBody()
        {
            return Bodies.PickOne().gameObject;
        }

        public GameObject GetRandomMag()
        {
            return Mags.PickOne().gameObject;
        }

        public GameObject GetRandomStock()
        {
            return Stocks.PickOne().gameObject;
        }

        public GameObject GetRandomBarrel()
        {
            return Barrels.PickOne().gameObject;
        }
    }
}
