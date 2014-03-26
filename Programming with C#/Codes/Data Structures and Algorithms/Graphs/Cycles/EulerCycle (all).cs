using System;
using System.Collections.Generic;
using System.Linq;

class EulearCycle
{
    static readonly List<string> allPaths = new List<string>();
    static readonly IList<int> currentPath = new List<int>();

    static int[,] adjancencyMatrix;
    static int connections; // total number of connections
    
    static bool IsEulearCandidate()
    {
        for (int i = 0; i < adjancencyMatrix.GetLongLength(0); i++)
        {
            for (int j = 0; j < adjancencyMatrix.GetLongLength(1); j++)
                connections += adjancencyMatrix[i, j];

            if (connections % 2 != 0) return false;
        }

        return true;
    }

    /// <summary>
    /// Finds all eulear cycles starting from some node
    /// </summary>
    static void FindAllEulearCycles(int nodeIndex)
    {
        if (currentPath.Count == connections / 2)
        {
            allPaths.Add(string.Join(" ", currentPath));
            return;
        }

        for (int i = 0; i < adjancencyMatrix.GetLongLength(0); i++)
        {
            if (adjancencyMatrix[nodeIndex, i] > 0)
            {
                adjancencyMatrix[nodeIndex, i] = adjancencyMatrix[i, nodeIndex] *= - 1; // mark as visited
                currentPath.Add(i); // add to path so far

                FindAllEulearCycles(i);

                currentPath.RemoveAt(currentPath.Count - 1); // backtracking
                adjancencyMatrix[nodeIndex, i] = adjancencyMatrix[i, nodeIndex] *= -1; // backtracking
            }
        }
    }
}