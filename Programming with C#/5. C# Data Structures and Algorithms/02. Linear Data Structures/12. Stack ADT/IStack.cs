using System;
using System.Linq;

interface IStack<T>
{
    void Push(T value);

    T Peek();

    T Pop();

    void Clear();
}