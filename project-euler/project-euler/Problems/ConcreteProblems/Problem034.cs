namespace project_euler.Problems.ConcreteProblems
{
    internal class Problem034 : BaseProblem, IProblem
    {
        public string Solve()
        {
            return FindDigitCancellingFractions().ToString();
        }

        private static int FindDigitCancellingFractions()
        {
            //let f(x) be sum of digits of x!
            //2540160=9!*7 so upper bounds f(x)=x. For any 7 digit number d0..d6 d0<2 since f(2999999)=6*9!+2=2177282 and f(2199999)=5*9!+2=1814402
            //Note also that any permutation x' of a number x satisfies f(x)=f(x') so we only need to check permutations
            //and even 1!=0!=1 so we only need to check their sum once.
            //Naive though:
            var factorials = CreateFactorials();
            var sum = 0;
            for (int i = 3; i < 1000000; i++) //Start as 100000? Then all nums below are permutations (eg.
                                              //f(000123)=f(111123). For each digitfactorial add sum to set if between 3 and 1000000
                                              //Then sum numbers in set (count)? Nah f(111111)=6 so not curious.
            {
                if (CheckDigitFactorialSum(i, factorials))
                {
                    sum += i;
                }
            }
            return sum;
        }

        private static int[] CreateFactorials()
        {
            var factorial=1;
            var dict = new int[10];
            dict[0] = 1;
            dict[1] = 1;
            for (int i = 2; i < 10; i++)
            {
                factorial *= i;
                dict[i] = factorial;
            }
            return dict;
        }

        private static bool CheckDigitFactorialSum(int num, int[] factorials)
        {
            var sum = 0;
            var remainder = num;
            while(remainder>0)
            {
                var digit = remainder % 10;
                sum += factorials[digit];
                remainder /= 10;
            }
            return sum == num;
        }
    }
}
