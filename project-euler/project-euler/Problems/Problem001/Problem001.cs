namespace project_euler.Problems.Problem001
{
    internal class Problem001 : BaseProblem, IProblem
    {
        public string Solve()
        {
            return SumMultiplesUnder(new List<int>() { 3, 5 }, 1000).ToString();
        }

        private static int SumMultiplesUnder(List<int> divisors, int limit)
        {
            int sum = 0;
            for (int i = 0; i < limit; i++)
            {
                if (IsDivisible(i, divisors))
                {
                    sum += i;
                }
            }
            return sum;
        }

        private static bool IsDivisible(int num, List<int> divisors)
        {
            foreach (var divisor in divisors)
            {
                if (IsDivisible(num, divisor))
                {
                    return true;
                }
            }
            return false;
        }

        private static bool IsDivisible(int num, int divisor)
        {
            return num % divisor == 0;
        }
    }
}
