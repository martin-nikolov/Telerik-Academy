using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// A binary heap, useful for sorting data and priority queues.
/// </summary>
/// <typeparam name="T"><![CDATA[IComparable<T> type of item in the heap]]>.</typeparam>
public class BinaryHeap<T> : ICollection<T> where T : IComparable<T>
{
    // Constants
    private const int DefaultSize = 4;

    // Fields
    private T[] innerArray = new T[DefaultSize];
    private int count = 0;
    private int capacity = DefaultSize;
    private bool sorted;

    // Constructors
    /// <summary>
    /// Creates a new binary heap.
    /// </summary>
    public BinaryHeap()
    {
    }

    private BinaryHeap(T[] data, int count)
    {
        this.Capacity = this.count;
        this.count = count;
        Array.Copy(this.innerArray, data, this.count);
    }

    // Properties
    /// <summary>
    /// Gets the number of values in the heap. 
    /// </summary>
    public int Count
    {
        get
        {
            return this.count;
        }
    }

    /// <summary>
    /// Gets whether or not the binary heap is readonly.
    /// </summary>
    public bool IsReadOnly
    {
        get
        {
            return false;
        }
    }

    /// <summary>
    /// Gets or sets the capacity of the heap.
    /// </summary>
    public int Capacity
    {
        get
        {
            return this.capacity;
        }

        set
        {
            int previousCapacity = this.capacity;
            this.capacity = Math.Max(value, this.count);

            if (this.capacity != previousCapacity)
            {
                T[] temp = new T[this.capacity];
                Array.Copy(this.innerArray, temp, this.count);
                this.innerArray = temp;
            }
        }
    }

    // Methods
    /// <summary>
    /// Gets the first value in the heap without removing it.
    /// </summary>
    /// <returns>The lowest value of type TValue.</returns>
    public T Peek()
    {
        return this.innerArray[0];
    }

    /// <summary>
    /// Removes all items from the heap.
    /// </summary>
    public void Clear()
    {
        this.count = 0;
        this.innerArray = new T[this.capacity];
    }

    /// <summary>
    /// Adds a key and value to the heap.
    /// </summary>
    /// <param name="item">The item to add to the heap.</param>
    public void Add(T item)
    {
        if (this.count == this.capacity)
        {
            this.Capacity *= 2;
        }

        this.innerArray[this.count] = item;
        this.UpHeap();
        this.count++;
    }

    /// <summary>
    /// Removes and returns the first item in the heap.
    /// </summary>
    /// <returns>The next value in the heap.</returns>
    public T Remove()
    {
        if (this.count == 0)
        {
            throw new InvalidOperationException("Heap is empty.");
        }

        T currentValue = this.innerArray[0];
        this.count--;
        this.innerArray[0] = this.innerArray[this.count];

        // Clears the Last Node
        this.innerArray[this.count] = default(T);
        this.DownHeap();

        return currentValue;
    }

    /// <summary>
    /// Creates a new instance of an identical binary heap.
    /// </summary>
    /// <returns>A BinaryHeap.</returns>
    public BinaryHeap<T> Copy()
    {
        return new BinaryHeap<T>(this.innerArray, this.count);
    }

    /// <summary>
    /// Gets an enumerator for the binary heap.
    /// </summary>
    /// <returns>An IEnumerator of type T.</returns>
    public IEnumerator<T> GetEnumerator()
    {
        this.EnsureSort();

        for (int i = 0; i < this.count; i++)
        {
            yield return this.innerArray[i];
        }
    }

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    /// <summary>
    /// Checks to see if the binary heap contains the specified item.
    /// </summary>
    /// <param name="item">The item to search the binary heap for.</param>
    /// <returns>A boolean, true if binary heap contains item.</returns>
    public bool Contains(T item)
    {
        this.EnsureSort();

        return Array.BinarySearch<T>(this.innerArray, 0, this.count, item) >= 0;
    }

    /// <summary>
    /// Copies the binary heap to an array at the specified index.
    /// </summary>
    /// <param name="array">One dimensional array that is the destination of the copied elements.</param>
    /// <param name="arrayIndex">The zero-based index at which copying begins.</param>
    public void CopyTo(T[] array, int arrayIndex)
    {
        this.EnsureSort();
        Array.Copy(this.innerArray, array, this.count);
    }

    /// <summary>
    /// Removes an item from the binary heap. This utilizes the type T's Comparer and will not remove duplicates.
    /// </summary>
    /// <param name="item">The item to be removed.</param>
    /// <returns>Boolean true if the item was removed.</returns>
    public bool Remove(T item)
    {
        this.EnsureSort();
        int i = Array.BinarySearch<T>(this.innerArray, 0, this.count, item);
        if (i < 0)
        {
            return false;
        }

        Array.Copy(this.innerArray, i + 1, this.innerArray, i, this.count - i);
        this.innerArray[this.count] = default(T);
        this.count--;

        return true;
    }

    // helper function that calculates the parent of a node
    private static int Parent(int index)
    {
        return (index - 1) >> 1;
    }

    // helper function that calculates the first child of a node
    private static int Child1(int index)
    {
        return (index << 1) + 1;
    }

    // helper function that calculates the second child of a node
    private static int Child2(int index)
    {
        return (index << 1) + 2;
    }

    // helper function that performs up-heap bubbling
    private void UpHeap()
    {
        this.sorted = false;
        int currentCount = this.count;
        T item = this.innerArray[currentCount];
        int currentParrent = Parent(currentCount);

        while (currentParrent > -1 && item.CompareTo(this.innerArray[currentParrent]) < 0)
        {
            // Swap nodes
            this.innerArray[currentCount] = this.innerArray[currentParrent];
            currentCount = currentParrent;
            currentParrent = Parent(currentCount);
        }

        this.innerArray[currentCount] = item;
    }

    // helper function that performs down-heap bubbling
    private void DownHeap()
    {
        this.sorted = false;
        int n = 0;
        int p = 0;
        T item = this.innerArray[p];
        while (true)
        {
            int ch1 = Child1(p);
            if (ch1 >= this.count)
            {
                break;
            }

            int ch2 = Child2(p);

            if (ch2 >= this.count)
            {
                n = ch1;
            }
            else
            {
                n = this.innerArray[ch1].CompareTo(this.innerArray[ch2]) < 0 ? ch1 : ch2;
            }

            if (item.CompareTo(this.innerArray[n]) > 0)
            {
                // Swap nodes
                this.innerArray[p] = this.innerArray[n];
                p = n;
            }
            else
            {
                break;
            }
        }

        this.innerArray[p] = item;
    }

    private void EnsureSort()
    {
        if (this.sorted)
        {
            return;
        }

        Array.Sort(this.innerArray, 0, this.count);
        this.sorted = true;
    }
}