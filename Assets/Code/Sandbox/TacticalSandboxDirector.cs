using Code.Actors;
using Code.Enums;
using Code.Generators.Weapons;
using Code.Infrastructure.Persistance;
using Code.Infrastructure.Repositories;
using UnityEngine;

namespace Assets.Code.Sandbox
{
    public class TacticalSandboxDirector : MonoBehaviour
    {
        public Actor[] Squad;

        void Start()
        {
            foreach (var actor in Squad)
            {
                InitializeRifle(actor);
                actor.SwitchToTacticalMode();
            }
        }

        void InitializeRifle(Actor actor)
        {
            var rifle = actor.ActionController.Weapon;
            var body = Instantiate(Repos.RifleRepo.GetRandomBody(), rifle.transform);
            var stock = Instantiate(Repos.RifleRepo.GetRandomStock());
            var mag = Instantiate(Repos.RifleRepo.GetRandomMag());
            var barrel = Instantiate(Repos.RifleRepo.GetRandomBarrel());

            rifle.Initialize(WeaponGenerator.GenerateNewRifle(ItemQuality.Common), body.transform, barrel.transform,
                stock.transform, mag.transform);
        }
    }
}
