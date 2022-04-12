using project_euler.Maths.Primes.Generation;

namespace project_euler.Problems.ConcreteProblems
{
    internal class Problem007 : BaseProblem, IProblem
    {
        public string Solve()
        {
            return FindPrimeNumberN(10001).ToString();
        }

        private static long FindPrimeNumberN(int n)
        {
            var primeCalc = ListOfPrimes.Construct();
            int i = n * 10;
            var primes = primeCalc.GetPrimesBelow(i);
            while (primes.Count < n)
            {
                i *= 10;
                primes = primeCalc.GetPrimesBelow(i);
            }
            return primes.ToList()[n - 1];
        }
    }
}
