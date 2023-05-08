
using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;

namespace StackOverflow
{

    internal class Program
    {
        static Random r = new Random();

        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<Benchmark>();

            Console.ReadLine();

            var arrays = GetValues(500);
            //Lazy(arrays);

            //arrays = GetValues(5000);
            //Lazy(arrays);

            //arrays = GetValues(10000);
            //Lazy(arrays);

            //arrays = GetValues(15000);
            //Lazy(arrays);

            arrays = GetValues(7_500);
           
            foreach (var distinct in GetDistinctValuesEager(arrays))
            {
                Console.WriteLine(distinct);
            }

            Console.WriteLine("---");

            foreach (var distinct in _WithoutLinq(arrays))
            {
                Console.WriteLine(distinct);
            }

            Console.WriteLine("---");

            foreach (var distinct in GetDistinctValues_Split(arrays))
            {
                Console.WriteLine(distinct);
            }

            Console.WriteLine("---");

            foreach (var distinct in GetDistinctValuesUnionOnly(arrays))
            {
                Console.WriteLine(distinct);
            }

            
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        static IList<int> Lazy(int[][] arrays)
        {
            var distincts = GetDistinctValuesLazy(arrays);

            var result = distincts.ToList();

            return result;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void Eager(int[][] arrays)
        {
            var distincts = GetDistinctValuesEager(arrays);

            var result = distincts.ToList();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void Split(int[][] arrays)
        {
            var distincts = GetDistinctValues_Split(arrays);

            var result = distincts.ToList();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void WithoutLinq(int[][] arrays)
        {
            var distincts = _WithoutLinq(arrays);

            var result = distincts.ToList();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static IEnumerable<int> _WithoutLinq(int[][] arrays)
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
        private static IEnumerable<int> GetDistinctValues(IEnumerable<int[]> arrays)
        {
            return arrays.SelectMany(array => array).Distinct();
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
        static IEnumerable<int> GetDistinctValuesLazy(int[][] arrays)
        {
            var distincted = new List<int>().AsEnumerable();

            foreach (var a in arrays)
            {
                distincted = distincted.Union(a).Distinct();
            }

            return distincted;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        static IEnumerable<int> GetDistinctValuesEager(int[][] arrays)
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

                if(i % 1000 == 0)
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