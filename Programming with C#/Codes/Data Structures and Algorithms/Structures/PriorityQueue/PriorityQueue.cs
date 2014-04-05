using System;

public class PriorityQueue<T> where T : IComparable
{
    private const int InitialCapacity = 16;

    private T[] heap;
    private int index;

    /// <summary>
    /// Creates a new priority queue. Implementation is based on the binary heap data structure.
    /// </summary>
    public PriorityQueue()
    {
        this.heap = new T[InitialCapacity];
        this.index = 1;
    }

    /// <summary>
    /// Gets the number of elements contained in the priority queue.
    /// </summary>
    public int Count
    {
        get { return this.index - 1; }
    }

    /// <summary>
    /// Adds a new element to the priority queue.
    /// </summary>
    /// <param name="element">The element to add to the priority queue.</param>
    public void Add(T element)
    {
        this.IncreaseArrayIfNecessary();

        this.heap[this.index] = element;

        int childIndex = this.index;
        int parentIndex = childIndex / 2;
        this.index++;

        while (parentIndex >= 1 && this.heap[childIndex].CompareTo(this.heap[parentIndex]) < 0)
        {
            T swapValue = this.heap[parentIndex];
            this.heap[parentIndex] = this.heap[childIndex];
            this.heap[childIndex] = swapValue;

            childIndex = parentIndex;
            parentIndex = childIndex / 2;
        }
    }

    /// <summary>
    /// Removes and returns the first element from the priority queue.
    /// </summary>
    /// <returns>The element of type T with high priority.</returns>
    public T RemoveFirst()
    {
        T result = this.heap[1];

        this.heap[1] = this.heap[this.Count];
        this.index--;

        int rootIndex = 1;
        int minChild;

        while (true)
        {
            int leftChildIndex = rootIndex * 2;
            int rightChildIndex = rootIndex * 2 + 1;

            if (leftChildIndex > this.index) break;

            if (rightChildIndex > this.index)
            {
                minChild = leftChildIndex;
            }
            else if (this.heap[leftChildIndex].CompareTo(this.heap[rightChildIndex]) < 0)
            {
                minChild = leftChildIndex;
            }
            else
            {
                minChild = rightChildIndex;
            }

            if (this.heap[minChild].CompareTo(this.heap[rootIndex]) < 0)
            {
                T swapValue = this.heap[rootIndex];
                this.heap[rootIndex] = this.heap[minChild];
                this.heap[minChild] = swapValue;

                rootIndex = minChild;
            }
            else
            {
                break;
            }
        }

        return result;
    }

    /// <summary>
    /// Gets the first element from the priority queue without removing it.
    /// </summary>
    /// <returns>The element of type T with high priority.</returns>
    public T Peek()
    {
        return this.heap[1];
    }

    private void IncreaseArrayIfNecessary()
    {
        if (this.index >= this.heap.Length - 1)
        {
            T[] copiedHeap = new T[this.heap.Length * 2];

            Array.Copy(this.heap, 0, copiedHeap, 0, this.heap.Length);

            this.heap = copiedHeap;
        }
    }
}