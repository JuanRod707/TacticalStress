using Code.Enums;

namespace Code.Weapons.Shotgun
{
    public class ShotgunStats : WeaponStats
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
        public int PelletCount { get; set; }

        public ShotgunStats()
        {
            AimBonus = 5f;
            AimZoomModifier = 25f;
            AimPercentageCost = 10;
            ReloadPercentageCost = 20;
            PelletCount = 8;
        }
    }
}
