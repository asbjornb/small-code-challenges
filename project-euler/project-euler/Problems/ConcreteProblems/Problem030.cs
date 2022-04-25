namespace project_euler.Problems.ConcreteProblems
{
    internal class Problem030 : BaseProblem, IProblem
    {
        private static readonly Dictionary<int, int> powerDict = new();
        public string Solve()
        {
            var powerDict = CreateDict();
            return FindDigitFifthPowers(powerDict).ToString();
        }

        //Notes:
        //All permutations have same digit sum so should only be checked once - 6 forloops to 10.
        private static Dictionary<int, int> CreateDict()
        {
            var powerDict = new Dictionary<int, int>();
            for (int i = 0; i < 10; i++)
            {
                powerDict.Add(i, (int)Math.Pow(i, 5));
            }
            return powerDict;
        }

        private static int FindDigitFifthPowers(Dictionary<int, int> powerDict)
        {
            var sum = 0;
            for (int a = 1; a < 10; a++)
            {
                for (int b = 1; b <= a; b++) //Two digits must be non-zero - otherwise it's not a sum as per the problem text.
                {
                    for (int c = 0; c <= b; c++)
                    {
                        for (int d = 0; d <= c; d++)
                        {
                            for (int e = 0; e <= d; e++)
                            {
                                for (int f = 0; f <= e; f++)
                                {
                                    //a-f are digits
                                    var fifthPowerDigitSum = powerDict.GetValueOrDefault(a, 0)
                                        + powerDict.GetValueOrDefault(b, 0)
                                        + powerDict.GetValueOrDefault(c, 0)
                                        + powerDict.GetValueOrDefault(d, 0)
                                        + powerDict.GetValueOrDefault(e, 0)
                                        + powerDict.GetValueOrDefault(f, 0);
                                    //See if fifthpowerdigitsum has same digits as a,b,...f
                                    //Remember to account for prefixed 0's
                                    var digitsInDigitSum = fifthPowerDigitSum.ToString().Select(x => x - '0').OrderByDescending(x => x).ToList();
                                    var toCompare = new List<int> { a, b, c, d, e, f };
                                    var length = fifthPowerDigitSum.ToString().Length;
                                    var isFifthPowerDigitSum = true;
                                    for (int i = 0; i < 6; i++)
                                    {
                                        if ((i < length && digitsInDigitSum[i] != toCompare[i]) || (i >= length && toCompare[i] != 0))
                                        {
                                            isFifthPowerDigitSum = false;
                                            break;
                                        }
                                    }
                                    if(isFifthPowerDigitSum)
                                    {
                                        sum += fifthPowerDigitSum;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return sum;
        }
    }
}
