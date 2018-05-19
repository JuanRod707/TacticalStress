using Assets.Code.Enums;
using Assets.Code.Generators.Weapons;
using Assets.Code.Helpers;
using Assets.Code.Repositories;
using Assets.Code.UI;
using Assets.Code.Weapons;
using UnityEngine;

namespace Assets.Code.Sandbox
{
    public class RifleSpawner : MonoBehaviour
    {
        public Transform Platform;
        public GameObject RiflePrefab;
        public RiflePanel Panel;

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

            rifle.LoadParts(body.transform, barrel.transform, stock.transform, mag.transform);
            rifle.LoadStats(WeaponGenerator.GenerateNewRifle(ItemQuality.Common));

            Panel.FillRifleStats(rifle.Stats);
        }

        public void GenerateRifle()
        {
            Destroy(Platform.GetComponentInChildren<Rifle>().gameObject);
            GenerateNewRifle();
        }
    }
}
