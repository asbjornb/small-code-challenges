namespace project_euler.Problems.ConcreteProblems
{
    internal class Problem030 : BaseProblem, IProblem
    {
        private static readonly Dictionary<int, int> powerDict = new();
        public string Solve()
        {
            PopulateDict();
            return FindDigitFifthPowers().ToString();
        }

        //Notes:
        //A naive brute force approach for now. To optimize consider:
        //Also permutations have same digit sum so should only be checked once - 6 forloops to 10 should be faster.
        private void PopulateDict()
        {
            for (int i = 0; i < 10; i++)
            {
                powerDict.Add(i, (int)Math.Pow(i, 5));
            }
        }

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
            return i == asDigits.Sum(x => powerDict.GetValueOrDefault(x, 0));
        }
    }
}
