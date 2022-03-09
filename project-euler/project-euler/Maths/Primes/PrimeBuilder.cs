namespace project_euler.Maths.Primes
{
    internal static class PrimeBuilder
    {
        internal static IEnumerable<int> ArrayBuildPrimesBelow(int num)
        {
            var composites = CompositesBelow(num);
            var primesWithIndex = composites.Select((isNotPrime, index) => (isPrime: !isNotPrime, number: index));
            return primesWithIndex.Where(x => x.isPrime).Select(x => x.number);
        }

        private static bool[] CompositesBelow(int num)
        {
            if (num < 3)
            {
                throw new ArgumentException("Use only with num>=3");
            }
            bool[] notPrime = new bool[num];
            var limit = (int)Math.Sqrt(notPrime.Length);
            notPrime[0] = true;
            notPrime[1] = true;
            for (int i = 2; i <= limit; i++)
            {
                if (!notPrime[i])
                {
                    for (int j = i * i; j < notPrime.Length; j += i)
                    {
                        notPrime[j] = true;
                    }
                }
            }
            return notPrime;
        }
    }
}
