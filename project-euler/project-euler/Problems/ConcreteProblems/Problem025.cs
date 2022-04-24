using System.Numerics;

namespace project_euler.Problems.ConcreteProblems
{
    internal class Problem025 : BaseProblem, IProblem
    {
        public string Solve()
        {
            return FindFibonacci().ToString();
        }

        private static int FindFibonacci()
        {
            var fibonacci1 = BigInteger.One;
            var fibonacci2 = BigInteger.One;
            var limit = BigInteger.Pow(10,999);
            var index = 3;
            while (true)
            {
                var fibonacciNext = fibonacci1 + fibonacci2;
                if (fibonacciNext > limit)
                {
                    return index;
                }
                fibonacci1 = fibonacci2;
                fibonacci2 = fibonacciNext;
                index++;
            }
        }
    }
}
