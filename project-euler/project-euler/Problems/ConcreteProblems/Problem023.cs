using project_euler.Maths.NumberTheory;
using System.Diagnostics;

namespace project_euler.Problems.ConcreteProblems
{
    internal class Problem023 : BaseProblem, IProblem
    {
        public string Solve()
        {
            const int limit = 28123;
            var abundantNumbers = GetAbundantBelow(limit-11);
            var sums = GetAbundantSumsBelow(abundantNumbers, limit);
            return SumNonAbundantSums(28123, sums).ToString();
        }

        private static List<int> GetAbundantBelow(int limit)
        {
            var divisorsums = NumberTheoryCalculator.ProperDivisorSumsBelow(limit);
            var result = new List<int>();
            for(int i = 12; i < limit; i++)
            {
                if (divisorsums[i] > i)
                {
                    result.Add(i);
                }
            }
            return result;
        }

        private static int SumNonAbundantSums(int limit, bool[] sums)
        {
            var result = 0;
            for (int i = 1; i < limit; i++)
            {
                if(!sums[i])
                {
                    result += i;
                }
            }
            return result;
        }

        private static bool[] GetAbundantSumsBelow(List<int> abundantNumbers, int limit)
        {
            var sums = new bool[limit+1];
            for (var i = 0; i < abundantNumbers.Count; i++)
            {
                for (var j = i; j < abundantNumbers.Count; j++)
                {
                    var sum = abundantNumbers[i] + abundantNumbers[j];
                    if (sum > limit)
                    {
                        break;
                    }
                    sums[sum]=true;
                }
            }
            return sums;
        }
    }
}
