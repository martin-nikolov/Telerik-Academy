using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

class Tasks : IComparer<Tuple<string, int>>
{
    static readonly OrderedBag<Tuple<string, int>> orderedBag = new OrderedBag<Tuple<string, int>>(new Tasks());

    public static void Main()
    {
        int N = int.Parse(Console.ReadLine());

        for (int i = 0; i < N; i++)
            ExecuteCommand(Console.ReadLine().Split(' ').ToArray());
    }

    public int Compare(Tuple<string, int> x, Tuple<string, int> y)
    {
        var priorityComparison = x.Item2.CompareTo(y.Item2);

        return priorityComparison == 0 ? x.Item1.CompareTo(y.Item1) : priorityComparison;
    }

    static void ExecuteCommand(string[] tokens)
    {
        switch (tokens[0])
        {
            case "New": orderedBag.Add(Tuple.Create(tokens[2], int.Parse(tokens[1]))); break;
            case "Solve": Console.WriteLine(orderedBag.Count > 0 ? orderedBag.RemoveFirst().Item1 : "Rest"); break;
        }
    }
}