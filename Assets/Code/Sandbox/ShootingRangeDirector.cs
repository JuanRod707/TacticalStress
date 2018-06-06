using Code.Actors;
using Code.Cameras;
using Code.Enums;
using Code.Generators.Weapons;
using Code.Infrastructure.Persistance;
using Code.Infrastructure.Repositories;
using Code.UI;
using Code.UI.Action;
using UnityEngine;

namespace Code.Sandbox
{
    public class ShootingRangeDirector : MonoBehaviour
    {
        public DualPointCamera Camera;
        public Actor Actor;
        public AttackPanel ActionModePanel;

        void Start()
        {
            Camera.SetCameraPoints(Actor.ActionInput.ShoulderCamera, Actor.ActionInput.AimPoint);
            InitializeRifle();
            ActionModePanel.Crosshair.AttachToActor(Actor);
            Actor.SwitchToActionMode(ActionModePanel);
        }

        void InitializeRifle()
        {
            var rifle = Actor.ActionController.Weapon;

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
