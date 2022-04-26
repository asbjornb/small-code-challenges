using project_euler.Maths.Primes.Generation;

namespace project_euler.Maths.Primes
{
    internal static class PrimesCalculator
    {
        private const int PrimeCheckLimit = 1000000;
        private static readonly HashSet<int> Primes;

        static PrimesCalculator()
        {
            Primes = ListOfPrimes.GetHashSetPrimes(PrimeCheckLimit);
        }

        public static PrimeFactorization FindPrimeFactors(int num)
        {
            var primeFactors = new PrimeFactorization();
            if (num <= 1)
            {
                return primeFactors;
            }
            var primes = ListOfPrimes.GetPrimesBelow((int)Math.Sqrt(num) + 1);

            var rest = num;
            foreach (var prime in primes)
            {
                if (rest == 1 || rest < prime)
                {
                    break;
                }
                while (rest % prime == 0)
                {
                    rest /= prime;
                    primeFactors.AddFactor(prime);
                }
            }
            if (rest > 1)
            {
                primeFactors.AddFactor(rest);
            }
            return primeFactors;
        }

        public static bool IsPrime(int num)
        {
            if (num <= 1 || num % 2 == 0 || num % 3 == 0)
            {
                return num == 2 || num == 3;
            }
            if (num <= PrimeCheckLimit)
            {
                return Primes.Contains(num);
            }
            //the case with num > PrimeCheckLimit^2 does not occur for int with limit>500k
            else
            {
                var limit = (int)Math.Sqrt(num) + 1;

                foreach (var prime in Primes)
                {
                    if (prime > limit)
                    {
                        break;
                    }
                    if (num % prime == 0)
                    {
                        return false;
                    }
                }
                return true;
            }
        }
    }
}
