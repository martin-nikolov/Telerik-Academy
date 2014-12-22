using System;
using System.Linq;

public class Leafs
{
    private static bool[] graph;

    internal static void Main()
    {
        var numberOfEdges = int.Parse(Console.ReadLine());
        graph = new bool[numberOfEdges + 1];

        for (int i = 0; i < numberOfEdges; i++)
        {
            var vertices = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            graph[vertices[0]] = true; // Has children
        }

        PrintLeafs();
    }
 
    private static void PrintLeafs()
    {
        Console.WriteLine(graph.Count(a => !a));
        for (int i = 0; i < graph.Length; i++)
        {
            if (!graph[i])
            {
                Console.WriteLine(i);
            }
        }
    }
}