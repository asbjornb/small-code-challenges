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
            if(set.Count == 0)
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
            var combinations = candidateSubsets.SelectMany(_=>candidateSubsets, (x,y)=>(x,y))
                .Where(pair => pair.x!=pair.y);
            //Can be made more efficient with .Where((x,y) => x<y) with some ordering
            //Also add compare - so new class. Need to filter combinations for B!=C.
            if(combinations.Any(pair=>pair.x.Sum()== pair.y.Sum())){
                return false;
            }
            if (combinations.Any(pair => pair.x.Sum() >= pair.y.Sum() && pair.x.Count < pair.y.Count)){
                return false;
            }
            return true;
        }
    }
}
