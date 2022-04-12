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
            var index = 3;
            var primefactorization = PrimesCalculator.FindPrimeFactors(index); //Store factorization for reuse for next index
            while (true)
            {
                var triangleNumber = index * (index - 1) / 2; //Eulers formula displaced by 1
                var factorsNminusOne = primefactorization; //Store previous in temp variable
                var factorsN = primefactorization = PrimesCalculator.FindPrimeFactors(index);
                var totalFactors = factorsN.Add(factorsNminusOne);
                totalFactors.TryRemove(2); //Now holds the factors of the trianglenumber
                if (NumDivisors(totalFactors) >= divisors)
                {
                    return triangleNumber;
                }
                index++;
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
