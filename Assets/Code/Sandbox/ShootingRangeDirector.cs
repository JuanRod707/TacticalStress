using Code.Action;
using Code.Cameras;
using Code.Enums;
using Code.Generators.Weapons;
using Code.Infrastructure.Persistance;
using Code.Infrastructure.Repositories;
using Code.UI;
using UnityEngine;

namespace Code.Sandbox
{
    public class ShootingRangeDirector : MonoBehaviour
    {
        public DualPointCamera Camera;
        public TPSController actor;
        public AdvancedCrosshair Crosshair;

        void Start()
        {
            Camera.SetCameraPoints(actor.ShoulderCamera, actor.AimPoint);
            InitializeRifle();
            Crosshair.AttachWeapon(actor.Weapon);
        }

        void InitializeRifle()
        {
            var rifle = actor.Weapon;

            if (Session.GeneratedRifleStats == null)
            {
                var body = Instantiate(Repos.RifleRepo.GetRandomBody(), rifle.transform);
                var stock = Instantiate(Repos.RifleRepo.GetRandomStock());
                var mag = Instantiate(Repos.RifleRepo.GetRandomMag());
                var barrel = Instantiate(Repos.RifleRepo.GetRandomBarrel());

                rifle.Initialize(WeaponGenerator.GenerateNewRifle(ItemQuality.Common), body.transform, barrel.transform,
                    stock.transform, mag.transform);
            }
            else
            {
                var body = Instantiate(Repos.RifleRepo.GetBody(Session.GeneratedRifleAssembly.BodyId), rifle.transform);
                var stock = Instantiate(Repos.RifleRepo.GetStock(Session.GeneratedRifleAssembly.StockId), rifle.transform);
                var mag = Instantiate(Repos.RifleRepo.GetMag(Session.GeneratedRifleAssembly.MagId), rifle.transform);
                var barrel = Instantiate(Repos.RifleRepo.GetBarrel(Session.GeneratedRifleAssembly.BarrelId), rifle.transform);

                rifle.Initialize(Session.GeneratedRifleStats, body.transform, barrel.transform,
                    stock.transform, mag.transform);
            }
        }
    }
}
