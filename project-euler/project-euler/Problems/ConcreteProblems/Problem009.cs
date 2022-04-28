namespace project_euler.Problems.ConcreteProblems
{
    internal class Problem009 : BaseProblem, IProblem
    {
        public string Solve()
        {
            return FindTripletsWithSum(1000).ToString();
        }

        private static int FindTripletsWithSum(int sum)
        {
            //sum=c+b+a<3c
            var cLimitLow = sum / 3;
            for (int c = cLimitLow; c < sum; c++)
            {
                //a=sum-b-c>sum-2c
                var aLimitLow = Math.Max(1, sum - (2 * c));
                //a=sum-b-c<sum-a-c => 2a<sum-c => a<(sum-c)/2
                var aLimitHigh = Math.Min(c, (sum - c) / 2);

                for (int a = aLimitLow; a < aLimitHigh; a++)
                {
                    var b = sum - a - c;
                    if ((a * a) + (b * b) == c * c)
                    {
                        return a * b * c;
                    }
                }
            }
            return default;
        }
    }
}
