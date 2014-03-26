using System;
using System.Collections.Generic;
using System.Linq;

class KruskalAlgorithm
{
    static void Main()
    {
        int N = // ...

        var allTrees = new HashSet<HashSet<int>>();
        var edges = new Tuple<int, int, int>[N];
        var nodes = new HashSet<int>();

        // Initialization -> edges / nodes
        
        // Represend each node as tree
        foreach (var node in nodes)
        {
            var tree = new HashSet<int>();
            tree.Add(node);

            allTrees.Add(tree);
        }

        // Sorting edges by their weight
        Array.Sort(edges, (a, b) => a.Item3.CompareTo(b.Item3));

        double result = 0; // Minimal spanning tree distance

        foreach (var edge in edges)
        {
            var tree1 = allTrees.Where(tree => tree.Contains(edge.Item1)).First();
            var tree2 = allTrees.Where(tree => tree.Contains(edge.Item2)).First();

            // Elements are in same tree
            if (tree1.Equals(tree2)) continue;

            result += edge.Item3;

            // Combine trees
            tree1.UnionWith(tree2);
            allTrees.Remove(tree2);

            // Small optimization
            if (allTrees.Count == 1) break;
        }

        Console.WriteLine(result);
    }
}