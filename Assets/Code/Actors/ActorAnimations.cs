using Code.Enums;
using Code.Weapons;
using UnityEngine;

namespace Code.Actors
{
    public class ActorAnimations : MonoBehaviour
    {
        public Actor Actor;

        private Animator animatorController;
        private Weapon WeaponHeld {
            get { return Actor.WeaponSpot.GetComponentInChildren<Weapon>(); }
        }

        public void SwapWeapon()
        {
            LoadController();
            var weapon = WeaponHeld;

            if (WeaponHeld != null)
            {
                switch (weapon.WeaponType)
                {
                    case WeaponType.Rifle:
                    case WeaponType.GrenadeLauncher:
                    case WeaponType.Shotgun:
                    case WeaponType.SniperRifle:
                    case WeaponType.Submachinegun:
                    case WeaponType.Machinegun:
                        animatorController.SetTrigger("AimRifle");
                        break;
                    case WeaponType.Pistol:
                        animatorController.SetTrigger("AimPistol");
                        break;
                    case WeaponType.Minigun:
                        animatorController.SetTrigger("AimMinigun");
                        break;
                }
            }
        }

        void LoadController()
        {
            if (animatorController == null)
            {
                animatorController = GetComponent<Animator>();
            }
        }
    }
}
