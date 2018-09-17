using System.Collections.Generic;
using Code.Enums;

namespace Code.Generators.Weapons
{
    static class MinigunGenerationPresets
    {
        public static Dictionary<ItemQuality, WeaponGenertationData> GenData { get; private set; }

        static MinigunGenerationPresets()
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
                MinAccuracy = 35f,
                MaxAccuracy = 40f,
                MinAmmoPerMag = 150,
                MaxAmmoPerMag = 250,
                MinDamagePerRound = 2,
                MaxDamagePerRound = 3,
                MinRange = 30,
                MaxRange = 40,
                MinRateOfFire = 0.05f,
                MaxRateOfFire = 0.08f,
                MinRecoil = 3,
                MaxRecoil = 6
            };
        }

        static WeaponGenertationData CreateUncommonRifleData()
        {
            return new WeaponGenertationData
            {
                MinAccuracy = 35f,
                MaxAccuracy = 40f,
                MinAmmoPerMag = 150,
                MaxAmmoPerMag = 250,
                MinDamagePerRound = 2,
                MaxDamagePerRound = 3,
                MinRange = 30,
                MaxRange = 40,
                MinRateOfFire = 0.1f,
                MaxRateOfFire = 0.12f,
                MinRecoil = 3,
                MaxRecoil = 6
            };
        }

        static WeaponGenertationData CreateRareRifleData()
        {

            return new WeaponGenertationData
            {
                MinAccuracy = 35f,
                MaxAccuracy = 40f,
                MinAmmoPerMag = 150,
                MaxAmmoPerMag = 250,
                MinDamagePerRound = 2,
                MaxDamagePerRound = 3,
                MinRange = 30,
                MaxRange = 40,
                MinRateOfFire = 0.1f,
                MaxRateOfFire = 0.12f,
                MinRecoil = 3,
                MaxRecoil = 6
            };
        }

        static WeaponGenertationData CreateLegendaryRifleData()
        {
            return new WeaponGenertationData
            {
                MinAccuracy = 35f,
                MaxAccuracy = 40f,
                MinAmmoPerMag = 150,
                MaxAmmoPerMag = 250,
                MinDamagePerRound = 2,
                MaxDamagePerRound = 3,
                MinRange = 30,
                MaxRange = 40,
                MinRateOfFire = 0.1f,
                MaxRateOfFire = 0.12f,
                MinRecoil = 3,
                MaxRecoil = 6
            };
        }
    }
}
