namespace project_euler.Problems.Problem0002
{
    internal class Problem0002a : BaseProblem, IProblem
    {
        public string Description => "Simple brute force solution";

        public string Solve()
        {
            return SumEvenFibonnaciNumbersUnder(4000000).ToString();
        }

        private static int SumEvenFibonnaciNumbersUnder(int limit)
        {
            int sum = 0;
            int num = 1;
            while(true)
            {
                if(num>limit)
                {
                    return sum;
                }
                if(IsDivisible(num, 2))
                {
                    sum += num;
                }
                num += num;
            }
        }

        private static bool IsDivisible(int num, int divisor)
        {
            return num % divisor == 0;
        }
    }
}
