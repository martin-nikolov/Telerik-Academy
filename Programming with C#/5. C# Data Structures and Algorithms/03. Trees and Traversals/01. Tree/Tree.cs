namespace TreesTraversals
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    public class Tree<T>
    {
        private readonly IDictionary<T, Node<T>> nodes = new Dictionary<T, Node<T>>();

        /// <summary>
        /// Returns the parent node of the tree.
        /// </summary>
        public Node<T> ParentNode
        {
            get
            {
                return this.nodes.Values.First(n => n.Parent == null); // HACK: Would not works correctly if there is more than 1 parent node. 
            }
        }

        /// <summary>
        /// Returns a collection of all Node objects in the tree.
        /// </summary>
        public IReadOnlyCollection<Node<T>> Nodes
        {
            get
            {
                return new ReadOnlyCollection<Node<T>>(this.nodes.Values.ToList());
            }
        }

        /// <summary>
        /// Returns all middle nodes (that have both - parent and children) in the tree.
        /// </summary>
        public IReadOnlyCollection<Node<T>> MiddleNodes
        {
            get
            {
                var middleNodes = this.nodes.Values.Where(n => n.Children.Count != 0 && n.Parent != null).ToList();
                return new ReadOnlyCollection<Node<T>>(middleNodes);
            }
        }

        /// <summary>
        /// Returns all leaf nodes (that have only parent, but not children) in the tree.
        /// </summary>
        public IReadOnlyCollection<Node<T>> LeafNodes
        {
            get
            {
                var leafNodes = this.nodes.Values.Where(n => n.Children.Count == 0).ToList();
                return new ReadOnlyCollection<Node<T>>(leafNodes);
            }
        }

        /// <summary>
        /// Connects two nodes in the tree. If some of the node does not exists, it is created.
        /// </summary>
        /// <param name="parentNodeValue">The parent node that the child to be added.</param>
        /// <param name="childNodeValue">The child node to be added to the parent node.</param>
        public void ConnectNodes(T parentNodeValue, T childNodeValue)
        {
            var parentNode = this.TryGetNode(parentNodeValue);
            var childNode = this.TryGetNode(childNodeValue);
            parentNode.Children.Add(childNode);
            childNode.Parent = parentNode;
        }

        private Node<T> TryGetNode(T nodeValue)
        {
            if (!this.nodes.ContainsKey(nodeValue))
            {
                var node = new Node<T>(nodeValue);
                this.nodes[nodeValue] = node;
                return node;
            }

            return this.nodes[nodeValue];
        }
    }
}