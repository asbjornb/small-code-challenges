using project_euler.Maths.Primes.Generation;

namespace project_euler.Problems.ConcreteProblems
{
    internal class Problem010 : BaseProblem, IProblem
    {
        public string Solve()
        {
            return SumPrimesBelow(2000000).ToString();
        }

        private static long SumPrimesBelow(int limit)
        {
            var primes = ListOfPrimes.GetPrimesBelow(limit);
            var sum = 0L;
            foreach (var prime in primes)
            {
                sum += prime;
            }
            return sum;
        }
    }
}
