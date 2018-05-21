namespace Code.Generators.Weapons
{
    static class RifleGenerationPresets
    {
        public static RifleGenertationData CommonRifleData
        {
            get
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
                    MinRecoil = 4,
                    MaxRecoil = 6
                };
            }
        }
    }
}
