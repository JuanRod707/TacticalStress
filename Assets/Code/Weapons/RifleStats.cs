using Code.Enums;

namespace Code.Weapons
{
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
