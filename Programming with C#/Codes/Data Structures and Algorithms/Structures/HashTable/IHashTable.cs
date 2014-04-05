using System;
using System.Linq;

interface IHashTable<TKey, TValue>
{
    int Count { get; }

    TValue this[TKey key] { get; set; }

    void Add(TKey key, TValue value);

    TValue GetValue(TKey key);

    bool Remove(TKey key);

    void Clear();
}