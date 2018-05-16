using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Code.Enums;

namespace Assets.Code.Weapons
{
    [Serializable]
    public class RifleStats : WeaponStats
    {
        public ItemQuality Quality;
        public float RateOfFire;
        public float PushForce;
        public float DamagePerRound;
        public int AmmoPerMag;

        public float Accuracy;
        public float MinAccuracy;
        public float AimDistance;

        public float Range;
        public float Recoil;
        public float AimRecovery;
    }
}
