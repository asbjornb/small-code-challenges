using System.Numerics;

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
                //Discarding first part to make sure to hold cycles - see 1/6 = 0.1666... so we need to discard the 1 before looking for cycles
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
            var remainders = new List<int>();
            var remainder = 1;
            while(remainder != 0)
            {
                while (remainder < i)
                {
                    remainder *= 10;
                }
                remainder %= i;
                if (remainder == 0) { return 0; }
                if (remainders.Contains(remainder))
                {
                    return remainders.Count - remainders.IndexOf(remainder);
                }
                remainders.Add(remainder);
            }
            return 0;
        }
    }
}
