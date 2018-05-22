using System.Collections.Generic;
using Code.Enums;

namespace Code.Generators.Weapons
{
    static class RifleGenerationPresets
    {
        public static Dictionary<ItemQuality, RifleGenertationData> RifleGenData { get; private set; }

        static RifleGenerationPresets()
        {
            RifleGenData = new Dictionary<ItemQuality, RifleGenertationData>();
            RifleGenData.Add(ItemQuality.Common, CreateCommonRifleData());
            RifleGenData.Add(ItemQuality.Uncommon, CreateUncommonRifleData());
            RifleGenData.Add(ItemQuality.Rare, CreateRareRifleData());
            RifleGenData.Add(ItemQuality.Legendary, CreateLegendaryRifleData());
        }

        static RifleGenertationData CreateCommonRifleData()
        {
            return new RifleGenertationData
            {
                MinAccuracy = 46f,
                MaxAccuracy = 52f,
                MinAmmoPerMag = 20,
                MaxAmmoPerMag = 25,
                MinDamagePerRound = 2,
                MaxDamagePerRound = 5,
                MinRange = 50,
                MaxRange = 60,
                MinRateOfFire = 0.2f,
                MaxRateOfFire = 0.25f,
                MinRecoil = 5,
                MaxRecoil = 8
            };
        }

        static RifleGenertationData CreateUncommonRifleData()
        {
            return new RifleGenertationData
            {
                MinAccuracy = 50,
                MaxAccuracy = 65f,
                MinAmmoPerMag = 20,
                MaxAmmoPerMag = 25,
                MinDamagePerRound = 4,
                MaxDamagePerRound = 6,
                MinRange = 65,
                MaxRange = 80,
                MinRateOfFire = 0.2f,
                MaxRateOfFire = 0.25f,
                MinRecoil = 3,
                MaxRecoil = 6
            };
        }

        static RifleGenertationData CreateRareRifleData()
        {

            return new RifleGenertationData
            {
                MinAccuracy = 60f,
                MaxAccuracy = 75f,
                MinAmmoPerMag = 20,
                MaxAmmoPerMag = 25,
                MinDamagePerRound = 6,
                MaxDamagePerRound = 8,
                MinRange = 70,
                MaxRange = 95,
                MinRateOfFire = 0.18f,
                MaxRateOfFire = 0.23f,
                MinRecoil = 3,
                MaxRecoil = 4
            };
        }

        static RifleGenertationData CreateLegendaryRifleData()
        {
            return new RifleGenertationData
            {
                MinAccuracy = 75f,
                MaxAccuracy = 90f,
                MinAmmoPerMag = 30,
                MaxAmmoPerMag = 35,
                MinDamagePerRound = 8,
                MaxDamagePerRound = 10,
                MinRange = 80,
                MaxRange = 120,
                MinRateOfFire = 0.15f,
                MaxRateOfFire = 0.2f,
                MinRecoil = 2,
                MaxRecoil = 3
            };
        }
    }
}
