using project_euler.Maths;
using project_euler.Maths.Primes;

namespace project_euler.Problems.Problem007
{
    internal class Problem007 : BaseProblem, IProblem
    {
        public string Description => "Simple brute force solution";

        public string Solve()
        {
            return FindPrimeNumberN(10001).ToString();
        }

        private static long FindPrimeNumberN(int n)
        {
            var primeCalc = new ListOfPrimes();
            int i = n*10;
            var  primes = primeCalc.GeneratePrimesBelow(i);
            while (primes.Count < n)
            {
                i*=10;
                primes = primeCalc.GeneratePrimesBelow(i);
            }
            return primes[n-1];
        }
    }
}
