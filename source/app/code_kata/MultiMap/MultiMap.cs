using System;
using System.Collections.Generic;
using code_kata.integer_stack;
using System.Linq;

namespace app.code_kata.MultiMap
{
    public class MultiMap<T> : IMultiMap<T>
    {
        Dictionary<T, List<T>> map;

        public MultiMap(Dictionary<T, List<T>> map)
        {
            this.map = map;
        }

        public MultiMap() : this(new Dictionary<T, List<T>>())
        {
        }

        public void Put(T key, List<T> keys)
        {
            if(key == null)
            {
                throw new InvalidOperationException();
            }
            map.Add(key, keys);
        }

        public List<T> Get(T key)
        {
            return map[key];
        }

        public int Size
        {
            get { return map.Keys.Count; }
        }

        public bool IsEmpty
        {
            get { return map.Count == 0; }
        }

        public int TotalItems
        {
            get { return map.Values.SelectMany(x => x).Count(); }
        }
    }
}