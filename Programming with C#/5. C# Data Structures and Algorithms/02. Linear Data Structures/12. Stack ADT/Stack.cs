namespace AbstractDataStructures
{
    using System;

    public class Stack<T> : IStack<T>, System.Collections.Generic.IEnumerable<T>
    {
        private const int DefaultCapacity = 4;

        private T[] elements;
        private int size = 0;

        /// <summary>
        /// Initialize a new instance of Stack class that is empty and has the default initial capacity.
        /// </summary>
        public Stack()
            : this(DefaultCapacity)
        {
        }

        /// <summary>Initializes a new instance of the Stack class that is empty 
        /// and has the specified initial capacity or the default initial capacity, 
        /// whichever is greater.</summary>
        public Stack(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException("Capacity must be non-negative number.");
            }

            this.elements = new T[Math.Max(DefaultCapacity, capacity)];
        }

        /// <summary>Initializes a new instance of the Stack class class that contains 
        /// elements copied from the specified collection.</summary>
        /// <param name="collection">The collection contains elements to seed.</param>
        public Stack(System.Collections.Generic.IEnumerable<T> collection)
            : this()
        {
            if (collection == null)
            {
                throw new NullReferenceException("Seed collection cannot be null.");
            }

            foreach (var element in collection)
            {
                this.Push(element);
            }
        }

        /// <summary>
        /// Gets the number of elements contained in the collection.
        /// </summary>
        public int Count
        {
            get
            {
                return this.size;
            }
        }

        /// <summary>
        /// Gets the total number of elements the data structure can hold.
        /// </summary>
        public int Capacity
        {
            get
            {
                return this.elements.Length;
            }
        }

        /// <summary>
        /// Inserts an objects at the top of the collection.
        /// </summary>
        /// <param name="value">The object to push onto the collection. The value can be null for reference types.</param>
        public void Push(T value)
        { 
            this.ExpandCapacity();
            this.elements[this.size++] = value;
        }

        /// <summary>
        /// Returns the object at the top of the collection without removing it.
        /// </summary>
        public T Peek()
        {
            if (this.size == 0)
            {
                throw new ArgumentException("There is no elements in stack.");
            }

            return this.elements[this.size - 1];
        }

        /// <summary>
        /// Removes and returns the object at the top of the collection.
        /// </summary>
        public T Pop()
        {
            if (this.size == 0)
            {
                throw new ArgumentException("There is no elements in stack.");
            }

            var value = this.elements[this.size - 1];
            this.elements[this.size - 1] = default(T);
            this.size--;

            return value;
        }

        /// <summary>
        /// Removes all objects from the collection.
        /// </summary>
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

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        public System.Collections.Generic.IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
            {
                yield return this.elements[i];
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
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
}