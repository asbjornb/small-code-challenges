using project_euler.Maths.NumberTheory;
using project_euler.Maths.Primes;
using project_euler.Maths.Primes.Generation;

namespace project_euler.Problems.ConcreteProblems
{
    internal class Problem005 : BaseProblem, IProblem
    {
        public string Solve()
        {
            return FindSmallestMultiple(20).ToString();
        }

        private static long FindSmallestMultiple(int input)
        {
            ListOfPrimes.BuildUpTo(input); //Make sure we have the primes up to the input so we don't regen for each iteration
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
