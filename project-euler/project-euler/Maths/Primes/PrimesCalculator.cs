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
            var primes = primeGenerator.GetPrimesBelow(num + 1);

            var rest = num;
            foreach (var prime in primes)
            {
                if (prime > rest)
                {
                    break;
                }
                while (rest % prime == 0)
                {
                    rest /= prime;
                    primeFactors.AddFactor(prime);
                }
            }
            return primeFactors;
        }
    }
}
