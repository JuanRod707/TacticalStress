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

        public void UpdateTimeUnits(int remaining, int total)
        {
            TimeUnits.SetDynamicText(remaining, total);
        }

        public void UpdateAmmo(int remaining, int total)
        {
            Ammo.SetDynamicText(remaining, total);
        }

        public void UpdateReload(int timeUnits)
        {
            ReloadAction.SetDynamicText(timeUnits);
        }

        public void UpdateFireAction(string modeName, int timeUnits)
        {
            FireAction.SetDynamicText(modeName, timeUnits);
        }

        public void UpdateAimAction(int timeUnits)
        {
            AimAction.SetDynamicText(timeUnits);
        }
    }
}
