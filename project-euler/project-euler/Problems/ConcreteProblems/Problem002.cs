namespace project_euler.Problems.ConcreteProblems
{
    internal class Problem002 : BaseProblem, IProblem
    {
        public string Solve()
        {
            return SumEvenFibonnaciNumbersUnder(4000000).ToString();
        }

        private static int SumEvenFibonnaciNumbersUnder(int limit)
        {
            int sum = 0;

            int current = 1;
            int last = 1;
            while (true)
            {
                if (current >= limit)
                {
                    return sum;
                }
                if (IsDivisible(current, 2))
                {
                    sum += current;
                }
                var temp = last;
                last = current;
                current += temp;
            }
        }

        private static bool IsDivisible(int num, int divisor)
        {
            return num % divisor == 0;
        }
    }
}
