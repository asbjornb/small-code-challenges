namespace project_euler.Problems.ConcreteProblems
{
    internal class Problem015 : BaseProblem, IProblem
    {
        public string Solve()
        {
            //For each step one must go right or down
            //To complete the path one must go exactly 20 times right and 20 times down - but steps in any order
            //Any such sequence of steps complete the path
            //So this is NChooseK for n=40, k=20 => Factorial(n) / (Factorial(k) * Factorial(n - k))
            return NChoooseK(40, 20).ToString();
        }

        //For larger numbers with full precision consider BigInteger - this is much faster though
        private static double NChoooseK(int n, int k)
        {
            return Math.Round(FactorialFromTo(n, k) / Factorial(n - k));
        }

        public static double Factorial(int num)
        {
            return FactorialFromTo(num);
        }

        public static double FactorialFromTo(int from, int to = 1)
        {
            double product = 1;
            for (int i = from; i > to; i--)
            {
                product *= i;
            }
            return product;
        }
    }
}
