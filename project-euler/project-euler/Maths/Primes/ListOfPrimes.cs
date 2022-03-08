﻿namespace project_euler.Maths.Primes
{
    internal class ListOfPrimes
    {
        private List<int> knownPrimes = new();

        public PrimeFactorization FindPrimeFactors(int num)
        {
            var rest = num;
            var primes = GeneratePrimesBelow(num+1);
            int index = 0;
            var primeFactors = new PrimeFactorization();
            while(primes[index] <= rest)
            {
                if (IsDivisible(rest, primes[index]))
                {
                    rest /= primes[index];
                    primeFactors.AddFactor(primes[index]);
                }
                else
                {
                    index++;
                }
            }
            return primeFactors;
        }

        public List<int> GeneratePrimesBelow(int num)
        {
            List<int> primes = new(knownPrimes);
            var startAt = 2;
            if (knownPrimes.Count > 0)
            {
                startAt = knownPrimes.Last();
            }
            for (int i = startAt; i < num; i++)
            {
                if(primes.Exists(x => IsDivisible(i,x)))
                {
                    continue;
                }
                primes.Add(i);
            }
            knownPrimes = primes; //Should only add new. In general linq with Take() and something to calculate next on request with yield return?
            return primes;
        }

        private static bool IsDivisible(int num, int divisor)
        {
            return num % divisor == 0;
        }
    }
}