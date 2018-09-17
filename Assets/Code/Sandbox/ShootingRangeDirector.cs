using Code.Actors;
using Code.Cameras;
using Code.Enums;
using Code.Generators.Weapons;
using Code.Infrastructure.Persistance;
using Code.Infrastructure.Repositories;
using Code.UI.Action;
using Code.Weapons.GrenadeLauncher;
using Code.Weapons.Minigun;
using Code.Weapons.Rifle;
using Code.Weapons.Shotgun;
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
        public GameObject ShotgunPrefab;
        public GameObject MinigunPrefab;

        void Start()
        {
            Camera.SetCameraPoints(Actor.ActionInput.ShoulderCamera, Actor.ActionInput.AimPoint);
            InitializeWeapon();
            ActionModePanel.Crosshair.AttachToActor(Actor);
            Actor.SwitchToActionMode(ActionModePanel);
        }

        void InitializeWeapon()
        {
            Transform weapon;
            if (Session.GeneratedRifleStats == null)
            {
                weapon = SpawnShotgun();
                //weapon = SpawnLauncher();
                //weapon = SpawnMinigun();
            }
            else
            {
                weapon = SpawnRifle();
            }

            Actor.EquipWeapon(weapon);
        }

        Transform SpawnLauncher()
        {
            var launcher = Instantiate(LauncherPrefab).GetComponent<GrenadeLauncher>();
            launcher.Initialize(WeaponGenerator.GenerateNewGrenadeLauncher(ItemQuality.Common));
            return launcher.transform;
        }

        Transform SpawnShotgun()
        {
            var shotgun = Instantiate(ShotgunPrefab).GetComponent<Shotgun>();
            shotgun.Initialize(WeaponGenerator.GenerateNewShotgun(ItemQuality.Common));
            return shotgun.transform;
        }

        Transform SpawnMinigun()
        {
            var minigun = Instantiate(MinigunPrefab).GetComponent<Minigun>();
            minigun.Initialize(WeaponGenerator.GenerateNewMinigun(ItemQuality.Common));
            return minigun.transform;

        }

        Transform SpawnRifle()
        {
            var rifle = Instantiate(RiflePrefab).GetComponent<Rifle>();
            var body = Instantiate(Repos.RifleRepo.GetBody(Session.GeneratedRifleAssembly.BodyId), rifle.transform);
            var stock = Instantiate(Repos.RifleRepo.GetStock(Session.GeneratedRifleAssembly.StockId), rifle.transform);
            var mag = Instantiate(Repos.RifleRepo.GetMag(Session.GeneratedRifleAssembly.MagId), rifle.transform);
            var barrel = Instantiate(Repos.RifleRepo.GetBarrel(Session.GeneratedRifleAssembly.BarrelId), rifle.transform);

            rifle.Initialize(Session.GeneratedRifleStats, body.transform, barrel.transform,
                stock.transform, mag.transform);

            return rifle.transform;
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
