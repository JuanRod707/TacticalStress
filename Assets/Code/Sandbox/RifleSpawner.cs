using Assets.Code.Helpers;
using Assets.Code.Weapons;
using UnityEngine;

namespace Assets.Code.Sandbox
{
    public class RifleSpawner : MonoBehaviour
    {
        public Transform Platform;

        public GameObject[] Bodies;
        public GameObject[] Mags;
        public GameObject[] Stocks;
        public GameObject[] Barrels;

        void Start()
        {
            GenerateNewRifle();   
        }

        void GenerateNewRifle()
        {
            var rifle = Instantiate(Bodies.PickOne(), Platform);

            var stock = Instantiate(Stocks.PickOne(), rifle.transform);
            var mag = Instantiate(Mags.PickOne(), rifle.transform);
            var barrel = Instantiate(Barrels.PickOne(), rifle.transform);

            rifle.GetComponent<RifleAssembly>().Assemble(barrel, stock, mag);
        }
    }
}
