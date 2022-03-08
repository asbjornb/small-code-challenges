using project_euler.Maths.Primes;

namespace project_euler.Maths.NumberTheory
{
    internal static class NumberTheoryCalculator
    {
        public static PrimeFactorization SmallestCommonMultiple(PrimeFactorization p1, PrimeFactorization p2)
        {
            var firstPairs = p1.ToList();
            var secondPairs = p2.ToList();
            var result = new PrimeFactorization();
            firstPairs.ForEach(x => result.IncreaseIfLarger(x));
            secondPairs.ForEach(x => result.IncreaseIfLarger(x));
            return result;
        }

        public static bool IsDivisible(int num, int divisor)
        {
            return num % divisor == 0;
        }
    }
}
