using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Code.Generators.Weapons
{
    [Serializable]
    public class RifleGenertationData
    {
        public float MinRateOfFire;
        public float MaxRateOfFire;

        public float MinDamagePerRound;
        public float MaxDamagePerRound;

        public int MinAmmoPerMag;
        public int MaxAmmoPerMag;

        public float MinAccuracy;
        public float MaxAccuracy;

        public float MinRange;
        public float MaxRange;

        public float MinRecoil;
        public float MaxRecoil;
    }
}
