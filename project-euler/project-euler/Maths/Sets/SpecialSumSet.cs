namespace project_euler.Maths.Sets
{
    internal class SpecialSumSet
    {
        private readonly SortedSet<int> set;
        private readonly HashSet<int> subsetSums;

        public SpecialSumSet()
        {
            set = new SortedSet<int>();
            subsetSums = new HashSet<int>() { 0 };
        }

        private SpecialSumSet(SpecialSumSet toClone)
        {
            set = new(toClone.set);
            subsetSums = new(toClone.subsetSums);
        }

        public bool Add(int i)
        {
            if (set.Count == 0)
            {
                set.Add(i);
                subsetSums.Add(i);
                return true;
            }
            if(set.Count == 1)
            {
                set.Add(i);
                var currentSums = subsetSums.ToList();
                currentSums.ForEach(x => subsetSums.Add(x + i));
                return true;
            }
            var newSet = new SortedSet<int>(set) { i };
            int half = newSet.Count / 2;
            //If the subset of smallest half elements A and the subset of the largest half elements B satisfy Count(A)>Count(B) AND Sum(A)<=Sum(B)
            //Then obviously return false. No other subsets can satisfy the above if smallest vs. largest doesn't.
            if ((newSet.Count % 2 == 0 && newSet.Take(half).Sum() <= newSet.Skip(half + 1).Sum())
                || (newSet.Count % 2 == 1 && newSet.Take(half + 1).Sum() < newSet.Skip(half + 1).Sum()))
            {
                return false;
            }
            //If any 2 distinct subsets A and B has Sum(A)==Sum(B) then removing common elements two disjoint subsets A' and B' has the same property
            foreach (var sum in subsetSums.ToList())
            {
                var newSum = sum + i;
                if (subsetSums.Contains(newSum))
                {
                    return false;
                }
                subsetSums.Add(newSum);
            }
            set.Add(i);
            return true;
        }

        public SpecialSumSet Clone()
        {
            return new SpecialSumSet(this);
        }
    }
}
