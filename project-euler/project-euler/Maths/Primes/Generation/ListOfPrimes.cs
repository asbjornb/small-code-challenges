namespace project_euler.Maths.Primes.Generation
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
            if (knownPrimes?.LastOrDefault() >= num)
            {
                return knownPrimes.Where(x => x < num).ToList();
            }
            knownPrimes = PrimeBuilder.BuildPrimesBelow(num).ToList();
            return knownPrimes;
        }
    }
}
