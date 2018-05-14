using Assets.Code.UI;
using UnityEngine;

namespace Code.Actors
{
    public class ActorStats : MonoBehaviour
    {
        public int StartingTimeUnits;
        public DynamicText TUsLabel;

        private int currentTimeUnits;

        void Start()
        {
            ResetTimeUnits();
        }

        public bool CommitTimeAction(int timeCost)
        {
            if (currentTimeUnits >= timeCost)
            {
                currentTimeUnits -= timeCost;
                TUsLabel.SetDynamicText(currentTimeUnits);
                return true;
            }

            return false;
        }

        public void ResetTimeUnits()
        {
            currentTimeUnits = StartingTimeUnits;
            TUsLabel.SetDynamicText(currentTimeUnits);
        }
    }
}
