namespace project_euler.Problems.ConcreteProblems
{
    internal class Problem116 : BaseProblem, IProblem
    {
        public string Solve()
        {
            return FindCombinations().ToString();
        }

        //See #114 for idea
        private static long FindCombinations()
        {
            const int minRedSequence = 2;
            const int minGreenSequence = 3;
            const int minBlueSequence = 4;
            var redPathsToState = new long[minRedSequence + 1];
            var greenPathsToState = new long[minGreenSequence + 1];
            var bluePathsToState = new long[minBlueSequence + 1];
            redPathsToState[0] = 1;
            greenPathsToState[0] = 1;
            bluePathsToState[0] = 1;
            for (int i = 0; i < 50; i++)
            {
                var redStateZeroes = redPathsToState[0] + redPathsToState[minRedSequence];
                var greenStateZeroes = greenPathsToState[0] + greenPathsToState[minGreenSequence];
                var blueStateZeroes = bluePathsToState[0] + bluePathsToState[minBlueSequence];
                var redStateOnes = redPathsToState[0] + redPathsToState[minRedSequence];
                var greenStateOnes = greenPathsToState[0] + greenPathsToState[minGreenSequence];
                var blueStateOnes = bluePathsToState[0] + bluePathsToState[minBlueSequence];
                for (int x = minRedSequence; x > 1; x--)
                {
                    redPathsToState[x] = redPathsToState[x - 1];
                }
                for (int x = minGreenSequence; x > 1; x--)
                {
                    greenPathsToState[x] = greenPathsToState[x - 1];
                }
                for (int x = minBlueSequence; x > 1; x--)
                {
                    bluePathsToState[x] = bluePathsToState[x - 1];
                }
                redPathsToState[0] = redStateZeroes;
                greenPathsToState[0] = greenStateZeroes;
                bluePathsToState[0] = blueStateZeroes;
                redPathsToState[1] = redStateOnes;
                greenPathsToState[1] = greenStateOnes;
                bluePathsToState[1] = blueStateOnes;
            }
            return redPathsToState[0] - 1 + redPathsToState[minRedSequence]
                + (greenPathsToState[0] - 1 + greenPathsToState[minGreenSequence])
                + (bluePathsToState[0] - 1 + bluePathsToState[minBlueSequence]);
        }
    }
}
