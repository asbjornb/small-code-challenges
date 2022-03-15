namespace project_euler.Maths.Primes.Generation
{
    internal sealed class ListOfPrimes
    {
        private static ListOfPrimes? instance;
        private SortedSet<int> knownPrimes = new();
        private int maxChecked;

        private ListOfPrimes() { }

        internal static ListOfPrimes Construct()
        {
            return instance ??= new ListOfPrimes();
        }

        public SortedSet<int> GetPrimesBelow(int num)
        {
            if (num <= 2) { return new(); }
            if (maxChecked >= num)
            {
                return knownPrimes.GetViewBetween(2, num-1);
            }
            knownPrimes = new SortedSet<int>(PrimeBuilder.BuildPrimesBelow(num));
            maxChecked = num;
            return knownPrimes;
        }
    }
}
