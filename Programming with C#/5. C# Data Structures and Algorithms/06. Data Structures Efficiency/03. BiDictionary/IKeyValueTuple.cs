namespace DataStructures
{
    using System;
    using System.Linq;

    interface IKeyValueTuple<K1, K2, V> : IEquatable<IKeyValueTuple<K1, K2, V>>
    {
        K1 Key1 { get; }

        K2 Key2 { get; }

        V Value { get; }

        bool Equals(IKeyValueTuple<K1, K2, V> other);

        bool Equals(object obj);

        int GetHashCode();
    }
}