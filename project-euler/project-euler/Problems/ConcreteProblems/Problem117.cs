namespace project_euler.Problems.ConcreteProblems
{
    internal class Problem117 : BaseProblem, IProblem
    {
        public string Solve()
        {
            return FindCombinations().ToString();
        }

        private static Int64 FindCombinations()
        {
            const int minRedSequence = 2;
            const int minGreenSequence = 3;
            const int minBlueSequence = 4;
            Int64 pathsToZeroColoureds = 1;
            var pathsToState = new Int64[3][];
            pathsToState[0] = new Int64[minRedSequence]; //pathsToState[1][x] denotes x+1 running reds in current state
            pathsToState[1] = new Int64[minGreenSequence]; //pathsToState[1][x] denotes x+1 running greens in current state
            pathsToState[2] = new Int64[minBlueSequence];
            for (int i = 0; i < 50; i++)
            {
                //Only grey and maxed coloured sequences can lead to grey or colour.
                var pathsToGreyOrColoured = pathsToZeroColoureds + pathsToState[0][minRedSequence-1]+ pathsToState[1][minGreenSequence-1]+ pathsToState[2][minBlueSequence-1];
                for (int x = minRedSequence-1; x > 0; x--)
                {
                    pathsToState[0][x] = pathsToState[0][x - 1];
                }
                for (int x = minGreenSequence-1; x > 0; x--)
                {
                    pathsToState[1][x] = pathsToState[1][x - 1];
                }
                for (int x = minBlueSequence-1; x > 0; x--)
                {
                    pathsToState[2][x] = pathsToState[2][x - 1];
                }
                pathsToState[0][0] = pathsToGreyOrColoured;
                pathsToState[1][0] = pathsToGreyOrColoured;
                pathsToState[2][0] = pathsToGreyOrColoured;
                pathsToZeroColoureds = pathsToGreyOrColoured;
            }
            return pathsToZeroColoureds + pathsToState[0][minRedSequence-1]
                + pathsToState[1][minGreenSequence-1]
                + pathsToState[2][minBlueSequence-1];
        }
    }
}
