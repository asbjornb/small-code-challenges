using project_euler.Maths.Primes;
using project_euler.Maths.Primes.Generation;

namespace project_euler.Problems.ConcreteProblems
{
    internal class Problem037 : BaseProblem, IProblem
    {
        public string Solve()
        {
            return SumTruncatablePrimes().ToString();
        }

        private static int SumTruncatablePrimes()
        {
            // Why are there only 11?
            // Proof might be by looking at left-truncateable and right-truncateable primes separately
            // Then each one can only be created by adding a single digit to an existing
            // When no more can be made the overlap must be all doubly truncatable primes.
            var sum = 0;
            var count = 0;
            foreach (var prime in ListOfPrimes.GetPrimesBelow(1000000))
            {
                if (prime < 10)
                {
                    continue;
                }
                if (IsTruncatablePrime(prime))
                {
                    count++;
                    sum += prime;
                }
                if (count == 11)
                {
                    break;
                }
            }
            return sum;
        }

        private static bool IsTruncatablePrime(int prime)
        {
            var remainder = prime / 10;
            while (remainder > 0)
            {
                if (!PrimesCalculator.IsPrime(remainder))
                {
                    return false;
                }
                remainder /= 10;
            }
            for (int i = 10; i < prime; i*=10)
            {
                if (!PrimesCalculator.IsPrime(prime % i))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
