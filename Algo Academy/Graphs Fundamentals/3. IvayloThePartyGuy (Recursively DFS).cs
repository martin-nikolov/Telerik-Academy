using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class IvayloThePartyGuy
{
    static List<int>[] nodes;
    static bool[] visitedNodes;

    static void Main()
    {
        #if DEBUG
            Console.SetIn(new StreamReader("../../input.txt"));
        #endif

        ParseInput();
        PrintResult();
    }

    static void ParseInput()
    {
        int n = int.Parse(Console.ReadLine());
        int m = int.Parse(Console.ReadLine());

        nodes = new List<int>[n];
        visitedNodes = new bool[n];

        for (int i = 0; i < n; i++)
            nodes[i] = new List<int>();

        for (int i = 0; i < m; i++)
        {
            var tokens = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int from = tokens[0] - 1, to = tokens[1] - 1;

            AddOrCreateNode(from, to);
            AddOrCreateNode(to, from);
        }
    }

    static void AddOrCreateNode(int from, int to)
    {
        if (nodes[from] == null)
            nodes[from] = new List<int>();

        nodes[from].Add(to);
    }

    static int GetNumberOfCouples(int node, int count)
    {
        visitedNodes[node] = true;

        for (int i = 0; i < nodes[node].Count; i++)
            if (!visitedNodes[nodes[node][i]])
                count = GetNumberOfCouples(nodes[node][i], count);

        return count + 1;
    }

    static void PrintResult()
    {
        int numberOfGroups = 0;
        var numberOfPeopleInGroups = new List<int>();

        for (int i = 0; i < nodes.Length; i++)
        {
            if (!visitedNodes[i])
            {
                numberOfPeopleInGroups.Add(GetNumberOfCouples(i, 0));
                numberOfGroups++;
            }
        }

        Console.WriteLine(numberOfGroups);
        Console.WriteLine(string.Join(" ", numberOfPeopleInGroups.OrderBy(a => a)));
    }
}