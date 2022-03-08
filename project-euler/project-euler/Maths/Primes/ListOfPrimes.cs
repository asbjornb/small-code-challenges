namespace project_euler.Maths.Primes
{
    internal sealed class ListOfPrimes
    {
        private static ListOfPrimes? instance;
        private List<int> knownPrimes = new();

        private ListOfPrimes() { }

        internal static ListOfPrimes Construct()
        {
            return instance ??= new ListOfPrimes();
        }

        public List<int> GetPrimesBelow(int num)
        {
            if (knownPrimes.LastOrDefault() >= num)
            {
                return knownPrimes.Where(x => x < num).ToList();
            }
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
