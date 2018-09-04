using Code.Enums;

namespace Code.Weapons
{
    public interface WeaponStats
    {
        ItemQuality Quality { get; set; }
        float RateOfFire { get; set; }
        float PushForce { get; set; }
        float DamagePerRound { get; set; }
        int AmmoPerMag { get; set; }

        float Accuracy { get; set; }
        float MinAccuracy { get; set; }
        float AimDistance { get; set; }

        float Range { get; set; }
        float Recoil { get; set; }
        float AimRecovery { get; set; }

        float AimBonus { get; set; }
        float AimZoomModifier { get; set; }
        int AimPercentageCost { get; set; }
        int ReloadPercentageCost { get; set; }
    }
}
