using System;
using System.Collections.Generic;

namespace StackOverflow
{
    internal static class DataInitializer
    {
        private static readonly Random r = new Random();

        public static int[][] GetValues(int n)
        {
            var size = n;
            var result = new List<int[]>(size);

            for (int j = 0; j < size; ++j)
            {
                var arrayWithRandoms = new int[10];

                for (int i = 0; i < arrayWithRandoms.Length; ++i)
                {
                    arrayWithRandoms[i] = r.Next(20);
                }

                result.Add(arrayWithRandoms);
            }

            return result.ToArray();
        }
    }
}