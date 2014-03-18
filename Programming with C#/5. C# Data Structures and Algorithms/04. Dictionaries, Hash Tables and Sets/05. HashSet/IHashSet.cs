using System;
using System.Collections.Generic;
using System.Linq;

interface IHashSet<T> where T : IComparable<T>
{
    bool Add(T item);

    bool Contains(T item);

    bool Remove(T item);

    void Clear();

    void UnionWith(IEnumerable<T> other);

    void IntersectWith(IEnumerable<T> other);
}