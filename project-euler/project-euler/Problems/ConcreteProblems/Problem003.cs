namespace project_euler.Problems.ConcreteProblems
{
    internal class Problem003 : BaseProblem, IProblem
    {
        public string Solve()
        {
            return FindLargestFactor(600851475143).ToString();
        }

        private static int FindLargestFactor(long number)
        {
            int largestFactor = 0;
            var rest = number;
            for (var current = 2; rest > 1; current++)
            {
                while (rest % current == 0)
                {
                    rest /= current;
                    largestFactor = current;
                }
                if (current > 2) 
                {
                    current++; //After 2 is checked, we can skip even numbers
                }
            }
            return largestFactor;
        }
    }
}
