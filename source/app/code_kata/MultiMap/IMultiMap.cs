using System.Collections.Generic;

namespace app.code_kata.MultiMap
{
    public interface IMultiMap<TKey>
    {
        void Put(TKey key, List<TKey> keys);
        List<TKey> Get(TKey key);
        int Size { get; }
        bool IsEmpty { get; }
        int TotalItems { get; }
    }
}