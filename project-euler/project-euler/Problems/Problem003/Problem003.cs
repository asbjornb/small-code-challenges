namespace project_euler.Problems.Problem003
{
    internal class Problem003 : BaseProblem, IProblem
    {
        public string Description => "Simple brute force solution";

        public string Solve()
        {
            var result = FindLargestFactor(600851475143).ToString();
            return result ?? "No solution found";
        }

        private static int? FindLargestFactor(long number)
        {
            int largestFactor = 0;
            var rest = number;
            while (true)
            {
                var next = FindSmallestFactor(rest, largestFactor);
                if (next is null)
                {
                    return largestFactor;
                }
                largestFactor = next.Value;
                rest = number / largestFactor;
            }
        }

        private static int? FindSmallestFactor(long number, int startFrom)
        {
            if (startFrom < 2)
            {
                startFrom = 2;
            }
            for (int divisor = startFrom; divisor * divisor <= number; divisor++)
            {
                if (IsDivisible(number, divisor))
                {
                    return divisor;
                }
            }
            return null;
        }

        private static bool IsDivisible(long num, int divisor)
        {
            return num % divisor == 0;
        }
    }
}
