using project_euler.Maths;

namespace project_euler.Problems.Problem0005
{
    internal class Problem0007a : BaseProblem, IProblem
    {
        public string Description => "Simple brute force solution";

        public string Solve()
        {
            return FindPrimeNumberN(10001).ToString();
        }

        private static long FindPrimeNumberN(int n)
        {
            var primeCalc = new Primes();
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
