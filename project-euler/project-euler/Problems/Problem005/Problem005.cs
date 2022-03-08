using project_euler.Maths.NumberTheory;
using project_euler.Maths.Primes;

namespace project_euler.Problems.Problem005
{
    internal class Problem005 : BaseProblem, IProblem
    {
        public string Description => "Simple brute force solution";

        public string Solve()
        {
            return FindSmallestMultiple(20).ToString();
        }

        private static long FindSmallestMultiple(int input)
        {
            var primes = ListOfPrimes.Construct();
            var _ = primes.GetPrimesBelow(input+1);
            var smallestMultiple = new PrimeFactorization();
            for (int i = 2; i <= input; i++)
            {
                var primeFactors = PrimesCalculator.FindPrimeFactors(i);
                smallestMultiple = NumberTheoryCalculator.SmallestCommonMultiple(smallestMultiple, primeFactors);
            }
            return smallestMultiple.Product();
        }
    }
}
