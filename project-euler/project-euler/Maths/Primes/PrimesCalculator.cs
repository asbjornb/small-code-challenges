using project_euler.Maths.NumberTheory;

namespace project_euler.Maths.Primes
{
    internal static class PrimesCalculator
    {
        public static PrimeFactorization FindPrimeFactors(int num)
        {
            var primeGenerator = ListOfPrimes.Construct();
            var primes = primeGenerator.GetPrimesBelow(num + 1);

            var rest = num;
            int index = 0;
            var primeFactors = new PrimeFactorization();
            while(primes[index] <= rest)
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
