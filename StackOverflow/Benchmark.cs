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
            a = Program.GetValues(20_000);
        }

        [Benchmark]
        public void Eager()
        {
            Program.Eager(a);
        }

        [Benchmark]
        public void Split()
        {
            Program.Split(a);
        }

        [Benchmark]
        public void WithoutLinq()
        {
            Program.WithoutLinq(a);
        }

        [Benchmark(Baseline = true)]
        public void OnlyUnion()
        {
            Program.GetDistinctValuesUnionOnly(a);
        }
    }
}
