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
            //When running multiple times using the primelist would be much faster
            var primes = PrimeBuilder.BuildPrimesBelow(500000); //Number is a guess (1 in 50 numbers prime seems reasonable)
            return primes.ElementAt(n-1);
        }
    }
}
