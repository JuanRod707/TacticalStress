using UnityEngine;

namespace Assets.Code.Repositories
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
    }
}
