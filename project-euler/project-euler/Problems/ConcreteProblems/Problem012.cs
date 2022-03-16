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
                var numDivisors = 0;
                if (index % 2 == 0)
                {
                    var factors = cache.Get(index/2);
                    factors = factors.Add(cache.Get(index + 1));
                    numDivisors = NumDivisors(factors);
                }
                else
                {
                    var factors = cache.Get(index);
                    factors = factors.Add(cache.Get((index + 1) / 2));
                    numDivisors = NumDivisors(factors);
                }
                if (numDivisors >= 500) { return triangleNumber; }
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
