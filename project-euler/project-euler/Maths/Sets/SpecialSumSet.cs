namespace project_euler.Maths.Sets
{
    internal class SpecialSumSet
    {
        private readonly SortedSet<int> set;
        private List<ImmutableSortedSet<int>> subsets;

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
            var candidateSubsets = new List<ImmutableSortedSet<int>>(subsets);
            candidateSubsets.Add(new ImmutableSortedSet<int>(i));
            candidateSubsets.AddRange(subsets.Select(x => x.Add(i)));
            if (Validate(candidateSubsets))
            {
                set.Add(i);
                subsets = candidateSubsets;
                return true;
            }
            return false;
        }

        //Should use existing pairs to not re-validate
        private static bool Validate(List<ImmutableSortedSet<int>> candidateSubsets)
        {
            var combinations = GetPairs(candidateSubsets);
            //Also add compare - so new class. Need to filter combinations for B!=C.
            if (combinations.Any(pair => pair.Item1.Sum() == pair.Item2.Sum())) {
                return false;
            }
            if (combinations.Any(pair => pair.Item1.Sum() >= pair.Item2.Sum() && pair.Item1.Count < pair.Item2.Count)) {
                return false;
            }
            return true;
        }

        private static IEnumerable<PairOfSets> GetPairs(List<ImmutableSortedSet<int>> candidateSubsets)
        {
            for (int i = 0; i < candidateSubsets.Count; i++)
            {
                for (int j = i+1; j < candidateSubsets.Count; j++)
                {
                    yield return new PairOfSets(candidateSubsets[i], candidateSubsets[j]);
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
