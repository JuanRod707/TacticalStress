﻿using UnityEngine;
using Random = System.Random;

namespace Code.Helpers
{
    public static class RandomService
    {
        private static readonly Random random = new Random();

        public static int GetRandom(int min, int max)
        {
            return random.Next(min, max);
        }
    }
}
