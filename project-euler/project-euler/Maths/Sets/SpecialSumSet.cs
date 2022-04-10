namespace project_euler.Maths.Sets
{
    internal class SpecialSumSet
    {
        private readonly SortedSet<int> set;
        private readonly List<ImmutableSortedSet> subsets;

        public SpecialSumSet()
        {
            set = new SortedSet<int>();
            subsets = new List<ImmutableSortedSet>();
        }

        public bool Add(int i)
        {
            if (set.Count == 0)
            {
                set.Add(i);
                subsets.Add(new ImmutableSortedSet(i));
                return true;
            }
            var newSubsets = new List<ImmutableSortedSet>(subsets.Select(x => x.Add(i)));
            newSubsets.Add(new ImmutableSortedSet(i));
            if (Validate(newSubsets, subsets))
            {
                set.Add(i);
                subsets.AddRange(newSubsets);
                return true;
            }
            return false;
        }

        //Should use existing pairs to not re-validate
        private static bool Validate(List<ImmutableSortedSet> newSubsets, List<ImmutableSortedSet>  existingSubsets)
        {
            var combinations = GetPairs(newSubsets,existingSubsets);
            if (combinations.Any(pair => pair.Item1.Sum == pair.Item2.Sum)) {
                return false;
            }
            if (combinations.Any(pair => (pair.Item1.Sum > pair.Item2.Sum && pair.Item1.Count < pair.Item2.Count)
                                        || (pair.Item1.Sum < pair.Item2.Sum && pair.Item1.Count > pair.Item2.Count))) {
                return false;
            }
            return true;
        }

        //Get all distinct pairs with 1 element from each of two given lists
        private static IEnumerable<PairOfSets> GetPairs(List<ImmutableSortedSet> set1, List<ImmutableSortedSet> set2)
        {
            foreach(var element1 in set1)
            {
                foreach(var element2 in set2)
                {
                    yield return new PairOfSets(element1, element2);
                }
            }
        }

        private class PairOfSets
        {
            public ImmutableSortedSet Item1{ get; }
            public ImmutableSortedSet Item2 { get; }
            public PairOfSets(ImmutableSortedSet item1, ImmutableSortedSet item2)
            {
                Item1 = item1;
                Item2 = item2;
            }
        }
    }
}
