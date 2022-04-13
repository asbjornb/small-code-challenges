using project_euler.Maths.NumberTheory;
using project_euler.Maths.Primes.Generation;

namespace project_euler.Maths.Primes
{
    internal static class PrimesCalculator
    {
        public static PrimeFactorization FindPrimeFactors(int num)
        {
            var primeFactors = new PrimeFactorization();
            if(num <= 1)
            {
                return primeFactors;
            }
            var primeGenerator = ListOfPrimes.Construct();
            var primes = primeGenerator.GetPrimesBelow(num + 1).ToList();

            var rest = num;
            int index = 0;
            while (primes[index] <= rest)
            {
                if (NumberTheoryCalculator.IsDivisible(rest, primes[index]))
                {
                    rest /= primes[index];
                    primeFactors.AddFactor(primes[index]);
                }
                else
                {
                    index++;
                }
            }
            return primeFactors;
        }
    }
}
