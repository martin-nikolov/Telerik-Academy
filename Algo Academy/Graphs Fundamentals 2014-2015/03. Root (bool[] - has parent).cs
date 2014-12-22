using System;
using System.Linq;

public class Root
{
    private static bool[] graph;

    internal static void Main()
    {
        var numberOfEdges = int.Parse(Console.ReadLine());
        graph = new bool[numberOfEdges + 1];

        for (int i = 0; i < numberOfEdges; i++)
        {
            var vertices = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            graph[vertices[1]] = true; // Has parent
        }

        PrintRoot();
    }
 
    private static void PrintRoot()
    {
        for (int i = 0; i < graph.Length; i++)
        {
            if (!graph[i])
            {
                Console.WriteLine(i);
                break;
            }
        }
    }
}