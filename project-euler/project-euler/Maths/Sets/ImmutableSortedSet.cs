using System.Collections;

namespace project_euler.Maths.Sets
{
    internal class ImmutableSortedSet<T> : IEquatable<ImmutableSortedSet<T>?>, IEnumerable<T> where T : struct
    {
        private readonly SortedSet<T> set;

        public ImmutableSortedSet(IEnumerable<T> collection)
        {
            set = new SortedSet<T>(collection);
        }

        public ImmutableSortedSet(T element)
        {
            set = new SortedSet<T>() { element };
        }

        public SortedSet<T> ToMutable()
        {
            return new SortedSet<T>(set);
        }

        public ImmutableSortedSet<T> Add(T element)
        {
            return new ImmutableSortedSet<T>(new SortedSet<T>(set) { element });
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as ImmutableSortedSet<T>);
        }

        public bool Equals(ImmutableSortedSet<T>? other)
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

        public IEnumerator<T> GetEnumerator()
        {
            return set.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return set.GetEnumerator();
        }

        public int Count => set.Count;

        public static bool operator ==(ImmutableSortedSet<T>? left, ImmutableSortedSet<T>? right)
        {
            return EqualityComparer<ImmutableSortedSet<T>>.Default.Equals(left, right);
        }

        public static bool operator !=(ImmutableSortedSet<T>? left, ImmutableSortedSet<T>? right)
        {
            return !(left == right);
        }
    }
}
