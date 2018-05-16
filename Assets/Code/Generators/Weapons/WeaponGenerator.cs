using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Code.Enums;
using Assets.Code.Helpers;
using Assets.Code.Weapons;

namespace Assets.Code.Generators.Weapons
{
    public class WeaponGenerator
    {
        public static RifleStats GenerateNewRifle(ItemQuality quality)
        {
            var genData = RifleGenerationPresets.CommonRifleData;
            var stats = new RifleStats();

            stats.Accuracy = RandomService.GetRandom(genData.MinAccuracy, genData.MaxAccuracy);
            stats.MinAccuracy = stats.Accuracy - 20;
            stats.AimDistance = 20f;
            stats.AimRecovery = 0.8f;
            stats.Quality = quality;
            stats.DamagePerRound = RandomService.GetRandom(genData.MinDamagePerRound, genData.MaxDamagePerRound);
            stats.PushForce = stats.DamagePerRound * 10;
            stats.Range = RandomService.GetRandom(genData.MinRange, genData.MaxRange);
            stats.RateOfFire = RandomService.GetRandom(genData.MinRateOfFire, genData.MaxRateOfFire);
            stats.Recoil = RandomService.GetRandom(genData.MinRecoil, genData.MaxRecoil);
            stats.AmmoPerMag = RandomService.GetRandom(genData.MinAmmoPerMag, genData.MaxAmmoPerMag);

            return stats;
        }
    }
}
