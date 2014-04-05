using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

class HashTable<TKey, TValue> : IHashTable<TKey, TValue>, IEnumerable<KeyValuePair<TKey, TValue>>
{
    private const int DefaultCapacity = 16;
    private const float DefaultLoadFactory = 0.75f;
    private readonly int initialCapacity;
    
    private IList<KeyValuePair<TKey, TValue>>[] table;

    public HashTable()
        : this(DefaultCapacity)
    {
    }

    public HashTable(int capacity)
    {
        this.initialCapacity = capacity;
        this.table = new IList<KeyValuePair<TKey, TValue>>[capacity];
    }
  
    public int Count { get; private set; }

    public TValue this[TKey key]
    {
        get { return this.GetValue(key); }
        set { this.Add(key, value); }
    }

    public void Add(TKey key, TValue value)
    {
        var chain = this.FindChain(key, true);

        for (int i = 0; i < chain.Count; i++)
        {
            if (chain[i].Key.Equals(key))
            {
                chain[i] = new KeyValuePair<TKey, TValue>(key, value);
                return;
            }
        }

        chain.Add(new KeyValuePair<TKey, TValue>(key, value));

        this.Count++;

        this.Expand();
    }

    public TValue GetValue(TKey key)
    {
        var chain = this.FindChain(key, false);

        if (chain != null)
        {
            for (int i = 0; i < chain.Count; i++)
            {
                if (chain[i].Key.Equals(key))
                {
                    return chain[i].Value;
                }
            }
        }

        throw new KeyNotFoundException("The given key was not present in the hash table.");
    }

    public bool Remove(TKey key)
    {
        var chain = this.FindChain(key, false);

        if (chain != null)
        {
            for (int i = 0; i < chain.Count; i++)
            {
                if (chain[i].Key.Equals(key))
                {
                    chain.RemoveAt(i);
                    this.Count--;
                    return true;
                }
            }
        }

        return false;
    }

    public void Clear()
    {
        if (this.table != null)
        {
            this.table = new IList<KeyValuePair<TKey, TValue>>[this.initialCapacity];
        }

        this.Count = 0;
    }

    public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
    {
        foreach (var chain in this.table)
        {
            if (chain != null)
            {
                foreach (var keyValuePair in chain)
                {
                    yield return keyValuePair;
                }
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    private IList<KeyValuePair<TKey, TValue>> FindChain(TKey key, bool createIfMissing)
    {
        var hash = key.GetHashCode() & int.MaxValue;
        var index = hash % this.table.Length;

        if (this.table[index] == null && createIfMissing)
        {
            this.table[index] = new List<KeyValuePair<TKey, TValue>>();
        }

        return this.table[index];
    }

    private void Expand()
    {
        var maxLength = (int)(this.table.Length * DefaultLoadFactory);

        if (this.Count >= maxLength)
        {
            int newCapacity = this.table.Length * 2;

            IList<KeyValuePair<TKey, TValue>>[] oldTable = this.table;
            this.table = new List<KeyValuePair<TKey, TValue>>[newCapacity];

            foreach (var oldChain in oldTable)
            {
                if (oldChain != null)
                {
                    foreach (var keyValuePair in oldChain)
                    {
                        var chain = this.FindChain(keyValuePair.Key, true);
                        chain.Add(keyValuePair);
                    }
                }
            }
        }
    }
}