using Code.Enums;
using Code.Helpers;
using Code.Weapons;
using Code.Weapons.GrenadeLauncher;
using Code.Weapons.Rifle;
using Code.Weapons.Shotgun;

namespace Code.Generators.Weapons
{
    public class WeaponGenerator
    {
        public static RifleStats GenerateNewRifle(ItemQuality quality)
        {
            var genData = RifleGenerationPresets.GenData[quality];
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

        public static GrenadeLauncherStats GenerateNewGrenadeLauncher(ItemQuality quality)
        {
            var genData = LauncherGenerationPresets.GenData[quality];
            var stats = new GrenadeLauncherStats();

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

        public static ShotgunStats GenerateNewShotgun(ItemQuality quality)
        {
            var genData = ShotgunGenerationPresets.GenData[quality];
            var stats = new ShotgunStats();

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

        public static MinigunStats GenerateNewMinigun(ItemQuality quality)
        {
            var genData = MinigunGenerationPresets.GenData[quality];
            var stats = new MinigunStats();

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
