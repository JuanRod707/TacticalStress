using Code.Enums;

namespace Code.Weapons.GrenadeLauncher
{
    public class GrenadeLauncherStats : WeaponStats
    {
        public ItemQuality Quality { get; set; }
        public float RateOfFire { get; set; }
        public float PushForce { get; set; }
        public float DamagePerRound { get; set; }
        public int AmmoPerMag { get; set; }
        public float Accuracy { get; set; }
        public float MinAccuracy { get; set; }
        public float AimDistance { get; set; }
        public float Range { get; set; }
        public float Recoil { get; set; }
        public float AimRecovery { get; set; }
        public float AimBonus { get; set; }
        public float AimZoomModifier { get; set; }
        public int AimPercentageCost { get; set; }
        public int ReloadPercentageCost { get; set; }
        public float LaunchForce { get; set; }

        public GrenadeLauncherStats()
        {
            AimBonus = 5f;
            AimZoomModifier = 25f;
            AimPercentageCost = 10;
            ReloadPercentageCost = 20;
            LaunchForce = 1100f;
        }
    }
}
