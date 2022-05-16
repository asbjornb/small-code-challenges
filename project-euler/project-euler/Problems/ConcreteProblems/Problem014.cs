namespace project_euler.Problems.ConcreteProblems
{
    internal class Problem014 : BaseProblem, IProblem
    {
        private static readonly Dictionary<long, int> known = new(500000) { [1] = 1 };

        public string Solve()
        {
            return LongestCollatzBelow(1000000).ToString();
        }

        //This version is actually slower than previous imperial version
        //I think it's much nicer and more intuitive so keeping it for now
        private static int LongestCollatzBelow(int limit)
        {
            var maxIterations = 0;
            var result = 0;

            for (int i = limit/2; i < limit; i++) //First half of numbers are mirrorered by second half /2
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
            if(num % 2 == 0) //For even shortcut to smaller numbers
            {
                return GetIterations(num / 2) + 1;
            }
            if (known.TryGetValue(num, out var knownIterations)) //For unevens check and otherwise persist
            {
                return knownIterations;
            }
            else
            {
                //Since num is odd, so is 3*num+1, so we can always divide by 2 and take 2 steps at once
                return known[num] = GetIterations(((3 * num) + 1) / 2) + 2;
            }
        }
    }
}
