using System;
using System.Linq;
using Code.Enums;
using Code.Generators.Weapons;
using Code.Helpers;
using Code.Infrastructure.Persistance;
using Code.Infrastructure.Repositories;
using Code.UI;
using Code.Weapons;
using Code.Weapons.Rifle;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code.Sandbox
{
    public class RifleSpawner : MonoBehaviour
    {
        public Transform Platform;
        public GameObject RiflePrefab;
        public RiflePanel Panel;

        private RifleStats currentRifleStats;
        private RifleAssemblyData currentRifleData;

        void Start()
        {
            GenerateNewRifle();   
        }

        void GenerateNewRifle()
        {
            var rifle = Instantiate(RiflePrefab, Platform).GetComponent<Rifle>();

            var body = Instantiate(Repos.RifleRepo.GetRandomBody(), rifle.transform);
            var stock = Instantiate(Repos.RifleRepo.GetRandomStock());
            var mag = Instantiate(Repos.RifleRepo.GetRandomMag());
            var barrel = Instantiate(Repos.RifleRepo.GetRandomBarrel());

            var quality = Enum.GetValues(typeof(ItemQuality)).Cast<ItemQuality>().PickOne();

            rifle.Initialize(WeaponGenerator.GenerateNewRifle(quality), body.transform, barrel.transform, stock.transform, mag.transform);

            Panel.FillRifleStats(rifle.Stats);

            currentRifleStats = rifle.Stats;
            currentRifleData = new RifleAssemblyData
            {
                BarrelId = barrel.GetComponent<AssemblyPart>().AssemblyPartId,
                BodyId = body.GetComponent<AssemblyPart>().AssemblyPartId,
                StockId = stock.GetComponent<AssemblyPart>().AssemblyPartId,
                MagId = mag.GetComponent<AssemblyPart>().AssemblyPartId,
            };
        }

        public void GenerateRifle()
        {
            Destroy(Platform.GetComponentInChildren<Rifle>().gameObject);
            GenerateNewRifle();
        }

        public void TestRifle()
        {
            Session.GeneratedRifleAssembly = currentRifleData;
            Session.GeneratedRifleStats = currentRifleStats;
            SceneManager.LoadScene("ShootingRange");
        }
    }
}
