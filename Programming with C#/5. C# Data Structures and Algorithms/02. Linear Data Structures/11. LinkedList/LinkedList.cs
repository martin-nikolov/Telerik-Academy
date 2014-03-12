namespace DynamicList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class LinkedList<T> : IEnumerable<T>
    {
        public LinkedListNode<T> First { get; private set; }

        public LinkedListNode<T> Last { get; private set; }

        public int Count { get; private set; }

        public void AddFirst(T value)
        {
            var linkedListNode = new LinkedListNode<T>(value);

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

        public void AddLast(T value)
        {
            var linkedListNode = new LinkedListNode<T>(value);

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

        public void AddBefore(LinkedListNode<T> node, T value)
        {
            if (node == null)
            {
                return;
            }

            var newNode = new LinkedListNode<T>(value);

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

        public void AddAfter(LinkedListNode<T> node, T value)
        {
            if (node == null)
            {
                return;
            }

            var newNode = new LinkedListNode<T>(value);

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

        public void RemoveFirst(T value)
        {
            var node = this.FindFirst(value);

            this.RemoveReference(ref node);
        }
  
        public void RemoveLast(T value)
        {
            var node = this.FindLast(value);

            this.RemoveReference(ref node);
        }

        public LinkedListNode<T> FindFirst(T value)
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

        public LinkedListNode<T> FindLast(T value)
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

        public void Clear()
        {
            this.First = this.Last = null;
            this.Count = 0;
        }

        public IEnumerator<T> GetEnumerator()
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

        private void RemoveReference(ref LinkedListNode<T> node)
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