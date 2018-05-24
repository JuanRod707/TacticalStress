using UnityEngine;

namespace Code.UI.Action
{
    public class AttackPanel : MonoBehaviour
    {
        public DynamicText TimeUnits;
        public DynamicText Ammo;
        public DynamicText ReloadAction;
        public DynamicText FireAction;
        public DynamicText AimAction;

        public void UpdateTimeUnits(int total, int remaining)
        {
            TimeUnits.SetDynamicText(total, remaining);
        }

        public void UpdateAmmo(int total, int remaining)
        {
            Ammo.SetDynamicText(total, remaining);
        }

        public void UpdateReload(int timeUnits)
        {
            ReloadAction.SetDynamicText(timeUnits);
        }

        public void UpdateFireAction(string modeName, int timeUnits)
        {
            ReloadAction.SetDynamicText(modeName, timeUnits);
        }

        public void UpdateAimAction(int timeUnits)
        {
            AimAction.SetDynamicText(timeUnits);
        }
    }
}
