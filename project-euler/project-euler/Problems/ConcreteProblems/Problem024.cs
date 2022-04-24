namespace project_euler.Problems.ConcreteProblems
{
    internal class Problem024 : BaseProblem, IProblem
    {
        public string Solve()
        {
            return FindPermutationByNum(1000000);
        }

        private static string FindPermutationByNum(int num)
        {
            //var permutation1 = (1,"0123456789"); //Starting point
            //Places 2-10 can be rearranged in 9! ways before upping first digit
            //var x = Factorial(9);
            //var permutationx = (x+1,"1023456789");
            var digits = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var lockedDigits = "";
            var remaining = num;
            var index = 0;
            while (true)
            {
                if(digits.Count == 1)
                {
                    lockedDigits += digits[0];
                    break;
                }
                var combinationsBeforeSwappingLeadingDigit = Factorial(digits.Count - 1);
                if (combinationsBeforeSwappingLeadingDigit >= remaining)
                {
                    lockedDigits += digits[index];
                    digits.RemoveAt(index);
                    index = 0;
                }
                else
                {
                    remaining -= combinationsBeforeSwappingLeadingDigit;
                    index++;
                }
            }
            return lockedDigits;
        }

        private static int Factorial(int num)
        {
            int product = 1;
            for (int i = num; i > 1; i--)
            {
                product *= i;
            }
            return product;
        }
    }
}
