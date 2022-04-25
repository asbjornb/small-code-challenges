namespace project_euler.Problems.ConcreteProblems
{
    internal class Problem028 : BaseProblem, IProblem
    {
        public string Solve()
        {
            return FindCornerSum().ToString();
        }

        //Notes:
        //Observe that moving between corners just adds the same number to each corner and moving out a layer adds 2 to height/width.
        private static double FindCornerSum()
        {
            var cornerSum = 1d; //layer 1 has sum 1 so we start from 2
            var increment = 1;
            for (int layer = 2; layer <= 501; layer++) //layer 501 has 1001 height/width
            {
                for (int i = 0; i < 4; i++)
                {
                    increment += 2 * (layer - 1);
                    cornerSum += increment;
                }
            }
            return cornerSum;
        }
    }
}
