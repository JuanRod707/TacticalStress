using Code.Actors;
using Code.Enums;
using Code.Generators.Weapons;
using Code.Helpers;
using Code.Infrastructure.Repositories;
using Code.Weapons;
using Code.Weapons.Rifle;
using UnityEngine;

namespace Code.Sandbox
{
    public class TacticalSandboxDirector : MonoBehaviour
    {
        public Actor[] Squad;
        public GameObject[] Weapons;

        void Start()
        {
            foreach (var actor in Squad)
            {
                var weapon = Instantiate(Weapons.PickOne());
                weapon.GetComponent<Weapon>().Randomize();
                
                actor.EquipWeapon(weapon.transform);
                actor.SwitchToTacticalMode();
            }
        }
    }
}
