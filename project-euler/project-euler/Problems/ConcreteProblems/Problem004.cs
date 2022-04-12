namespace project_euler.Problems.ConcreteProblems
{
    internal class Problem004 : BaseProblem, IProblem
    {
        public string Solve()
        {
            return FindLargestPalindrome(999).ToString();
        }

        private static int FindLargestPalindrome(int limit)
        {
            //Limit is based on 999*999 as largest candidate for factor of 3-digit numbers
            for (int i = limit; i > 0; i--)
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
            //i,j>99 && i,j<1000 && i*j=num
            for (int i = 999; i > 99; i--)
            {
                if (IsDivisible(num, i))
                {
                    var otherFactor = num / i;
                    if (otherFactor > 999) //Further loops with smaller i's will continue to have otherFactor>999
                    {
                        return false;
                    }
                    if (otherFactor > 99)
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
