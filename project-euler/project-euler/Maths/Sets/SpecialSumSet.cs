namespace project_euler.Maths.Sets
{
    internal class SpecialSumSet
    {
        private readonly SortedSet<int> set;
        private readonly List<ImmutableSortedSet<int>> subsets;

        public SpecialSumSet()
        {
            set = new SortedSet<int>();
            subsets = new List<ImmutableSortedSet<int>>();
        }

        public bool Add(int i)
        {
            if (set.Count == 0)
            {
                set.Add(i);
                subsets.Add(new ImmutableSortedSet<int>(i));
                return true;
            }
            var newSubsets = new List<ImmutableSortedSet<int>>(subsets.Select(x => x.Add(i)));
            newSubsets.Add(new ImmutableSortedSet<int>(i));
            if (Validate(newSubsets, subsets))
            {
                set.Add(i);
                subsets.AddRange(newSubsets);
                return true;
            }
            return false;
        }

        //Should use existing pairs to not re-validate
        private static bool Validate(List<ImmutableSortedSet<int>> newSubsets, List<ImmutableSortedSet<int>>  existingSubsets)
        {
            var combinations = GetPairs(newSubsets,existingSubsets);
            if (combinations.Any(pair => pair.Item1.Sum() == pair.Item2.Sum())) {
                return false;
            }
            if (combinations.Any(pair => (pair.Item1.Sum() > pair.Item2.Sum() && pair.Item1.Count < pair.Item2.Count)
                                        || (pair.Item1.Sum() < pair.Item2.Sum() && pair.Item1.Count > pair.Item2.Count))) {
                return false;
            }
            return true;
        }

        //Get all distinct pairs with 1 element from each of two given lists
        private static IEnumerable<PairOfSets> GetPairs(List<ImmutableSortedSet<int>> set1, List<ImmutableSortedSet<int>> set2)
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
            public ImmutableSortedSet<int> Item1{ get; }
            public ImmutableSortedSet<int> Item2 { get; }
            public PairOfSets(ImmutableSortedSet<int> item1, ImmutableSortedSet<int> item2)
            {
                Item1 = item1;
                Item2 = item2;
            }
        }
    }
}
