/*
 * 3. You are given a cable TV company. The company needs to lay cable to 
 * a new neighborhood (for every house). If it is constrained to bury the
 * cable only along certain paths, then there would be a graph representing
 * which points are connected by those paths. But the cost of some of the 
 * paths is more expensive because they are longer. If every house is a 
 * node and every path from house to house is an edge, find a way to 
 * minimize the cost for cables.
 */

namespace AlgoAcademy
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    /// <summary>
    /// Using Kruskal to find Minimal Spanning Tree
    /// </summary>
    public class TvCompany
    {
        private static Tuple<int, int, int>[] paths;
        private static ISet<int> houses;

        internal static void Main()
        {
            #if DEBUG
            Console.SetIn(new StreamReader("../../input.txt"));
            #endif

            ParseInput();

            Console.WriteLine(string.Join(Environment.NewLine,
                paths.Select(a => string.Format("[{0} {1} -> {2}]", a.Item1, a.Item2, a.Item3))));

            var allTrees = RepresendEachNodeAsTree();

            double result = FindMinimalCost(allTrees);

            Console.WriteLine("\nMinimal cost for cable: " + result);
        }

        private static HashSet<ISet<int>> RepresendEachNodeAsTree()
        {
            var allTrees = new HashSet<ISet<int>>();

            // Represend each node as tree
            foreach (var node in houses)
            {
                var tree = new HashSet<int>();
                tree.Add(node);

                allTrees.Add(tree);
            }

            return allTrees;
        }

        private static double FindMinimalCost(HashSet<ISet<int>> allTrees)
        {
            // Kruskal -> Sorting edges by their weight
            Array.Sort(paths, (a, b) => a.Item3.CompareTo(b.Item3));

            double result = 0;

            foreach (var path in paths)
            {
                var tree1 = allTrees.Where(tree => tree.Contains(path.Item1)).First();
                var tree2 = allTrees.Where(tree => tree.Contains(path.Item2)).First();

                // Elements are in same tree
                if (tree1.Equals(tree2)) continue;

                result += path.Item3;

                tree1.UnionWith(tree2);
                allTrees.Remove(tree2);

                // Small optimization
                if (allTrees.Count == 1) break;
            }

            return result;
        }

        private static void ParseInput()
        {
            int N = int.Parse(Console.ReadLine());
            paths = new Tuple<int, int, int>[N];
            houses = new HashSet<int>();

            for (int i = 0; i < N; i++)
            {
                var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

                paths[i] = new Tuple<int, int, int>(input[0], input[1], input[2]);
                houses.Add(input[0]);
                houses.Add(input[1]);
            }
        }
    }
}