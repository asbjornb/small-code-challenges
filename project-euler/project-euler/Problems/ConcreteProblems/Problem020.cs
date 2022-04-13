using System.Numerics;

namespace project_euler.Problems.ConcreteProblems
{
    internal class Problem020 : BaseProblem, IProblem
    {
        public string Solve()
        {
            return FindLargeDigitSum().ToString();
        }

        private static int FindLargeDigitSum()
        {
            var num = BigInteger.One;
            for(int i = 2; i <= 100; i++)
            {
                num = BigInteger.Multiply(num, i);
            }
            return num.ToString().ToArray().Select(x => x - '0').Sum();
        }
    }
}
