using project_euler.Maths.Primes;

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
                var primefactors = PrimesCalculator.FindPrimeFactors(i);
                var divisorSum = DivisorSum(primefactors)-i;
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

        public static int DivisorSum(PrimeFactorization primefactors)
        {
            var result = 1;
            foreach (var (prime, exponent) in primefactors.ToDict())
            {
                var primePowers = 1;
                for (int i = 1; i <= exponent; i++)
                {
                    primePowers += Pow(prime, i);
                }
                result *= primePowers;
            }
            return result;
        }

        private static int Pow(int baseNum, int exponent)
        {
            var result = baseNum;
            for (int i = 1; i < exponent; i++)
            {
                result *= baseNum;
            }
            return result;
        }
    }
}
