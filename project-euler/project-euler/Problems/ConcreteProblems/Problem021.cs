using project_euler.Maths.NumberTheory;

namespace project_euler.Problems.ConcreteProblems
{
    internal class Problem021 : BaseProblem, IProblem
    {
        public string Solve()
        {
            return FindAmicableNumbersBelow(10000).ToString();
        }

        private static int FindAmicableNumbersBelow(int limit)
        {
            var divisorSums = NumberTheoryCalculator.ProperDivisorSumsBelow(limit+1);

            var pairs = 0;
            for (int a = 0; a < limit; a++)
            {
                var b = divisorSums[a]; // d(a) = b
                if (a != b
                    && b <= limit // a below limit from forloop condition
                    && a == divisorSums[b]) // d(b) = a
                {
                    pairs += a;
                }
            }
            return pairs;
        }
    }
}
