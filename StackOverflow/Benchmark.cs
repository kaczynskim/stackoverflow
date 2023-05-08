using BenchmarkDotNet.Attributes;

namespace StackOverflow
{
    [MemoryDiagnoser]
    public class Benchmark
    {
        int[][] a;

        [GlobalSetup]
        public void GlobalSetup()
        {
            a = DataInitializer.GetValues(20_000);
        }

        [Benchmark]
        public void Eager()
        {
            DistinctValuesFinder.FindDistinctValuesEager(a);
        }

        [Benchmark]
        public void Split()
        {
            DistinctValuesFinder.FindDistinctValuesSplit(a);
        }

        [Benchmark]
        public void WithoutLinq()
        {
            DistinctValuesFinder.FindDistinctValuesWithoutLinq(a);
        }

        [Benchmark(Baseline = true)]
        public void OnlyUnion()
        {
            DistinctValuesFinder.GetDistinctValuesUnionOnly(a);
        }
    }
}
