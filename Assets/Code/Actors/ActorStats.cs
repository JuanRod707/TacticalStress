using Code.UI;
using UnityEngine;

namespace Code.Actors
{
    public class ActorStats
    {
        public int StartingTimeUnits;
        public int CurrentTimeUnits
        {
            get { return currentTimeUnits; }
        }

        DynamicText timeLabel;

        private int currentTimeUnits;

        public ActorStats(DynamicText label, int timeUnits)
        {
            StartingTimeUnits = timeUnits;
            timeLabel = label;
            ResetTimeUnits();
        }

        public bool CommitTimeAction(int timeCost)
        {
            if (currentTimeUnits >= timeCost)
            {
                currentTimeUnits -= timeCost;
                timeLabel.SetDynamicText(currentTimeUnits);
                return true;
            }

            return false;
        }

        public void ResetTimeUnits()
        {
            currentTimeUnits = StartingTimeUnits;
            timeLabel.SetDynamicText(currentTimeUnits);
        }
    }
}
