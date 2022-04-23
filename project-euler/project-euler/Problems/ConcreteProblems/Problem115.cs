namespace project_euler.Problems.ConcreteProblems
{
    internal class Problem115 : BaseProblem, IProblem
    {
        public string Solve()
        {
            return FindMinLengthOver(1000000).ToString();
        }

        //See #114 for idea
        private static int FindMinLengthOver(int limit)
        {
            var length = 1; //
            const int minSequence = 50;
            var pathsToState = new int[minSequence + 1];
            pathsToState[0] = 1;
            while (true)
            {
                var stateZeroes = pathsToState[0] + pathsToState[minSequence];
                var stateMs = pathsToState[minSequence - 1] + pathsToState[minSequence];
                if (stateZeroes + stateMs > limit)
                {
                    return length;
                }
                for (int j = minSequence - 1; j > 0; j--)
                {
                    pathsToState[j] = pathsToState[j - 1];
                }
                pathsToState[0] = stateZeroes;
                pathsToState[minSequence] = stateMs;
                length++;
            }
        }
    }
}
