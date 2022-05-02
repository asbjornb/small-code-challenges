using project_euler.Maths.Permutations;
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
            foreach (var rotation in GetRotations(candidate))
            {
                if (!PrimesCalculator.IsPrime(Digits.ToNum(rotation)))
                {
                    return false;
                }
            }
            return true;
        }

        private static IEnumerable<IEnumerable<int>> GetRotations(int candidate)
        {
            var digits = Digits.GetDigits(candidate);
            IEnumerable<int> next = digits;
            for (int i = 0; i < digits.Count-1; i++)
            {
                next = next.Skip(1).Concat(new List<int> { digits[0] });
                yield return next;
            }
        }
    }
}
