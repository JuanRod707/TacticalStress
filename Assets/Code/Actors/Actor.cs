using Code.Action;
using Code.Tactical;
using Code.UI;
using Code.UI.Action;
using UnityEngine;

namespace Code.Actors
{
    public class Actor : MonoBehaviour
    {
        public DynamicText TimeUnitsLabel;

        public ActionModeInput ActionInput;
        public ActionModeController ActionController;
        public TacticalController TacticalController;

        public ActorStats Stats { get; private set; }

        void Start()
        {
            Stats = new ActorStats(TimeUnitsLabel, 34);
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
    }
}
