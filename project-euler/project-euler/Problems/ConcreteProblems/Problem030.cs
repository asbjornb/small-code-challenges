namespace project_euler.Problems.ConcreteProblems
{
    internal class Problem030 : BaseProblem, IProblem
    {
        public string Solve()
        {
            var powerDict = CreateDict();
            return FindDigitFifthPowers(powerDict).ToString();
        }

        //Notes:
        //All permutations have same digit sum so should only be checked once - 6 forloops to 10.
        private static int[] CreateDict()
        {
            var powerDict = new int[10];
            for (int i = 0; i < 10; i++)
            {
                powerDict[i]=(int)Math.Pow(i, 5);
            }
            return powerDict;
        }

        private static int FindDigitFifthPowers(int[] powerDict)
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
                                    var fifthPowerDigitSum = powerDict[a]
                                        + powerDict[b]
                                        + powerDict[c]
                                        + powerDict[d]
                                        + powerDict[e]
                                        + powerDict[f];
                                    //See if fifthpowerdigitsum has same digits as a,b,...f
                                    //Remember to account for prefixed 0's
                                    var toCompare = new List<int> { a, b, c, d, e, f };
                                    var isFifthPowerDigitSum = true;
                                    var remainder = fifthPowerDigitSum;
                                    for (int i = 100000; i >= 1; i /= 10)
                                    {
                                        var digit = remainder/i;
                                        if (!toCompare.Remove(digit))
                                        {
                                            isFifthPowerDigitSum = false;
                                            break;
                                        }
                                        remainder -= digit * i;
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
