namespace project_euler.Maths.Primes.Generation
{
    internal static class PrimeBuilder
    {
        public static IEnumerable<int> BuildPrimesBelow(int num)
        {
            if (num < 3)
            {
                yield break;
            }
            //Marking notPrimes is easier since bool defaults to false
            var notPrime = new bool[num];
            var limit = (int)Math.Sqrt(num);
            notPrime[0] = true; //These don't need to be marked as prime, but why not?
            notPrime[1] = true;
            for (int i = 2; i <= limit; i++)
            {
                if (!notPrime[i])
                {
                    for (int j = i * i; j < num; j += i)
                    {
                        notPrime[j] = true;
                    }
                    yield return i;
                }
            }
            for (int i = limit+1; i <num; i++)
            {
                if (!notPrime[i])
                {
                    yield return i;
                }
            }
        }
    }
}
