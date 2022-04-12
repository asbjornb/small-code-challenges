namespace project_euler.Problems.ConcreteProblems
{
    internal class Problem014 : BaseProblem, IProblem
    {
        private static readonly Dictionary<long, int> known = new() { [1] = 1 };

        public string Solve()
        {
            return LongestCollatzBelow(1000000).ToString();
        }

        //This version is actually slower than previous imperial version
        //I think it's much nicer and more intuitive so keeping it for now
        private static long LongestCollatzBelow(long limit)
        {
            var maxIterations = 0;
            var result = 0;

            for (int i = 2; i < limit; i++)
            {
                var iterations = GetIterations(i);
                if (iterations > maxIterations)
                {
                    maxIterations = iterations;
                    result = i;
                }
            }
            return result;
        }

        private static int GetIterations(long num)
        {
            if (known.TryGetValue(num, out var knownIterations))
            {
                return knownIterations;
            }
            else
            {
                return known[num] = 1 + GetIterations(GetNextCollatz(num));
            }
        }

        private static long GetNextCollatz(long current)
        {
            if (current % 2 == 0)
            {
                return current / 2;
            }
            return (current * 3) + 1;
        }
    }
}
