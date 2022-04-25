using System.Numerics;

namespace project_euler.Problems.ConcreteProblems
{
    internal class Problem029 : BaseProblem, IProblem
    {
        public string Solve()
        {
            return FindDistinctPowers().ToString();
        }
        
        //Notes:
        //Could use that a^b has mostly same powers as (a^2)^b but the naive approach is fine
        private static double FindDistinctPowers()
        {
            var set = new HashSet<BigInteger>();
            for (int a = 2; a <= 100; a++)
            {
                for (int b = 2; b <= 100; b++)
                {
                    set.Add(BigInteger.Pow(a, b));
                }
            }
            return set.Count;
        }
    }
}
