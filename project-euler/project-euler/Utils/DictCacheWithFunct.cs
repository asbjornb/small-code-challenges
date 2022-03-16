namespace project_euler.Util
{
    internal class DictCacheWithFunct<TKey,TValue> where TKey : struct, IEquatable<TKey>
    {
        private readonly Dictionary<TKey, TValue> dict=new();
        private readonly Func<TKey, TValue> generator;

        public DictCacheWithFunct(Func<TKey, TValue> generator)
        {
            this.generator = generator;
        }

        public TValue Get(TKey key)
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
