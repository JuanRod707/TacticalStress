using System.Collections.Generic;
using Code.Enums;

namespace Code.Generators.Weapons
{
    static class LauncherGenerationPresets
    {
        public static Dictionary<ItemQuality, WeaponGenertationData> GenData { get; private set; }

        static LauncherGenerationPresets()
        {
            GenData = new Dictionary<ItemQuality, WeaponGenertationData>();
            GenData.Add(ItemQuality.Common, CreateCommonLauncherData());
            GenData.Add(ItemQuality.Uncommon, CreateUncommonLauncherData());
            GenData.Add(ItemQuality.Rare, CreateRareLauncherData());
            GenData.Add(ItemQuality.Legendary, CreateLegendaryLauncherData());
        }

        static WeaponGenertationData CreateCommonLauncherData()
        {
            return new WeaponGenertationData
            {
                MinAccuracy = 46f,
                MaxAccuracy = 52f,
                MinAmmoPerMag = 2,
                MaxAmmoPerMag = 6,
                MinDamagePerRound = 8,
                MaxDamagePerRound = 11,
                MinRange = 50,
                MaxRange = 60,
                MinRateOfFire = 1f,
                MaxRateOfFire = 1.25f,
                MinRecoil = 5,
                MaxRecoil = 8
            };
        }

        static WeaponGenertationData CreateUncommonLauncherData()
        {
            return new WeaponGenertationData
            {
                MinAccuracy = 46f,
                MaxAccuracy = 52f,
                MinAmmoPerMag = 2,
                MaxAmmoPerMag = 6,
                MinDamagePerRound = 8,
                MaxDamagePerRound = 11,
                MinRange = 50,
                MaxRange = 60,
                MinRateOfFire = 1f,
                MaxRateOfFire = 1.25f,
                MinRecoil = 5,
                MaxRecoil = 8
            };
        }

        static WeaponGenertationData CreateRareLauncherData()
        {

            return new WeaponGenertationData
            {
                MinAccuracy = 46f,
                MaxAccuracy = 52f,
                MinAmmoPerMag = 2,
                MaxAmmoPerMag = 6,
                MinDamagePerRound = 8,
                MaxDamagePerRound = 11,
                MinRange = 50,
                MaxRange = 60,
                MinRateOfFire = 1f,
                MaxRateOfFire = 1.25f,
                MinRecoil = 5,
                MaxRecoil = 8
            };
        }

        static WeaponGenertationData CreateLegendaryLauncherData()
        {
            return new WeaponGenertationData
            {
                MinAccuracy = 46f,
                MaxAccuracy = 52f,
                MinAmmoPerMag = 2,
                MaxAmmoPerMag = 6,
                MinDamagePerRound = 8,
                MaxDamagePerRound = 11,
                MinRange = 50,
                MaxRange = 60,
                MinRateOfFire = 1f,
                MaxRateOfFire = 1.25f,
                MinRecoil = 5,
                MaxRecoil = 8
            };
        }
    }
}
