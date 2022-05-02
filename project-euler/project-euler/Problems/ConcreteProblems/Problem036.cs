namespace project_euler.Problems.ConcreteProblems
{
    internal class Problem036 : BaseProblem, IProblem
    {
        public string Solve()
        {
            return SumDoubleBasedPalindromesBelow().ToString();
        }

        private static int SumDoubleBasedPalindromesBelow()
        {
            var sum = 0;
            //loop to 1000 instead and generate palindromes as p=i+reverse(i) and p=i+reverse(i).Skip(1)?
            for (int i = 1; i < 1000; i++)
            {
                var numBase10 = Convert.ToString(i, 10);
                string test = new string(numBase10.Reverse().ToArray());
                string palindromeString1 = (numBase10 + new string(numBase10.Reverse().ToArray()));
                var palindromeNum1 = Convert.ToInt32(palindromeString1, 10);
                var possiblePalindrome1 = Convert.ToString(palindromeNum1, 2);
                string palindromeString2 = (numBase10 + new string(numBase10.Reverse().Skip(1).ToArray()));
                var palindromeNum2 = Convert.ToInt32(palindromeString2, 10);
                var possiblePalindrome2 = Convert.ToString(palindromeNum2, 2);
                if (possiblePalindrome1.Select(x=>x).SequenceEqual(possiblePalindrome1.Reverse()))
                {
                    sum += palindromeNum1;
                }
                if (possiblePalindrome2.Select(x => x).SequenceEqual(possiblePalindrome2.Reverse()))
                {
                    sum += palindromeNum2;
                }
            }
            return sum;
        }
    }
}
