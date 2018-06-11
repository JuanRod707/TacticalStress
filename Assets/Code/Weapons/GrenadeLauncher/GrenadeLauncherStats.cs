using Code.Enums;

namespace Code.Weapons.GrenadeLauncher
{
    public class GrenadeLauncherStats : WeaponStats
    {
        public ItemQuality Quality;
        public float RateOfFire;
        public float PushForce;
        public float DamagePerRound;
        public int AmmoPerMag;

        public float Accuracy;
        public float MinAccuracy;
        public float AimDistance;
        
        public float Recoil;
        public float AimRecovery;

        public float AimBonus = 5f;
        public float AimZoomModifier = 25f;
        public int AimPercentageCost = 10;
        public int ReloadPercentageCost = 20;
    }
}
