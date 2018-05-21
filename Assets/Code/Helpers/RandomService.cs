using UnityEngine;

namespace Code.Helpers
{
    public static class RandomService
    {
        public static int GetRandom(int min, int max)
        {
            return Random.Range(min, max);
        }

        public static float GetRandom(float min, float max)
        {
            return Random.Range(min, max);
        }
    }
}
