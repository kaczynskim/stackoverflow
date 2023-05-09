
using BenchmarkDotNet.Running;
using System;
using System.Diagnostics;

namespace StackOverflow
{

    internal class Program
    {
        static void Main(string[] args)
        {
            //uncomment to run benchmark
            var summary = BenchmarkRunner.Run<Benchmark>();

            Console.ReadLine();

            //uncomment to see stackoverflow exception
            //var arrays = DataInitializer.GetValues(7_500);
            //DistinctValuesFinder.FindDistinctValuesLazy(arrays);
        }
    }
}