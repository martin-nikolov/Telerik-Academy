using System;
using System.Collections.Generic;
using System.Linq;

class FriendsOfPesho
{
    static IList<Node>[] graph;

    static void Main()
    {
        var parameters = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        graph = Enumerable.Range(0, parameters[0]).Select(i => new List<Node>()).ToArray();

        var hospitalIds = new HashSet<int>(Console.ReadLine().Split(' ').Select(a => int.Parse(a) - 1));

        for (int i = 0; i < parameters[1]; i++)
        {
            var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int parent = input[0] - 1, child = input[1] - 1;

            graph[parent].Add(new Node(child, input[2]));
            graph[child].Add(new Node(parent, input[2]));
        }

        Console.WriteLine(FindMinSum(hospitalIds));
    }
  
    static int FindMinSum(HashSet<int> hospitalIds)
    {
        var minSum = Int32.MaxValue;

        foreach (var item in hospitalIds)
            minSum = Math.Min(minSum, FindMinimalDistance(item).Where((a, b) => !hospitalIds.Contains(b)).Sum());

        return minSum;
    }

    static IEnumerable<int> FindMinimalDistance(int source)
    {
        var queue = new Queue<Node>();
        queue.Enqueue(new Node(source, 0));

        var distances = Enumerable.Repeat(int.MaxValue, graph.Length).ToArray();
        distances[source] = 0;

        while (queue.Count != 0)
        {
            Node currentNode = queue.Dequeue();

            foreach (var neighbour in graph[currentNode.Id])
            {
                int currentDistance = distances[currentNode.Id] + neighbour.Distance;

                if (currentDistance < distances[neighbour.Id])
                {
                    distances[neighbour.Id] = currentDistance;
                    queue.Enqueue(new Node(neighbour.Id, currentDistance));
                }
            }
        }

        return distances;
    }

    struct Node
    {
        public Node(int id, int distance)
            : this()
        {
            this.Id = id;
            this.Distance = distance;
        }

        public int Id { get; set; }

        public int Distance { get; set; }
    }
}