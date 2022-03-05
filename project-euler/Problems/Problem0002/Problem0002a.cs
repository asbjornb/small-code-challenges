namespace project_euler.Problems.Problem0001
{
    //https://projecteuler.net/problem=1
    internal static class Problem0002a
    {
        public static int SumEvenFibonnaciNumbersUnder(int limit)
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
