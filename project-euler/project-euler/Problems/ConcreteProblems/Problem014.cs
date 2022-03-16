namespace project_euler.Problems.ConcreteProblems
{
    internal class Problem014 : BaseProblem, IProblem
    {
        public string Solve()
        {
            return LongestCollatzBelow(1000000).ToString();
        }

        private static long LongestCollatzBelow(long limit)
        {
            Dictionary<long,long> known = new();
            known[1] = 1;
            var maxIterations = 0L;
            var mostIterations = 0L;
            
            for(long i = 2; i < limit; i++)
            {
                var iterations = 0L;
                var current = i;
                while(true)
                {
                    if (known.TryGetValue(current, out var knownIterations))
                    {
                        var iIterations = iterations + knownIterations;
                        known[i] = iIterations;
                        if (iIterations > maxIterations)
                        {
                            maxIterations = iIterations;
                            mostIterations = i;
                        }
                        break;
                    }
                    else
                    {
                        iterations++;
                        current = GetNextCollatz(current);
                    }
                }
            }
            return mostIterations;
        }

        private static long GetNextCollatz(long current)
        {
            if(current%2 == 0)
            {
                return current / 2;
            }
            return (current * 3) + 1;
        }
    }
}
