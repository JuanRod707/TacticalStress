using UnityEngine;

namespace Code.Infrastructure.Repositories
{
    public static class Repos
    {
        private static GameObject Repositories
        {
            get { return GameObject.Find("Repositories"); }
        }

        public static RiflePartsRepository RifleRepo
        {
            get { return Repositories.GetComponent<RiflePartsRepository>(); }
        }

        public static ParticleRepository ParticleRepo
        {
            get { return Repositories.GetComponent<ParticleRepository>(); }
        }

        public static WeaponRepository WeaponRepo
        {
            get { return Repositories.GetComponent<WeaponRepository>(); }
        }
    }
}
