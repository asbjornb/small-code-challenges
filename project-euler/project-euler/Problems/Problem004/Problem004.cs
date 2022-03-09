namespace project_euler.Problems.Problem004
{
    internal class Problem004 : BaseProblem, IProblem
    {
        public string Description => "Simple brute force solution";

        public string Solve()
        {
            return FindLargestPalindrome(10000).ToString();
        }

        private static int FindLargestPalindrome(int limit)
        {
            for (int i = limit - 1; i > 0; i--)
            {
                //Heuristicly this works, but other palindromes eixst that are not constructed like this (e.g. 121)
                var asText = i.ToString();
                var palindrome = asText + new string(asText.Reverse().ToArray());
                var num = int.Parse(palindrome);
                if (HasThreeDigitFactors(num))
                {
                    return num;
                }
            }
            return 0;
        }

        private static bool HasThreeDigitFactors(int num)
        {
            for (int i = 100; i < 1000; i++)
            {
                if (i * i > num)
                {
                    return false;
                }
                if (IsDivisible(num, i))
                {
                    var otherFactor = num / i;
                    if (otherFactor > 99 && otherFactor < 1000)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private static bool IsDivisible(int num, int divisor)
        {
            return num % divisor == 0;
        }
    }
}
