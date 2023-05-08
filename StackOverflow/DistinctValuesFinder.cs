using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace StackOverflow
{
    public static class DistinctValuesFinder
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static IList<int> FindDistinctValuesLazy(int[][] arrays)
        {
            var distincts = GetDistinctValuesLazy(arrays);

            var result = distincts.ToList();

            return result;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static IList<int> FindDistinctValuesEager(int[][] arrays)
        {
            var distincts = GetDistinctValuesEager(arrays);

            var result = distincts.ToList();

            return result;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static IList<int> FindDistinctValuesSplit(int[][] arrays)
        {
            var distincts = GetDistinctValues_Split(arrays);

            var result = distincts.ToList();

            return result;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static IList<int> FindDistinctValuesWithoutLinq(int[][] arrays)
        {
            var distincts = _WithoutLinq(arrays);

            var result = distincts.ToList();

            return result;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static IEnumerable<int> _WithoutLinq(int[][] arrays)
        {
            HashSet<int> hashSet = new HashSet<int>();

            for (int i = 0; i < arrays.Length; i++)
            {
                for (int j = 0; j < arrays[i].Length; j++)
                {
                    if (hashSet.Contains(arrays[i][j]) == false)
                    {
                        hashSet.Add(arrays[i][j]);
                    }
                }
            }

            var result = hashSet.ToList();
            return result;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static IEnumerable<int> GetDistinctValuesUnionOnly(int[][] arrays)
        {
            var distincted = new List<int>().AsEnumerable();

            foreach (var a in arrays)
            {
                distincted = distincted.Union(a);
            }

            return distincted;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static IEnumerable<int> GetDistinctValuesLazy(int[][] arrays)
        {
            var distincted = new List<int>().AsEnumerable();

            foreach (var a in arrays)
            {
                distincted = distincted.Union(a).Distinct();
            }

            return distincted;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static IEnumerable<int> GetDistinctValuesEager(int[][] arrays)
        {
            var distincted = new List<int>().AsEnumerable();

            foreach (var a in arrays)
            {
                distincted = distincted.Union(a).Distinct().ToList();
            }

            return distincted;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static IEnumerable<int> GetDistinctValues_Split(int[][] arrays)
        {
            var distincted = new List<int>().AsEnumerable();

            int i = 0;

            foreach (var a in arrays)
            {
                ++i;

                if (i % 1000 == 0)
                {
                    distincted = distincted.Union(a).Distinct().ToList();
                }
                else
                {
                    distincted = distincted.Union(a).Distinct();
                }
            }

            return distincted;
        }

    }
}