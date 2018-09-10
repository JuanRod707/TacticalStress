using Code.Actors;
using Code.Cameras;
using Code.Enums;
using Code.Generators.Weapons;
using Code.Infrastructure.Persistance;
using Code.Infrastructure.Repositories;
using Code.UI;
using Code.UI.Action;
using Code.Weapons.GrenadeLauncher;
using Code.Weapons.Rifle;
using UnityEngine;

namespace Code.Sandbox
{
    public class ShootingRangeDirector : MonoBehaviour
    {
        public DualPointCamera Camera;
        public Actor Actor;
        public AttackPanel ActionModePanel;
        public GameObject RiflePrefab;
        public GameObject LauncherPrefab;

        void Start()
        {
            Camera.SetCameraPoints(Actor.ActionInput.ShoulderCamera, Actor.ActionInput.AimPoint);
            InitializeWeapon();
            ActionModePanel.Crosshair.AttachToActor(Actor);
            Actor.SwitchToActionMode(ActionModePanel);
        }

        void InitializeWeapon()
        {
            var weaponSpot = Actor.ActionController.WeaponSpot;
            

            if (Session.GeneratedRifleStats == null)
            {
                SpawnLauncher(weaponSpot);
            }
            else
            {
                SpawnRifle(weaponSpot);
            }
        }

        void SpawnLauncher(Transform weaponSpot)
        {
            var launcher = Instantiate(LauncherPrefab, weaponSpot).GetComponent<GrenadeLauncher>();
            launcher.Initialize(WeaponGenerator.GenerateNewGrenadeLauncher(ItemQuality.Common));
        }

        void SpawnRifle(Transform weaponSpot)
        {
            var rifle = Instantiate(RiflePrefab, weaponSpot).GetComponent<Rifle>();
            var body = Instantiate(Repos.RifleRepo.GetBody(Session.GeneratedRifleAssembly.BodyId), rifle.transform);
            var stock = Instantiate(Repos.RifleRepo.GetStock(Session.GeneratedRifleAssembly.StockId), rifle.transform);
            var mag = Instantiate(Repos.RifleRepo.GetMag(Session.GeneratedRifleAssembly.MagId), rifle.transform);
            var barrel = Instantiate(Repos.RifleRepo.GetBarrel(Session.GeneratedRifleAssembly.BarrelId), rifle.transform);

            rifle.Initialize(Session.GeneratedRifleStats, body.transform, barrel.transform,
                stock.transform, mag.transform);
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                Actor.TimeActions.ResetTimeUnits();
            }
        }
    }
}
