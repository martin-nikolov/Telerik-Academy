namespace PathFinder
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Node<T> where T : struct, IComparable<T>
    {
        private readonly IList<Node<T>> childs;
        private T value;

        public Node(T value)
        {
            this.Value = value;
            this.childs = new List<Node<T>>();
        }

        public T Value
        {
            get { return this.value; }
            private set { this.value = value; }
        }

        public IList<Node<T>> Childs
        {
            get { return this.childs.ToList(); }
        }

        public void AddChild(Node<T> child)
        {
            this.childs.Add(child);
        }
    }
}