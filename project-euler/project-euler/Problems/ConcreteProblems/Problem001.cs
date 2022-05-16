namespace project_euler.Problems.ConcreteProblems
{
    internal class Problem001 : BaseProblem, IProblem
    {
        public string Solve()
        {
            return SumMultiplesUnder(1000).ToString();
        }

        private static int SumMultiplesUnder(int limit)
        {
            int sum = 0;
            for (int i = 0; i < limit; i++)
            {
                if (i % 3 == 0 || i % 5 == 0)
                {
                    sum += i;
                }
            }
            return sum;
        }
    }
}
