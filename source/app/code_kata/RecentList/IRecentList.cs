using System;
using System.Collections;
using System.Collections.Generic;

namespace app.code_kata.RecentList
{
    public interface IRecentList<T> where T : IEquatable<T>
    {
        IEnumerable<T> List { get; }
        void AddToRecent(T item);
    }
}
