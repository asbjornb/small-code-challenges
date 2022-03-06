namespace project_euler.Problems.Problem0004
{
    internal class Problem0004b : BaseProblem//, IProblem
    {
        public string Description => "Simple brute force solution";

        public string Solve()
        {
            return FindLargestPalindrome(10000).ToString();
        }

        private static int FindLargestPalindrome(int limit)
        {
            int largestPalindrome = 0;
            for (int i = 1; i < limit; i++)
            {
                Console.WriteLine(i);
                for (int j = i; j < limit; i++)
                {
                    var candidate = i * j;
                    if(candidate > largestPalindrome && IsPalindrome(candidate))
                    {
                        largestPalindrome = candidate;
                    }
                }
            }
            return largestPalindrome;
        }

        private static bool IsPalindrome(long num)
        {
            var asText = num.ToString();
            return new string(asText.Reverse().ToArray())==asText;
        }

        private static bool IsPalindromeSlow(long num)
        {
            var asText = num.ToString();
            for (int i = 0; i < asText.Length/2; i++)
            {
                if(asText[i]!=asText[asText.Length-1-i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
