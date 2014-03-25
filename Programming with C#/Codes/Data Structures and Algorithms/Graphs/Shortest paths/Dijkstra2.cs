using System;
using System.Collections.Generic;
using System.Linq;

class DijkstraAlgorithm
{
    static IList<IList<Node>> graph = null;

    private static IList<int> FindDistances(int start)
    {
        var distances = Enumerable.Repeat(int.MaxValue, graph.Count).ToArray();

        var queue = new OrderedBag<Node>((node1, node2) =>
            node1.Distance.CompareTo(node2.Distance)
        );

        distances[start] = 0;
        queue.Add(new Node(start, 0));

        while (queue.Count != 0)
        {
            var currentNode = queue.RemoveFirst();

            foreach (var neighborNode in graph[currentNode.To])
            {
                int currentDistance = distances[currentNode.To] + neighborNode.Distance;

                if (currentDistance < distances[neighborNode.To])
                {
                    distances[neighborNode.To] = currentDistance;
                    queue.Add(new Node(neighborNode.To, currentDistance));
                }
            }
        }

        return distances;
    }
}