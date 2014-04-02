namespace DataStructures
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

    partial class BiDictionary<K1, K2, V> : IBiDictionary<K1, K2, V>
    {
        private MultiDictionary<K1, IKeyValueTuple<K1, K2, V>> byKey1;
        private MultiDictionary<K2, IKeyValueTuple<K1, K2, V>> byKey2;
        private MultiDictionary<Tuple<K1, K2>, IKeyValueTuple<K1, K2, V>> byKey1Key2;

        public BiDictionary(bool allowDublicateValues)
        {
            this.byKey1 = new MultiDictionary<K1, IKeyValueTuple<K1, K2, V>>(allowDublicateValues);
            this.byKey2 = new MultiDictionary<K2, IKeyValueTuple<K1, K2, V>>(allowDublicateValues);
            this.byKey1Key2 = new MultiDictionary<Tuple<K1, K2>, IKeyValueTuple<K1, K2, V>>(allowDublicateValues);
        }

        public ICollection<IKeyValueTuple<K1, K2, V>> Values
        {
            get { return this.byKey1Key2.Values.ToArray(); }
        }

        public int Count
        {
            get { return this.byKey1Key2.KeyValuePairs.Count; }
        }

        public void Add(K1 key1, K2 key2, V value)
        {
            var tuple = new KeyValueTuple(key1, key2, value);
            var key1Key2 = new Tuple<K1, K2>(key1, key2);

            this.byKey1[key1].Add(tuple);
            this.byKey2[key2].Add(tuple);
            this.byKey1Key2[key1Key2].Add(tuple);
        }

        public ICollection<V> GetByFirstKey(K1 key1)
        {
            return this.byKey1[key1].Select(a => a.Value).ToArray();
        }

        public ICollection<V> GetBySecondKey(K2 key2)
        {
            return this.byKey2[key2].Select(a => a.Value).ToArray();
        }

        public ICollection<V> GetByTwoKeys(K1 key1, K2 key2)
        {
            return this.byKey1Key2[new Tuple<K1, K2>(key1, key2)].Select(a => a.Value).ToArray();
        }

        public void RemoveByFirstKey(K1 key1)
        {
            var values = this.byKey1[key1];

            foreach (var tuple in values)
            {
                this.byKey2.Remove(tuple.Key2, tuple);
                this.byKey1Key2.Remove(new Tuple<K1, K2>(tuple.Key1, tuple.Key2), tuple);
            }

            this.byKey1.Remove(key1);
        }

        public void RemoveBySecondKey(K2 key2)
        {
            var values = this.byKey2[key2];

            foreach (var tuple in values)
            {
                this.byKey1.Remove(tuple.Key1, tuple);
                this.byKey1Key2.Remove(new Tuple<K1, K2>(tuple.Key1, tuple.Key2), tuple);
            }

            this.byKey2.Remove(key2);
        }

        public void RemoveByTwoKeys(K1 key1, K2 key2)
        {
            var tuple = new Tuple<K1, K2>(key1, key2);
            var values = this.byKey1Key2[tuple];

            foreach (var value in values)
            {
                this.byKey1.Remove(key1, value);
                this.byKey2.Remove(key2, value);
            }

            this.byKey1Key2.Remove(tuple);
        }

        public void Clear()
        {
            this.byKey1.Clear();
            this.byKey2.Clear();
            this.byKey1Key2.Clear();
        }
    }
}