namespace project_euler.Problems.ConcreteProblems
{
    internal class Problem115 : BaseProblem, IProblem
    {
        public string Solve()
        {
            return FindMinLengthOver(1000000).ToString();
        }

        private static int FindMinLengthOver(int v)
        {
            var length = 101; //At least two can be placed
            while (true)
            {
                if (CountCombinations(50, length) >= v)
                    return length;
                length++;
            }
        }

        //See 114 for simple example
        private static int CountCombinations(int m, int n)
        {
            //Traversing the length we are always in 1 of 4 states depending on the number of preceding reds.
            //With 0 or 3+ preceding reds we can make the new block red or grey.
            //With 1 or 2 preceding reds we can only make the new block red.
            var pathsToState = new int[m+1];
            pathsToState[0] = 1;
            for (int i = 0; i < n; i++)
            {
                var stateZeroes = pathsToState[0]+pathsToState[m];
                var stateMs = pathsToState[m-1]+ pathsToState[m];
                for (int j = m-1; j > 0; j--)
                {
                    pathsToState[j] = pathsToState[j - 1];
                }
                pathsToState[0] = stateZeroes;
                pathsToState[m] = stateMs;
            }
            return pathsToState[0] + pathsToState[m];
        }
    }
}
