using System;
using System.Collections;
using System.Collections.Generic;

class Queue<T> : IEnumerable<T>
{
    private LinkedList<T> elements;

    public Queue()
    {
        this.elements = new LinkedList<T>();
    }

    public int Count
    {
        get { return this.elements.Count; }
    }

    public void Enqueue(T value)
    {
        this.elements.AddLast(value);
    }

    public T Peek()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException("There is no elements in queue.");
        }

        return this.elements.First.Value;
    }

    public T Dequeue()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException("There is no elements in queue.");
        }

        T value = this.elements.First.Value;

        this.elements.RemoveFirst();

        return value;
    }

    public void Clear()
    {
        this.elements.Clear();
    }

    public IEnumerator<T> GetEnumerator()
    {
        foreach (var element in this.elements)
        {
            yield return element;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}