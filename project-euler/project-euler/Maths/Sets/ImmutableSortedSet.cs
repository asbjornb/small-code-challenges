using System.Collections;

namespace project_euler.Maths.Sets
{
    internal class ImmutableSortedSet : IEquatable<ImmutableSortedSet?>, IEnumerable<int>
    {
        protected readonly SortedSet<int> set;
        public int Sum { get; }
        public int Count => set.Count;

        public ImmutableSortedSet(IEnumerable<int> collection)
        {
            set = new SortedSet<int>(collection);
            Sum = set.Sum();
        }

        public ImmutableSortedSet(int element)
        {
            set = new SortedSet<int>() { element };
            Sum = element;
        }

        public SortedSet<int> ToMutable()
        {
            return new SortedSet<int>(set);
        }

        public ImmutableSortedSet Add(int element)
        {
            return new ImmutableSortedSet(new SortedSet<int>(set) { element });
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as ImmutableSortedSet);
        }

        public bool Equals(ImmutableSortedSet? other)
        {
            return other?.set.SequenceEqual(set) == true;
        }

        public override int GetHashCode()
        {
            int hc = 0;
            foreach (var element in set)
            {
                hc ^= element.GetHashCode();
            }
            return hc;
        }

        public IEnumerator<int> GetEnumerator()
        {
            return set.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return set.GetEnumerator();
        }

        public static bool operator ==(ImmutableSortedSet? left, ImmutableSortedSet? right)
        {
            return EqualityComparer<ImmutableSortedSet>.Default.Equals(left, right);
        }

        public static bool operator !=(ImmutableSortedSet? left, ImmutableSortedSet? right)
        {
            return !(left == right);
        }
    }
}
