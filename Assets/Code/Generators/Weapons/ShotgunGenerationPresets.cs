using System.Collections.Generic;
using Code.Enums;

namespace Code.Generators.Weapons
{
    static class ShotgunGenerationPresets
    {
        public static Dictionary<ItemQuality, WeaponGenertationData> GenData { get; private set; }

        static ShotgunGenerationPresets()
        {
            GenData = new Dictionary<ItemQuality, WeaponGenertationData>();
            GenData.Add(ItemQuality.Common, CreateCommonRifleData());
            GenData.Add(ItemQuality.Uncommon, CreateUncommonRifleData());
            GenData.Add(ItemQuality.Rare, CreateRareRifleData());
            GenData.Add(ItemQuality.Legendary, CreateLegendaryRifleData());
        }

        static WeaponGenertationData CreateCommonRifleData()
        {
            return new WeaponGenertationData
            {
                MinAccuracy = 20f,
                MaxAccuracy = 25f,
                MinAmmoPerMag = 2,
                MaxAmmoPerMag = 8,
                MinDamagePerRound = 2,
                MaxDamagePerRound = 3,
                MinRange = 30,
                MaxRange = 40,
                MinRateOfFire = 0.5f,
                MaxRateOfFire = 0.55f,
                MinRecoil = 9,
                MaxRecoil = 12
            };
        }

        static WeaponGenertationData CreateUncommonRifleData()
        {
            return new WeaponGenertationData
            {
                MinAccuracy = 30f,
                MaxAccuracy = 35f,
                MinAmmoPerMag = 2,
                MaxAmmoPerMag = 8,
                MinDamagePerRound = 2,
                MaxDamagePerRound = 3,
                MinRange = 30,
                MaxRange = 40,
                MinRateOfFire = 0.5f,
                MaxRateOfFire = 0.55f,
                MinRecoil = 9,
                MaxRecoil = 12
            };
        }

        static WeaponGenertationData CreateRareRifleData()
        {

            return new WeaponGenertationData
            {
                MinAccuracy = 30f,
                MaxAccuracy = 35f,
                MinAmmoPerMag = 2,
                MaxAmmoPerMag = 8,
                MinDamagePerRound = 2,
                MaxDamagePerRound = 3,
                MinRange = 30,
                MaxRange = 40,
                MinRateOfFire = 0.5f,
                MaxRateOfFire = 0.55f,
                MinRecoil = 9,
                MaxRecoil = 12
            };
        }

        static WeaponGenertationData CreateLegendaryRifleData()
        {
            return new WeaponGenertationData
            {
                MinAccuracy = 30f,
                MaxAccuracy = 35f,
                MinAmmoPerMag = 2,
                MaxAmmoPerMag = 8,
                MinDamagePerRound = 2,
                MaxDamagePerRound = 3,
                MinRange = 30,
                MaxRange = 40,
                MinRateOfFire = 0.5f,
                MaxRateOfFire = 0.55f,
                MinRecoil = 9,
                MaxRecoil = 12
            };
        }
    }
}
