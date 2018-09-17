using Assets.Code.Actors;
using Code.Action;
using Code.Tactical;
using Code.UI;
using Code.UI.Action;
using UnityEngine;

namespace Code.Actors
{
    public class Actor : MonoBehaviour
    {
        public Stats Stats;
        public DynamicText TimeUnitsLabel;
        public ActionModeInput ActionInput;
        public ActionModeController ActionController;
        public TacticalController TacticalController;
        public ActorAnimations AnimationController;
        public Transform WeaponSpot;
        public TimeActions TimeActions { get; private set; }

        public float Inaccuracy
        {
            get { return 1 - (100f / (Stats.CurrentAccuracy + ActionController.Weapon.CurrentAccuracy)); }
        }

        void Start()
        {
            TimeActions = new TimeActions(TimeUnitsLabel, Stats.TimeUnits);
        }

        public void SwitchToActionMode(AttackPanel panel)
        {
            TacticalController.Deactivate();
            ActionController.Activate();
            ActionInput.Activate();

            ActionController.Initialize(
                panel.UpdateTimeUnits, 
                panel.UpdateAmmo, 
                panel.UpdateAimAction, 
                panel.UpdateReload, 
                panel.UpdateFireAction);
        }

        public void SwitchToTacticalMode()
        {
            TacticalController.Activate();
            ActionController.Deactivate();
            ActionInput.Deactivate();
        }

        public void EquipWeapon(Transform weapon)
        {
            weapon.SetParent(WeaponSpot);
            weapon.localPosition = Vector3.zero;
            weapon.localScale = Vector3.one;
            weapon.localRotation = Quaternion.identity;
            AnimationController.SwapWeapon();
        }
    }
}
