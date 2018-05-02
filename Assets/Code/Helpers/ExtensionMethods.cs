using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Code.Helpers
{
    internal static class ExtensionMethods
    {
        public static T PickOne<T>(this IEnumerable<T> col)
        {
            return col.ToArray()[Random.Range(0, col.Count())];
        }

        public static T[] PickSome<T>(this IEnumerable<T> col, int amount)
        {
            var result = new List<T>();

            if (amount > col.Count())
            {
                return col.ToArray();
            }

            for (int i = 0; i < amount; i++)
            {
                col = col.Where(x => !result.Contains(x));
                result.Add(col.ToArray()[Random.Range(0, col.Count())]);
            }

            return result.ToArray();
        }
    }
}
