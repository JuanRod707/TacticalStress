using System;

namespace Code.Weapons
{
    [Serializable]
    public class FiringMode
    {
        public string ModeName;
        public int TimePercentageCost;
        public int RoundsToFire;
        public float AccuracyModifier;
    }
}
