using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace app.code_kata.RecentList
{
    public class RecentList<T> : IRecentList<T> where T : IEquatable<T>
    {
        readonly int limit ;
        IList<T> list = new List<T>();

        public RecentList() : this(15)
        {
        }

        public RecentList(int limit)
        {
            this.limit = limit;
        }

        public IEnumerable<T> List
        {
            get { return list.AsEnumerable(); }
        }

        public void AddToRecent(T item)
        {
            list.Remove(item);
            list.Insert(0,item);
            if(list.Count > limit)
                list.RemoveAt(limit);
        }
    }
}