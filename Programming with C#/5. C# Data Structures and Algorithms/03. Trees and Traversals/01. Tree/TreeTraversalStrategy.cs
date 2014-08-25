namespace TreesTraversals
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TreeTraversalStrategy
    {
        /// <summary>
        /// Gets longest paths in tree starting from given node 
        /// and ending with leaf nodes from the subtree.
        /// </summary>
        /// <param name="startupNode">The node from which to be started traversion.</param>
        /// <returns>A collection of all longest paths in the given subtree.</returns>
        public List<List<int>> GetLongestPathInTree(Node<int> startupNode)
        {
            var allLongestPathsInSubtree = new List<List<int>>();
            var currentPath = new LinkedList<int>();
            var maxLength = 0;
            this.ConnectLongestPathsInSubtree(startupNode, currentPath, allLongestPathsInSubtree, ref maxLength);

            var longestPaths = allLongestPathsInSubtree.Where(p => p.Count == maxLength).ToList();
            return longestPaths;
        }

        /// <summary>
        /// Gets all paths in tree with given sum starting from given node 
        /// and ending with leaf nodes from the subtree.
        /// </summary>
        /// <param name="startupNode">The node from which to be started traversion.</param>
        /// <param name="sum">The sum that have to be formed by node values.</param>
        /// <returns>A collection of all paths with given sum formed by node values.</returns>
        public List<List<int>> GetAllPathsInTreeWithGivenSum(Node<int> startupNode, int sum)
        {
            var allPathsWithGivenSum = new List<List<int>>();
            var currentPath = new LinkedList<int>();
            this.ConnectPathsWithGivenSumInTreeUsingRecursivelyDfs(startupNode, currentPath, allPathsWithGivenSum, sum);
            return allPathsWithGivenSum;
        }

        /// <summary>
        /// Gets all subtrees with given sum.
        /// </summary>
        /// <param name="tree">The tree from which to be extracted subtrees.</param>
        /// <param name="sum">The sum that have to be formed by subtree sum values.</param>
        /// <returns>A collection of all paths in subtrees.</returns>
        public List<List<int>> GetAllSubtreesWithGivenSum(Tree<int> tree, int sum)
        {
            var subtreesDictionary = this.CreateDictionaryForSubtrees(tree.Nodes.ToList());
            var rootNode = tree.ParentNode;
            subtreesDictionary[rootNode] = this.BuildSubtrees(rootNode, subtreesDictionary);

            var rootNodes = this.FilterSubtreesWithGivenSum(subtreesDictionary, sum);
            var allSubtreesWithGivenSum = this.ConnectSubtreePaths(rootNodes);
            return allSubtreesWithGivenSum;
        }
 
        private void ConnectLongestPathsInSubtree(Node<int> node, LinkedList<int> currentPath, IList<List<int>> allPaths, ref int maxLength)
        {
            currentPath.AddLast(node.Value);

            if (node.Children.Count == 0 && currentPath.Count >= maxLength)
            {
                allPaths.Add(currentPath.ToList());

                if (currentPath.Count > maxLength)
                {
                    maxLength = currentPath.Count;
                }

                return;
            }

            foreach (var childNode in node.Children)
            {
                this.ConnectLongestPathsInSubtree(childNode, currentPath, allPaths, ref maxLength);
                currentPath.RemoveLast();
            }
        }

        private void ConnectPathsWithGivenSumInTreeUsingRecursivelyDfs(Node<int> node, LinkedList<int> currentPath, IList<List<int>> allPaths, int sum)
        {
            currentPath.AddLast(node.Value);

            if (node.Children.Count == 0 && currentPath.Sum() == sum)
            {
                allPaths.Add(currentPath.ToList());
                return;
            }

            foreach (var childNode in node.Children)
            {
                this.ConnectPathsWithGivenSumInTreeUsingRecursivelyDfs(childNode, currentPath, allPaths, sum);
                currentPath.RemoveLast();
            }
        }

        private IDictionary<Node<int>, int> CreateDictionaryForSubtrees(IList<Node<int>> nodes)
        {
            var subtreesDictionary = new Dictionary<Node<int>, int>();

            foreach (var node in nodes)
            {
                subtreesDictionary[node] = node.Value;
            }

            return subtreesDictionary;
        }

        private int BuildSubtrees(Node<int> node, IDictionary<Node<int>, int> subtreesDictionary)
        {
            foreach (var childNode in node.Children)
            {
                var currentSum = this.BuildSubtrees(childNode, subtreesDictionary);
                subtreesDictionary[node] += currentSum;
            }

            return subtreesDictionary[node];
        }

        private IList<Node<int>> FilterSubtreesWithGivenSum(IDictionary<Node<int>, int> subtreesDictionary, int sum)
        {
            var rootNodesOfSubtrees = new List<Node<int>>();

            foreach (var subtree in subtreesDictionary)
            {
                if (subtree.Value == sum)
                {
                    rootNodesOfSubtrees.Add(subtree.Key);
                }
            }

            return rootNodesOfSubtrees;
        }

        private List<List<int>> ConnectSubtreePaths(IList<Node<int>> rootNodes)
        {
            var allSubtreesWithGivenSum = new List<List<int>>();

            foreach (var root in rootNodes)
            {
                var subtreePath = new List<int>();
                this.ConnectSubtreesWithGivenSumRecursivelyBfs(root, subtreePath);
                allSubtreesWithGivenSum.Add(subtreePath);
            }

            return allSubtreesWithGivenSum;
        }

        private void ConnectSubtreesWithGivenSumRecursivelyBfs(Node<int> node, IList<int> subtreePath)
        {
            var queue = new Queue<Node<int>>();
            queue.Enqueue(node);

            while (queue.Count > 0)
            {
                var currentNode = queue.Dequeue();
                subtreePath.Add(currentNode.Value);

                foreach (var childNode in currentNode.Children)
                {
                    queue.Enqueue(childNode);
                }
            }
        }
    }
}