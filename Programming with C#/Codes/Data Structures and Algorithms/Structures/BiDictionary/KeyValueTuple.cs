namespace DataStructures
{
    using System;
    using System.Linq;

    partial class BiDictionary<K1, K2, V>
    {
        internal class KeyValueTuple : IKeyValueTuple<K1, K2, V>
        {
            public KeyValueTuple(K1 key1, K2 key2, V value)
            {
                this.Key1 = key1;
                this.Key2 = key2;
                this.Value = value;
            }

            public K1 Key1 { get; private set; }

            public K2 Key2 { get; private set; }

            public V Value { get; private set; }

            public bool Equals(IKeyValueTuple<K1, K2, V> other)
            {
                return !ReferenceEquals(other, null) &&
                       this.Key1.Equals(other.Key1) &&
                       this.Key2.Equals(other.Key2) &&
                       this.Value.Equals(other.Value);
            }

            public override bool Equals(object obj)
            {
                return this.Equals(obj as IKeyValueTuple<K1, K2, V>);
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    int result = 17;

                    result = result * 23 + this.Key1.GetHashCode();
                    result = result * 23 + this.Key2.GetHashCode();
                    result = result * 23 + this.Value.GetHashCode();

                    return result;
                }
            }

            public override string ToString()
            {
                return string.Format("[{0}, {1}, {2}]", this.Key1, this.Key2, this.Value);
            }
        }
    }
}