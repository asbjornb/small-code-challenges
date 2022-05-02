namespace project_euler.Problems.ConcreteProblems
{
    internal class Problem036 : BaseProblem, IProblem
    {
        public string Solve()
        {
            return SumDoubleBasedPalindromesBelow(1000000).ToString();
        }

        private static int SumDoubleBasedPalindromesBelow(int limit)
        {
            var sum = 0;
            //loop to 1000 instead and generate palindromes as p=i+reverse(i) and p=i+reverse(i).Skip(1)?
            for (int i = 1; i < limit; i++)
            {
                var numBase10 = Convert.ToString(i, 10);
                var numBase2 = Convert.ToString(i, 2);
                if (numBase10.Select(x=>x).SequenceEqual(numBase10.Reverse())
                    && numBase2.Select(x => x).SequenceEqual(numBase2.Reverse()))
                {
                    sum += i;
                }
            }
            return sum;
        }
    }
}
