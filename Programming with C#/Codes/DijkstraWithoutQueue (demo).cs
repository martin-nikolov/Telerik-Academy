using System;
using System.Collections.Generic;

namespace DijkstraWithoutQueue
{
    public class DijkstraWithoutQueue
    {
        static int[] distance = new int[10];
        static int?[] previous = new int?[10];
        static HashSet<int> setOfNodes = new HashSet<int>();

        public static void Dijkstra(int[,] graph, int source)
        {
            for (int i = 0; i < graph.GetLength(0); i++)
            {
                distance[i] = int.MaxValue;
                previous[i] = null;
                setOfNodes.Add(i);
            }

            distance[source] = 0;

            while (setOfNodes.Count != 0)
            {
                int minNode = int.MaxValue;

                foreach (var node in setOfNodes)
                {
                    if (minNode > distance[node])
                    {
                        minNode = node;
                    }
                }

                setOfNodes.Remove(minNode);

                if (minNode == int.MaxValue)
                {
                    break;
                }

                for (int i = 0; i < graph.GetLength(0); i++)
                {
                    if (graph[minNode, i] > 0)
                    {
                        int potencialDistance = distance[minNode] + graph[minNode, i];

                        if (potencialDistance < distance[i])
                        {
                            distance[i] = potencialDistance;
                            previous[i] = minNode;
                        }
                    }
                }
            }
        }

        public static void Main()
        {
            int[,] graph = new int[10, 10]{
                { 0, 23, 0, 0, 0, 0, 0, 8, 0, 0 },
                {23, 0, 0, 3, 0, 0, 34, 0, 0, 0 },
                { 0, 0, 0, 6, 0, 0, 0, 25, 0, 7 },
                { 0, 3, 6, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 10, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 10, 0, 0, 0, 0, 0 },
                { 0, 34, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 8, 0, 25, 0, 0, 0, 0, 0, 0, 30 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 7, 0, 0, 0, 0, 30, 0, 0 }
            };

            int source = 1;

            Dijkstra(graph, source - 1);

            for (int i = 0; i < distance.Length; i++)
            {
                Console.Write("Distance from 1 to {0}: ", i + 1);
                if (distance[i] == int.MaxValue)
                {
                    Console.WriteLine("No path.");
                }
                else
                {
                    Console.Write("Path: ");

                    int? indexer = i;
                    while (indexer != 0)
                    {
                        Console.Write(indexer + 1 + " ");
                        indexer = previous[indexer.Value];
                    }

                    Console.Write("1 ");

                    Console.WriteLine("Distance: " + distance[i]);
                }
            }
        }
    }
}