namespace project_euler.Problems.ConcreteProblems
{
    internal class Problem009 : BaseProblem, IProblem
    {
        public string Solve()
        {
            return FindTriplets().ToString();
        }

        private static int FindTriplets()
        {
            for (int c = 1; c <= 1000; c++)
            {
                for (int b = 0; b < c; b++)
                {
                    var a = 1000 - b - c;
                    if ((a * a) + (b * b) == c * c)
                    {
                        return a*b*c;
                    }
                }
            }
            return default;
        }
    }
}
