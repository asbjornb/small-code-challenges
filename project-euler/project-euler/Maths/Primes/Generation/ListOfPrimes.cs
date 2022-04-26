namespace project_euler.Maths.Primes.Generation
{
    internal sealed class ListOfPrimes
    {
        private static SortedSet<int> knownPrimes = new();
        private static HashSet<int> knownPrimesAsHash = new();
        private static int maxChecked;

        public static SortedSet<int> GetPrimesBelow(int num)
        {
            if (num <= 2) { return new(); }
            if (maxChecked >= num)
            {
                return knownPrimes.GetViewBetween(2, num - 1);
            }
            BuildUpTo(num);
            return knownPrimes;
        }

        public static HashSet<int> GetHashSetPrimes(int minimumLimit)
        {
            if (minimumLimit <= 2) { return new(); }
            if (maxChecked >= minimumLimit)
            {
                return knownPrimesAsHash;
            }
            BuildUpTo(minimumLimit);
            return knownPrimesAsHash;
        }

        public static void BuildUpTo(int num)
        {
            if (maxChecked >= num)
            {
                return;
            }
            var primes = PrimeBuilder.BuildPrimesBelow(num+1);
            knownPrimes = new SortedSet<int>(primes);
            knownPrimesAsHash = new HashSet<int>(primes);
            maxChecked = num;
        }
    }
}
