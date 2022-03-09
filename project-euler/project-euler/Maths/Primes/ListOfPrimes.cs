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
            if (knownPrimes?.LastOrDefault() >= num)
            {
                return knownPrimes.Where(x => x < num).ToList();
            }
            knownPrimes = PrimeBuilder.ArrayBuildPrimesBelow(num).ToList();
            return knownPrimes;
        }
    }
}
