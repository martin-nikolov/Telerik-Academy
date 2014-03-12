using System;
using System.Collections;
using System.Collections.Generic;

class Stack<T> : IEnumerable<T>
{
    private const int DefaultCapacity = 4;

    private T[] elements;
    private int size = 0;

    public Stack()
    {
        this.elements = new T[0];
    }

    public Stack(int capacity)
    {
        if (capacity < 0)
        {
            throw new ArgumentOutOfRangeException("Capacity must be non-negative number.");
        }

        this.elements = new T[capacity];
    }

    public int Count
    {
        get { return this.size; }
    }

    public int Capacity
    {
        get { return this.elements.Length; }
    }

    public void Push(T value)
    {
        this.ExpandCapacity();

        this.elements[this.size++] = value;
    }

    public T Peek()
    {
        if (this.size == 0)
        {
            throw new InvalidOperationException("There is no elements in stack.");
        }

        return this.elements[this.size - 1];
    }

    public T Pop()
    {
        if (this.size == 0)
        {
            throw new InvalidOperationException("There is no elements in stack.");
        }

        var value = this.elements[this.size - 1];

        this.elements[this.size - 1] = default(T);

        this.size--;

        return value;
    }

    public void Clear()
    {
        Array.Clear(this.elements, 0, this.size);
        this.size = 0;
    }
    
    /// <summary>
    /// Sets the capacity to the actual number of elements in the Stack,
    /// if that number is less than 90 percent of current capacity.
    /// </summary>
    public void TrimExcess()
    {
        int length = (int)(this.elements.Length * 0.9);

        if (this.size < length)
        {
            T[] resizedArray = new T[this.size];
            Array.Copy(this.elements, 0, resizedArray, 0, this.size);
            this.elements = resizedArray;
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < this.Count; i++)
        {
            yield return this.elements[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    private void ExpandCapacity()
    {
        if (this.size == this.elements.Length)
        {
            T[] resizedArray = new T[this.elements.Length == 0 ? DefaultCapacity : 2 * this.elements.Length];
            Array.Copy(this.elements, 0, resizedArray, 0, this.size);
            this.elements = resizedArray;
        }
    }
}