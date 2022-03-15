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
            var triangleNumber = 1;
            var index = 1;
            while (true)
            {
                index++;
                triangleNumber += index;
                if (NumDivisors(triangleNumber) >= 500) { return triangleNumber; }
            }
        }

        private static int NumDivisors(int num)
        {
            var primeFactors = PrimesCalculator.FindPrimeFactors(num).ToList();
            var divisors = 1;
            foreach (var factor in primeFactors)
            {
                divisors *= (factor.Exponent + 1);
            }
            return divisors;
        }
    }
}
