using Code.UI;
using UnityEngine;

namespace Code.Actors
{
    public class TimeActions
    {
        public int CurrentTimeUnits
        {
            get { return currentTimeUnits; }
        }

        DynamicText timeLabel;

        int startingTimeUnits;
        int currentTimeUnits;

        public TimeActions(DynamicText label, int timeUnits)
        {
            startingTimeUnits = timeUnits;
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
            currentTimeUnits = startingTimeUnits;
            timeLabel.SetDynamicText(currentTimeUnits);
        }
    }
}
