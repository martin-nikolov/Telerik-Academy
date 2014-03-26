using System;
using System.Collections.Generic;
using System.Linq;

class TheHugryTom
{
    static readonly int startupNodeIndex = 1;

    static readonly List<int[]> allPaths = new List<int[]>();
    static readonly ISet<int> currentPath = new HashSet<int>();

    static IDictionary<int, ISet<int>> nodes;
    static bool[] visited;

    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        int M = int.Parse(Console.ReadLine());

        nodes = new Dictionary<int, ISet<int>>(N);
        visited = new bool[N + 1];

        for (int i = 0; i < M; i++)
        {
            var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int parentIndex = input[0], childIndex = input[1];

            SetOrCreateKey(parentIndex, childIndex);
            SetOrCreateKey(childIndex, parentIndex);
        }

        visited[startupNodeIndex] = true; // marks startup node as visited

        FindAllHamiltonianCycles(startupNodeIndex);

        PrintResult();
    }

    /// <summary>
    /// Finds all hamiltonian cycles starting from some node
    /// </summary>
    static void FindAllHamiltonianCycles(int nodeIndex, int currentLevel = 1)
    {
        if (!nodes.ContainsKey(nodeIndex)) return;

        // Bottom of recursion
        if (nodes.Count == currentLevel && nodes[nodeIndex].Contains(startupNodeIndex))
        {
            allPaths.Add(currentPath.ToArray());
            return;
        }

        foreach (var neighbour in nodes[nodeIndex])
        {
            if (!visited[neighbour])
            {
                visited[neighbour] = true; // mask as visited
                currentPath.Add(neighbour); // add to path so far

                FindAllHamiltonianCycles(neighbour, currentLevel + 1);

                currentPath.Remove(neighbour); // backtracking
                visited[neighbour] = false; // backtracking
            }
        }
    }

    static void PrintResult()
    {
        if (allPaths.Count == 0)
        {
            Console.WriteLine(-1);
            return;
        }

        Console.WriteLine(allPaths.Count);

        allPaths.Sort((arr1, arr2) =>
        {
            int result = 0;

            for (int i = 0; i < arr1.Length; i++)
            {
                result = arr1[i].CompareTo(arr2[i]);

                if (result != 0) return result;
            }

            return result;
        });

        foreach (var path in allPaths)
            Console.WriteLine("{0} {1} {0}", startupNodeIndex, string.Join(" ", path));
    }

    static void SetOrCreateKey(int parentIndex, int childIndex)
    {
        if (!nodes.ContainsKey(parentIndex))
            nodes[parentIndex] = new HashSet<int>();

        nodes[parentIndex].Add(childIndex);
    }
}