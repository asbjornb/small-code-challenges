namespace project_euler.Maths
{
    internal class Primes
    {
        private readonly List<int> knownPrimes = new();

        public List<int> FindPrimeFactors(int num)
        {
            var rest = num;
            var primes = GeneratePrimesBelow(num+1);
            int index = 0;
            var primeFactors = new int[primes.Count];
            while(primes[index] <= rest)
            {
                if (IsDivisible(rest, primes[index]))
                {
                    rest /= primes[index];
                    primeFactors[index]++;
                }
                else
                {
                    index++;
                }
            }
            return primeFactors.ToList();
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
            return primes;
        }

        public static bool IsDivisible(int num, int divisor)
        {
            return num % divisor == 0;
        }
    }
}
