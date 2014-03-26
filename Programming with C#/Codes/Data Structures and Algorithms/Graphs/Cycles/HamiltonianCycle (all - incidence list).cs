using System;
using System.Collections.Generic;
using System.Linq;

class HamiltonianCycle
{
    static readonly List<int[]> allPaths = new List<int[]>();
    static readonly ISet<int> currentPath = new HashSet<int>();

    static IDictionary<int, ISet<int>> nodes;
    static bool[] visited;

    // -> visited[startupNodeIndex] = true; // marks startup node as visited

    /// <summary>
    /// Finds all hamiltonian cycles starting from some node
    /// </summary>
    static void FindAllHamiltonianCycles(int nodeIndex, int currentLevel = 1)
    {
        if (!nodes.ContainsKey(nodeIndex))
            return;

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
}