using project_euler.Maths.Primes;

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
            var index = 2;
            while (true)
            {
                index++;
                var triangleNumber = index*(index+1)/2;
                var numDivisors = 0;
                if (index % 2 == 0)
                {
                    var factors = PrimesCalculator.FindPrimeFactors(index/2);
                    factors.Add(PrimesCalculator.FindPrimeFactors(index + 1));
                    numDivisors = NumDivisors(factors);
                }
                else
                {
                    var factors = PrimesCalculator.FindPrimeFactors(index);
                    factors.Add(PrimesCalculator.FindPrimeFactors((index + 1) / 2));
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
