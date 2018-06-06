using System;

namespace Assets.Code.Actors
{
    [Serializable]
    public class Stats
    {
        public float Accuracy;
        public float Stress;
        public int TimeUnits;
        public int Bravery;
        public float HitPoints;

        public float CurrentAccuracy
        {
            get { return Accuracy - Stress; }
        }
    }
}
