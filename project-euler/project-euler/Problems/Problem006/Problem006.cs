namespace project_euler.Problems.Problem005
{
    internal class Problem006 : BaseProblem, IProblem
    {
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
            return squaredSum - sumOfSquares;
        }
    }
}
