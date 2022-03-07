namespace project_euler.Problems.Problem0005
{
    internal class Problem0006a : BaseProblem, IProblem
    {
        public string Description => "Simple brute force solution";

        public string Solve()
        {
            return FindSumOfSquareDifference(100).ToString();
        }

        private static long FindSumOfSquareDifference(int n)
        {
            var sumOfSquares = 0;
            for (int i = 1; i <= n; i++)
            {
                sumOfSquares += i * i;
            }
            var sum = n * (n + 1) / 2;
            var squaredSum = sum * sum;
            return squaredSum- sumOfSquares;
        }
    }
}
