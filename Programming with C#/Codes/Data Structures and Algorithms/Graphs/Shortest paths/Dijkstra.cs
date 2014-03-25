using System;
using System.Collections.Generic;
using System.Linq;

class DijkstraAlgorithm
{
    public static void FindMinimalDistance(Dictionary<Node, List<Connection>> graph, Node source)
    {
        var queue = new PriorityQueue<Node>();

        foreach (var node in graph)
            node.Key.DijkstraDistance = long.MaxValue; // double.PositiveInfinity;

        queue.AddFirst(source);
        source.DijkstraDistance = 0;

        while (queue.Count != 0)
        {
            var currentNode = queue.RemoveFirst();

            // if (currentNode.DijkstraDistance == long.MaxValue) break;

            foreach (var neighbour in graph[currentNode])
            {
                var potDistance = neighbour.Distance + currentNode.DijkstraDistance;

                if (potDistance < neighbour.ToNode.DijkstraDistance)
                {
                    neighbour.ToNode.DijkstraDistance = potDistance;
                    queue.AddFirst(neighbour.ToNode);
                }
            }
        }
    }
}