using project_euler.Maths.Primes;
using project_euler.Util;

namespace project_euler.Problems.ConcreteProblems
{
    internal class Problem012 : BaseProblem, IProblem
    {
        public string Solve()
        {
            return FindFirstTriangleWithDivisors(500).ToString();
        }

        private static int FindFirstTriangleWithDivisors(int divisors)
        {
            var cache = new DictCacheWithFunct<int, PrimeFactorization>(x => PrimesCalculator.FindPrimeFactors(x));

            var index = 2;
            while (true)
            {
                index++;
                var triangleNumber = index*(index+1)/2;
                var factors = cache.Get(index);
                factors = factors.Add(cache.Get(index + 1));
                factors.TryRemove(2);
                if (NumDivisors(factors) >= divisors) { return triangleNumber; }
            }
        }

        private static int NumDivisors(PrimeFactorization primeFactors)
        {
            var divisors = 1;
            foreach (var factor in primeFactors.ToList())
            {
                divisors *= (factor.Exponent + 1);
            }
            return divisors;
        }
    }
}
