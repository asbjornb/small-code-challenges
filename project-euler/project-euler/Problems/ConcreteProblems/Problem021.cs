using project_euler.Maths.NumberTheory;

namespace project_euler.Problems.ConcreteProblems
{
    internal class Problem021 : BaseProblem, IProblem
    {
        public string Solve()
        {
            return FindAmicableNumbersBelow(10000).ToString();
        }

        private static int FindAmicableNumbersBelow(int input)
        {
            var divisorSums = new HashSet<(int,int)>(); //holds (num, DivisorSum(num)) tuples
            for (int i = 1; i <= input; i++)
            {
                var divisorSum = DivisorSum(i);
                divisorSums.Add((i, divisorSum));
            }

            var pairs = 0;
            foreach (var (num, ds) in divisorSums)
            {
                if(num!=ds && ds<=input && divisorSums.Contains((ds,num)))
                {
                    pairs += num;
                }
            }
            return pairs;
        }

        public static int DivisorSum(int num)
        {
            var result = 1;
            for(int i = 2; i*i <= num; i++)
            {
                if(num % i == 0)
                {
                    result += i;
                    if(num/i != i)
                    {
                        result += num / i;
                    }
                }
            }
            return result;
        }
    }
}
