using project_euler.Maths.Primes;
using project_euler.Maths.Primes.Generation;
using project_euler.Util;

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
            // Why are there only 11? First and last digit must be prime and last can't be 2 or 5 if num>100
            // So last digit must be 3 og 7 for p>100
            // Same with first 2 and last 2 so last two must be 37, 
            // Proof might be by looking at left-truncateable and right-truncateable primes separately
            // Then each one can only be created by adding a single digit to an existing
            // When no more can be made check the overlap
            var sum = 0;
            var count = 0;
            foreach (var prime in ListOfPrimes.GetPrimesBelow(1000000))
            {
                if (prime < 10)
                {
                    continue;
                }
                var digits = Digits.GetDigits(prime);
                if (IsTruncatablePrime(digits))
                {
                    count++;
                    sum += prime;
                    Console.WriteLine(prime);
                }
                if (count == 11)
                {
                    break;
                }
            }
            return sum;
        }

        private static bool IsTruncatablePrime(List<int> digits)
        {
            for (int i = 1; i < digits.Count; i++)
            {
                var num = Digits.ToNum(digits.GetRange(i, digits.Count - i));
                if (!PrimesCalculator.IsPrime(num))
                {
                    return false;
                }
            }
            for (int i = digits.Count-1; i > 0; i--)
            {
                var num = Digits.ToNum(digits.GetRange(0, i));
                if (!PrimesCalculator.IsPrime(num))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
