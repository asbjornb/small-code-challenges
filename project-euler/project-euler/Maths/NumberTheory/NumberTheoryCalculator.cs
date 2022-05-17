using project_euler.Maths.Primes;

namespace project_euler.Maths.NumberTheory
{
    internal static class NumberTheoryCalculator
    {
        public static PrimeFactorization SmallestCommonMultiple(PrimeFactorization p1, PrimeFactorization p2)
        {
            var result = new PrimeFactorization();
            foreach (var factor in p1)
            {
                result.AddFactor(factor);
            }
            foreach (var factor in p2)
            {
                result.IncreaseIfLarger(factor);
            }
            return result;
        }

        public static int[] ProperDivisorSumsBelow(int limit)
        {
            var result = new int[limit];
            for (var i = 1; i < limit; i++)
            {
                for (var j = 2*i; j < limit; j+=i) //For full divisor sum just start at i instead of 2 * i
                {
                    result[j] += i; //For each multiple (j) of i, i is a divisor so add i to the divisor sum
                }
            }
            return result;
        }

        public static int ProperDivisorSum(int num)
        {
            var result = 1;
            for (int i = 2; i * i <= num; i++)
            {
                if (num % i == 0)
                {
                    result += i;
                    if (num / i != i)
                    {
                        result += num / i;
                    }
                }
            }
            return result;
        }
    }
}
