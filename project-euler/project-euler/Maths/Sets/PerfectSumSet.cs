namespace project_euler.Maths.Sets
{
    internal sealed class PerfectSumSet
    {
        private readonly SortedSet<int> set;
        private List<SortedSet<int>> subsets;

        private PerfectSumSet()
        {
            set = new SortedSet<int>();
            subsets = new List<SortedSet<int>>();
        }

        public static PerfectSumSet Create()
        {
            return new();
        }

        public bool Add(int i)
        {
            if(set.Count == 0)
            {
                set.Add(i);
                subsets.Add(new SortedSet<int> { i });
                return true;
            }
            var candidateSubsets = new List<SortedSet<int>>(subsets);
            candidateSubsets.Add(new SortedSet<int> { i });
            candidateSubsets.AddRange(subsets.Select(x => new SortedSet<int>(x) { i }));
            if (Validate(candidateSubsets))
            {
                set.Add(i);
                subsets = candidateSubsets;
                return true;
            }
            return false;
        }

        //Should use existing pairs to not re-validate
        private static bool Validate(List<SortedSet<int>> candidateSubsets)
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
