namespace project_euler.Problems.ConcreteProblems
{
    internal class Problem026 : BaseProblem, IProblem
    {
        public string Solve()
        {
            return FindLargestRecurring().ToString();
        }

        private static int FindLargestRecurring()
        {
            var maxRecursionLength = 6; //Example of 7 from the problem description
            var maxRecursionCandidate = 7;
            for (int i = 999; i > 1; i--)
            {
                var recursionLength = GetRecursionLength(i);
                if (recursionLength > maxRecursionLength)
                {
                    maxRecursionLength = recursionLength;
                    maxRecursionCandidate = i;
                }
                //Division by i has at most i-1 non-zero remainders so doing long division must cycle before that.
                if(maxRecursionLength>=i)
                {
                    break;
                }
            }
            return maxRecursionCandidate;
        }

        public static int GetRecursionLength(int i)
        {
            var remainders = new Dictionary<int, int>(); //Key is remainder, value is index. Faster contains than a list
            var remainder = 1;
            //Inspired by long division
            while(true)
            {
                while (remainder < i)
                {
                    remainder *= 10;
                }
                remainder %= i;
                if (remainder == 0) { return 0; }
                if (remainders.TryGetValue(remainder, out var index))
                {
                    return remainders.Count - index;
                }
                remainders.Add(remainder, remainders.Count);
            }
        }
    }
}
