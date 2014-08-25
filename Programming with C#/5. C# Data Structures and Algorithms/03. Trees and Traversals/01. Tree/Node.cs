namespace TreesTraversals
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Node<T>
    {
        private ISet<Node<T>> children;

        /// <summary>
        /// Creates a new instance of the Node class with empty set of children.
        /// </summary>
        /// <param name="value">The value uniquely identifies the node.</param>
        public Node(T value)
        {
            this.Value = value;
            this.Children = new HashSet<Node<T>>();
        }

        /// <summary>
        /// Creates a new instance of the Node class with given set of children.
        /// </summary>
        /// <param name="value">The value uniquely identifies the node.</param>
        /// <param name="children">The children of the node.</param>
        public Node(T value, ISet<Node<T>> children)
            : this(value)
        {
            this.Children = children;
        }

        /// <summary>
        /// Gets node's value that uniquely identifies it.
        /// </summary>
        public T Value { get; set; }

        /// <summary>
        /// Gets the parent node.
        /// </summary>
        public Node<T> Parent { get; set; }

        /// <summary>
        /// Gets a collection of the children nodes.
        /// </summary>
        public ISet<Node<T>> Children
        {
            get
            {
                return this.children;
            }
            set
            {
                if (value == null)
                {
                    throw new NullReferenceException("Children collection instance cannot be null.");
                }

                this.children = value;
            }
        }

        public override string ToString()
        {
            var output = new StringBuilder();
            output.AppendFormat("Node -> Value: {0}", this.Value);

            if (this.Children.Count > 0)
            {
                var childrenValues = this.Children.Select(c => c.Value);
                var valuesToString = string.Join(", ", childrenValues);
                output.AppendFormat(" | Direct children: {{ {0} }}", valuesToString);
            }

            return output.ToString();
        }
    }
}