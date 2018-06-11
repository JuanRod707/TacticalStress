using Code.Actors;
using Code.Weapons;
using System;
using Code.Cameras;
using Code.Helpers;
using Code.Weapons.Rifle;
using UnityEngine;

namespace Code.Action
{
    public class ActionModeController: MonoBehaviour
    {
        public Rifle Weapon;
        public Actor Actor;

        private Action<int, int> updateTimeDisplay = (a, b) => { };
        private Action<int, int> updateAmmoDisplay = (a, b) => { };
        private Action<int> updateAimDisplay = (a) => { };
        private Action<int> updateReloadDisplay = (a) => { };
        private Action<string, int> updateFireModeDisplay = (a, b) => { };

        private int BaseTimeUnits
        {
            get { return Actor.Stats.TimeUnits; }
        }

        public void AttackCommand()
        {
            var cost = MathHelper.CalculatePercentage(Weapon.CurrentMode.TimePercentageCost,
                BaseTimeUnits);

            if (Actor.TimeActions.CommitTimeAction(cost))
            {
                Weapon.Attack(updateAmmoDisplay);
                updateTimeDisplay(Actor.TimeActions.CurrentTimeUnits, BaseTimeUnits);
                Camera.main.GetComponent<CameraZoom>().ZoomOut();
            }
        }

        public void ReloadCommand()
        {
            var cost = MathHelper.CalculatePercentage(Weapon.Stats.ReloadPercentageCost,
                BaseTimeUnits);

            if (Actor.TimeActions.CommitTimeAction(cost))
            {
                Weapon.Reload();
                updateAmmoDisplay(Weapon.CurrentAmmo, Weapon.Stats.AmmoPerMag);
                updateTimeDisplay(Actor.TimeActions.CurrentTimeUnits, BaseTimeUnits);
            }
        }

        public void AimCommand()
        {
            var cost = MathHelper.CalculatePercentage(Weapon.Stats.AimPercentageCost,
                BaseTimeUnits);

            if (Actor.TimeActions.CommitTimeAction(cost))
            {
                Weapon.Aim();
                updateTimeDisplay(Actor.TimeActions.CurrentTimeUnits, BaseTimeUnits);
                Camera.main.GetComponent<CameraZoom>().ZoomIn(Weapon.Stats.AimZoomModifier);
            }
        }

        public void CycleFireCommand()
        {
            Weapon.CycleFiringMode();
            var cost = MathHelper.CalculatePercentage(Weapon.CurrentMode.TimePercentageCost,
                BaseTimeUnits);
            updateFireModeDisplay(Weapon.CurrentMode.ModeName, cost);
        }

        public void Initialize(
            Action<int, int> updateTime,
            Action<int, int> updateAmmo,
            Action<int> updateAim,
            Action<int> updateReload,
            Action<string, int> updateFireMode)
        {
            updateTimeDisplay = updateTime;
            updateAmmoDisplay = updateAmmo;
            updateAimDisplay = updateAim;
            updateReloadDisplay = updateReload;
            updateFireModeDisplay = updateFireMode;

            updateTimeDisplay(Actor.TimeActions.CurrentTimeUnits, BaseTimeUnits);
            updateAmmoDisplay(Weapon.CurrentAmmo, Weapon.Stats.AmmoPerMag);
            updateAimDisplay(MathHelper.CalculatePercentage(Weapon.Stats.AimPercentageCost, BaseTimeUnits));
            updateReloadDisplay(MathHelper.CalculatePercentage(Weapon.Stats.ReloadPercentageCost, BaseTimeUnits));
            updateFireModeDisplay(Weapon.CurrentMode.ModeName, MathHelper.CalculatePercentage(Weapon.CurrentMode.TimePercentageCost, BaseTimeUnits));
        }

        public void Activate()
        {
            this.enabled = true;
            Weapon.enabled = true;
        }

        public void Deactivate()
        {
            this.enabled = false;
            Weapon.enabled = false;
        }
    }
}
