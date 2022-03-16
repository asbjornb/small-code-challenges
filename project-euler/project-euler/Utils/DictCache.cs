namespace project_euler.Util
{
    internal class DictCache<TKey,TValue> where TKey : struct, IEquatable<TKey>
    {
        private readonly Dictionary<TKey, TValue> dict=new();

        public TValue Get(TKey key, Func<TKey, TValue> generator)
        {
            if (dict.ContainsKey(key))
            {
                return dict[key];
            }
            var value = generator(key);
            dict.Add(key, value);
            return value;
        }
    }
}
