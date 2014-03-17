namespace DynamicList
{
    using System;
    using System.Collections;

    public class DoubleLinkedList<T> : System.Collections.Generic.IEnumerable<T>
    {
        /// <summary>
        /// Gets the first node of the collection.
        /// </summary>
        public ListNode<T> First { get; private set; }

        /// <summary>
        /// Gets the last node of the collection.
        /// </summary>
        public ListNode<T> Last { get; private set; }

        /// <summary>
        /// Gets the number of nodes actually contained in the collection.
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Adds a new node containing the specified value at the start of the collection.
        /// </summary>
        /// <param name="value">The value to add at the start of the collection.</param>
        public void AddFirst(T value)
        {
            var linkedListNode = new ListNode<T>(value);

            if (this.First == null)
            {
                this.First = this.Last = linkedListNode;
            }
            else
            {
                linkedListNode.Next = this.First;
                this.First.Previous = linkedListNode;
                this.First = linkedListNode;
            }

            this.Count++;
        }

        /// <summary>
        /// Adds a new node containing the specified value at the end of the collection.
        /// </summary>
        /// <param name="value">The value to add at the end of the collection.</param>
        public void AddLast(T value)
        {
            var linkedListNode = new ListNode<T>(value);

            if (this.Last == null)
            {
                this.First = this.Last = linkedListNode;
            }
            else
            {
                linkedListNode.Previous = this.Last;
                this.Last.Next = linkedListNode;
                this.Last = linkedListNode;
            }

            this.Count++;
        }

        /// <summary>
        /// Adds a new node containing the specified value before the specified existing node in the collection.
        /// </summary>
        /// <param name="node">The ListNode before which to insert a new ListNode containing value.</param>
        /// <param name="value">The value to add to the collection.</param>
        public void AddBefore(ListNode<T> node, T value)
        {
            if (node == null)
            {
                return;
            }

            var newNode = new ListNode<T>(value);

            if (node.Previous == null)
            {
                node.Previous = newNode;
                newNode.Next = node;
            }
            else
            {
                newNode.Next = node;
                newNode.Previous = node.Previous;

                node.Previous.Next = newNode;
                node.Previous = newNode;
            }

            if (node == this.First)
            {
                this.First = newNode;
            }

            this.Count++;
        }

        /// <summary>
        /// Adds a new node containing the specified value after the specified existing node in the collection.
        /// </summary>
        /// <param name="node">The ListNode after which to insert a new ListNode containing value.</param>
        /// <param name="value">The value to add to the collection.</param>
        public void AddAfter(ListNode<T> node, T value)
        {
            if (node == null)
            {
                return;
            }

            var newNode = new ListNode<T>(value);

            if (node.Next == null)
            {
                node.Next = newNode;
                newNode.Previous = node;
            }
            else
            {
                newNode.Next = node.Next;
                newNode.Previous = node;

                node.Next.Previous = newNode;
                node.Next = newNode;
            }

            if (node == this.Last)
            {
                this.Last = newNode;
            }

            this.Count++;
        }

        /// <summary>
        /// Removes the first occurrence of the specified value from the collection.
        /// </summary>
        /// <param name="value">The value to remove from the collection.</param>
        public void Remove(T value)
        {
            var node = this.Find(value);

            this.RemoveReference(ref node);
        }

        /// <summary>
        /// Removes the node at the start of the collection.
        /// </summary>
        public void RemoveFirst()
        {
            var node = this.First;

            this.RemoveReference(ref node);
        }

        /// <summary>
        /// Removes the node at the end of the collection.
        /// </summary>
        public void RemoveLast()
        {
            var node = this.Last;

            this.RemoveReference(ref node);
        }

        /// <summary>
        /// Finds the first node that contains the specified value.
        /// </summary>
        /// <param name="value">The value to locate in the collection.</param>
        public ListNode<T> Find(T value)
        {
            var currentNode = this.First;

            while (currentNode != null)
            {
                if (currentNode.Value.Equals(value))
                {
                    return currentNode;
                }

                currentNode = currentNode.Next;
            }

            return null;
        }

        /// <summary>
        /// Finds the last node that contains the specified value.
        /// </summary>
        /// <param name="value">The value to locate in the collection.</param>
        public ListNode<T> FindLast(T value)
        {
            var currentNode = this.Last;

            while (currentNode != null)
            {
                if (currentNode.Value.Equals(value))
                {
                    return currentNode;
                }

                currentNode = currentNode.Previous;
            }

            return null;
        }

        /// <summary>
        /// Removes all nodes from the collection.
        /// </summary>
        public void Clear()
        {
            this.First = this.Last = null;
            this.Count = 0;
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        public System.Collections.Generic.IEnumerator<T> GetEnumerator()
        {
            var currentNode = this.First;

            while (currentNode != null)
            {
                yield return currentNode.Value;

                currentNode = currentNode.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private void RemoveReference(ref ListNode<T> node)
        {
            if (node != null)
            {
                if (node.Previous != null)
                {
                    node.Previous.Next = node.Next;
                }

                if (node.Next != null)
                {
                    node.Next.Previous = node.Previous;
                }

                if (node == this.First)
                {
                    this.First = node.Next;
                }
                
                if (node == this.Last)
                {
                    this.Last = node.Previous;
                }

                node = null;

                this.Count--;
            }
        }
    }
}