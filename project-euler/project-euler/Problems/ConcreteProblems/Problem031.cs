namespace project_euler.Problems.ConcreteProblems
{
    internal class Problem031 : BaseProblem, IProblem
    {
        private static readonly Dictionary<int, int> powerDict = new();
        public string Solve()
        {
            return CountCoinCombinations().ToString();
        }

        //Notes:
        //Brute force approach for now
        private static int CountCoinCombinations()
        {
            var count = 2; //1 £2 and 2 £1's to start off
            //Coins a through e are £1 to p1.
            for (int a = 0; a <= 1; a++) //£1
            {
                for (int b = 0; b <= 4; b++) //£0.5
                {
                    var ab = (b * 50) + (a * 100);
                    if (ab >= 200)
                    {
                        if (ab == 200)
                        {
                            count++;
                        }
                        break;
                    }
                    for (int c = 0; c <= 10; c++) //£0.2
                    {
                        var abc = ab + (c * 20);
                        if (abc >= 200)
                        {
                            if (abc == 200)
                            {
                                count++;
                            }
                            break;
                        }
                        for (int d = 0; d <= 20; d++)  //£0.1
                        {
                            var abcd = abc + (d * 10);
                            if (abcd >= 200)
                            {
                                if (abcd == 200)
                                {
                                    count++;
                                }
                                break;
                            }
                            for (int e = 0; e <= 40; e++) //£0.05
                            {
                                var abcde = abcd + (e * 5);
                                if (abcde >= 200)
                                {
                                    if (abcde == 200)
                                    {
                                        count++;
                                    }
                                    break;
                                }
                                for (int f = 0; f <= 100; f++) //£0.02
                                {
                                    var abcdef = abcde + (f * 2);
                                    if (abcdef > 200)
                                    {
                                        break;
                                    }
                                    count++; //Since abcdef<=200, we can add (200-abcdef) 1 pence coins and have a solution
                                }
                            }
                        }
                    }
                }
            }
            return count;
        }
    }
}
