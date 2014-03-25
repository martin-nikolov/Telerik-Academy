using System;
using System.Collections;
using System.Collections.Generic;

public class PriorityQueue<T> : IEnumerable 
                                where T : IComparable
{
    private List<T> heap;

    public PriorityQueue()
    {
        heap = new List<T>();
    }

    public PriorityQueue(int size)
    {
        heap = new List<T>(size);
    }

    public int Count
    {
        get
        {
            return this.heap.Count;
        }
    }

    public bool IsEmpty
    {
        get
        {
            return this.heap.Count == 0;
        }
    }

    public void Enqueue(T item)
    {
        this.heap.Add(item);

        int childIndex = this.heap.Count - 1;
        while (childIndex > 0)
        {
            int parentIndex = (childIndex - 1) / 2;
            if (this.heap[parentIndex].CompareTo(this.heap[childIndex]) <= 0)
            {
                break;
            }

            T swap = this.heap[childIndex];
            this.heap[childIndex] = this.heap[parentIndex];
            this.heap[parentIndex] = swap;

            childIndex = parentIndex;
        }
    }

    public T Dequeue()
    {
        if (this.heap.Count == 0)
        {
            throw new InvalidOperationException("Queue empty.");
        }

        int lastIndex = this.heap.Count - 1;

        T topItem = this.heap[0];
        this.heap[0] = this.heap[lastIndex];
        this.heap.RemoveAt(lastIndex);
        lastIndex--;

        int parentIndex = 0;
        while (true)
        {
            int leftIndex = 2 * parentIndex + 1;
            if (leftIndex > lastIndex)
            {
                break;
            }

            int swapIndex = leftIndex;
            int rightIndex = leftIndex + 1;
            if (rightIndex <= lastIndex && this.heap[rightIndex].CompareTo(this.heap[leftIndex]) < 0)
            {
                swapIndex = rightIndex;
            }

            if (this.heap[parentIndex].CompareTo(this.heap[swapIndex]) <= 0)
            {
                // the parent and the child are in order
                break;
            }

            T swap = this.heap[swapIndex];
            this.heap[swapIndex] = this.heap[parentIndex];
            this.heap[parentIndex] = swap;

            parentIndex = swapIndex;
        }

        return topItem;
    }

    public T Peek()
    {
        if (this.heap.Count == 0)
        {
            throw new InvalidOperationException("Queue empty.");
        }

        T topItem = this.heap[0];
        return topItem;
    }

    public void Clear()
    {
        this.heap.Clear();
    }

    public IEnumerator<T> GetEnumerator()
    {
        return this.heap.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public T[] ToArray()
    {
        return this.heap.ToArray();
    }

    public override string ToString()
    {
        return string.Join(", ", this.heap);
    }
}