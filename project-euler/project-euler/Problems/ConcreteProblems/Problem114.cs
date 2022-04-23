namespace project_euler.Problems.ConcreteProblems
{
    internal class Problem114 : BaseProblem, IProblem
    {
        public string Solve()
        {
            return CountCombinations().ToString();
        }

        private static Int64 CountCombinations()
        {
            //Traversing the length we are always in 1 of 4 states depending on the number of preceding reds.
            //With 0 or 3+ preceding reds we can make the new block red or grey.
            //With 1 or 2 preceding reds we can only make the new block red.
            var pathsToState = new Int64[4];
            pathsToState[0] = 1;
            for (int i = 0; i < 50; i++)
            {
                var stateZeroes = pathsToState[0]+pathsToState[3];
                var stateOnes = pathsToState[0];
                var stateTwos = pathsToState[1];
                var stateThrees = pathsToState[2]+ pathsToState[3];
                pathsToState[0] = stateZeroes;
                pathsToState[1] = stateOnes;
                pathsToState[2] = stateTwos;
                pathsToState[3] = stateThrees;
            }
            return pathsToState[0] + pathsToState[3];
        }
    }
}
