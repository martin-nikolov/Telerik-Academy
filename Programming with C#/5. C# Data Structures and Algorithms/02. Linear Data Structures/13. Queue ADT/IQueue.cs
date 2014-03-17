using System;
using System.Linq;

interface IQueue<T>
{
    void Enqueue(T value);

    T Peek();

    T Dequeue();

    void Clear();
}