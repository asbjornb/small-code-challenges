using project_euler.Maths.NumberTheory;

namespace project_euler.Problems.ConcreteProblems
{
    internal class Problem023 : BaseProblem, IProblem
    {
        public string Solve()
        {
            var abundantNumbers = GetAbundantBelow(28123 - 11);
            var sums = GetAbundantSums(abundantNumbers);
            return SumNonAbundantSums(28123, sums).ToString();
        }

        private static List<int> GetAbundantBelow(int limit)
        {
            var result = new List<int>();
            for(int i = 12; i < limit; i++)
            {
                if (NumberTheoryCalculator.ProperDivisorSum(i) > i)
                {
                    result.Add(i);
                }
            }
            return result;
        }

        private static int SumNonAbundantSums(int limit, HashSet<int> sums)
        {
            var result = 0;
            for (int i = 1; i < limit; i++)
            {
                if(!sums.Contains(i))
                {
                    result += i;
                }
            }
            return result;
        }

        private static HashSet<int> GetAbundantSums(List<int> abundantNumbers)
        {
            var sums = new HashSet<int>();
            for (var i = 0; i < abundantNumbers.Count; i++)
            {
                for (var j = i; j < abundantNumbers.Count; j++)
                {
                    sums.Add(abundantNumbers[i] + abundantNumbers[j]);
                }
            }
            return sums;
        }
    }
}
