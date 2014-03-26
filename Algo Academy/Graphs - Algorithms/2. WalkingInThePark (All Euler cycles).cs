using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class WalkInThePark
{
    static readonly int startupNodeIndex = 0;

    static readonly List<string> allPaths = new List<string>();
    static readonly IList<int> currentPath = new List<int>();

    static int[,] adjancencyMatrix;
    static int connections;

    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        adjancencyMatrix = new int[N, N];

        bool isEulerCandidate = InitializeMatrix();

        if (isEulerCandidate)
            FindAllEulearCycles(startupNodeIndex);

        PrintResult();
    }

    static bool InitializeMatrix()
    {
        for (int i = 0; i < adjancencyMatrix.GetLongLength(0); i++)
        {
            var input = Console.ReadLine();

            for (int j = 0; j < adjancencyMatrix.GetLongLength(1); j++)
                connections += (adjancencyMatrix[i, j] = input[j] - '0');

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
                adjancencyMatrix[nodeIndex, i] = adjancencyMatrix[i, nodeIndex] *= -1; // mark as visited
                currentPath.Add(i); // add to path so far

                FindAllEulearCycles(i);

                currentPath.RemoveAt(currentPath.Count - 1); // backtracking
                adjancencyMatrix[nodeIndex, i] = adjancencyMatrix[i, nodeIndex] *= -1; // backtracking
            }
        }
    }

    static void PrintResult()
    {
        var result = new StringBuilder();

        for (int i = 0; i < allPaths.Count; i++)
            result.AppendFormat("Route {0}: {1} {2}\n", i + 1, startupNodeIndex, allPaths[i]);

        Console.Write(result);
        Console.WriteLine("Number of routes: {0}", allPaths.Count);
    }
}