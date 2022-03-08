using project_euler.Maths;

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
            var primes = new Primes();
            var _ = primes.GeneratePrimesBelow(input+1);
            var smallestMultiple = new PrimeFactorization();
            for (int i = 1; i <= input; i++)
            {
                var primeFactors = primes.FindPrimeFactors(i);
                smallestMultiple = Primes.SmallestCommonMultiple(smallestMultiple, primeFactors);
            }
            return smallestMultiple.Product();
        }
    }
}
