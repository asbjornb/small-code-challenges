using System.Numerics;

namespace project_euler.Problems.ConcreteProblems
{
    internal class Problem016 : BaseProblem, IProblem
    {
        public string Solve()
        {
            return GetDigitSumOfExponential(2, 1000).ToString();
        }

        public static int GetDigitSumOfExponential(int num, int exp)
        {
            var bigNumber = BigInteger.Pow(num, exp);
            var asString = bigNumber.ToString();
            return asString.Select(n => n - '0').Sum();
        }
    }
}
