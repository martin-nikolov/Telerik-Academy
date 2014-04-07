using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

class MaximalPathInTree
{
    static readonly Dictionary<int, List<int>> adjacencyList = new Dictionary<int, List<int>>();
    static readonly HashSet<int> visitedVertex = new HashSet<int>();

    static void Main()
    {
        #if DEBUG
            Console.SetIn(new StreamReader("../../input.txt"));
        #endif

        ParseInput();

        Console.WriteLine(FindMaximalPath());
    }

    static void ParseInput()
    {
        var n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n - 1; i++)
        {
            var connection = Console.ReadLine();        
            var match = Regex.Matches(connection, @"\d+");

            var parent = int.Parse(match[0].Value);
            var child = int.Parse(match[1].Value);

            AddConnection(parent, child);
        }
    }

    static IEnumerable<int> GetLeaves()
    {
        return adjacencyList.Where(a => a.Value.Count == 1).Select(a => a.Key);
    }

    static void AddConnection(int from, int to)
    {
        AddOrMakeConnection(from, to);
        AddOrMakeConnection(to, from);
    }

    static void AddOrMakeConnection(int from, int to)
    {
        if (!adjacencyList.ContainsKey(from))
            adjacencyList[from] = new List<int>();

        adjacencyList[from].Add(to);
    }

    static long FindMaximalPath()
    {
        var leaves = GetLeaves();
        var maximalSum = long.MinValue;

        foreach (var leaf in leaves)
        {
            visitedVertex.Clear();
            maximalSum = Math.Max(FindMaximalPath(leaf), maximalSum);
        }

        return maximalSum;
    }

    static long FindMaximalPath(int leafValue)
    {
        visitedVertex.Add(leafValue);

        long currentSum = 0;

        foreach (var child in adjacencyList[leafValue])
        {
            if (visitedVertex.Contains(child))
                continue;

            currentSum = Math.Max(currentSum, FindMaximalPath(child));
        }

        return leafValue + currentSum;
    }
}