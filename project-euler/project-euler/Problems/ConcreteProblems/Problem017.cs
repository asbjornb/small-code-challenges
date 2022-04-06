using project_euler.Problems.ConcreteProblems.Problem017Model;

namespace project_euler.Problems.ConcreteProblems
{
    internal class Problem017 : BaseProblem, IProblem
    {
        public string Solve()
        {
            var letterCounter = new NumberLetterCounter();
            var result = 0;
            for (int i = 1; i <= 1000; i++)
            {
                result += letterCounter.Convert(i);
            }
            return result.ToString();
        }
    }
}
