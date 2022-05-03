using project_euler.Maths.Primes;
using project_euler.Maths.Primes.Generation;
using project_euler.Util;

namespace project_euler.Problems.ConcreteProblems
{
    internal class Problem035 : BaseProblem, IProblem
    {
        public string Solve()
        {
            return CountCircularPrimes().ToString();
        }

        private static int CountCircularPrimes()
        {
            //Can it be done faster by not rechecking cycles? Remove the rotations from set and up count?
            var count = 0;
            foreach (var prime in ListOfPrimes.GetPrimesBelow(1000000))
            {
                if (IsCircularPrime(prime))
                {
                    count++;
                }
            }
            return count;
        }

        private static bool IsCircularPrime(int candidate)
        {
            var digits = Digits.GetDigits(candidate);
            if(digits.Count>1 && HasOutlawed(digits)) // Short circuit for numbers known not to be circular primes
            {
                return false;
            }
            foreach (var rotation in GetRotations(digits))
            {
                if (!PrimesCalculator.IsPrime(Digits.ToNum(rotation)))
                {
                    return false;
                }
            }
            return true;
        }

        // If the prime contains a 2, 4, 5, 6, 8, or 0 then there will be a rotation ending in that digit.
        // Numbers ending in 5 are devisible by 5, even numbers are divisible by 2.
        private static bool HasOutlawed(List<int> digits)
        {
            foreach(var digit in digits)
            {
                if (digit == 0
                    || digit == 2
                    || digit == 4
                    || digit == 5
                    || digit == 6
                    || digit == 8)
                {
                    return true;
                }
            }
            return false;
        }

        private static IEnumerable<IEnumerable<int>> GetRotations(List<int> digits)
        {
            IEnumerable<int> next = digits;
            for (int i = 0; i < digits.Count-1; i++)
            {
                next = next.Skip(1).Concat(next.Take(1));
                yield return next;
            }
        }
    }
}
