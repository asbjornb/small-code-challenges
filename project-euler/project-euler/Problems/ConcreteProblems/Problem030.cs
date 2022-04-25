using System.Numerics;

namespace project_euler.Problems.ConcreteProblems
{
    internal class Problem030 : BaseProblem, IProblem
    {
        public string Solve()
        {
            return FindDigitFifthPowers().ToString();
        }
        
        //Notes:
        //A naive brute force approach
        private static double FindDigitFifthPowers()
        {
            var sum = 0;
            //The number is decently bounded by 10 and 9^5 * 6 = 354294
            for (int i = 10; i <= 354294; i++)
            {
                if(IsDigitFifthPower(i))
                {
                    sum += i;
                }
            }
            return sum;
        }

        private static bool IsDigitFifthPower(int i)
        {
            var asDigits = i.ToString().Select(x => x-'0');
            return i == asDigits.Sum(x => (int)Math.Pow(x, 5));
        }
    }
}
