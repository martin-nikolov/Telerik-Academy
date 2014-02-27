using System;
using System.Collections;
using CodingPractice.Heap;

namespace CodingPractice.Graph
{
    public class ShortestPathSearch
    {
        private readonly IWeightedGraph graph;

        public ShortestPathSearch(IWeightedGraph graph)
        {
            this.graph = graph;
        }

        public void printShortestPath(object startVertex)
        {
            shortestPathSearch(startVertex);
        }

        private void shortestPathSearch(object startVertex)
        {
            Flights item;
            Flights saveItem;
            int minDistance;

            IPriorityQueue pq = new MinHeap();
            object vertex;
            var vertextQueue = new Queue();

            graph.clearMarks();
            saveItem = new Flights
                           {
                               FromVertex = startVertex,
                               ToVertex = startVertex,
                               Distance = 0
                           };

            pq.enqueue(saveItem);

            Console.WriteLine("Last Vertex  Destination  Distance");
            Console.WriteLine("-----------------------------------");

            do
            {
                item = (Flights) pq.dequeue();

                if (!graph.isMarked(item.ToVertex))
                {
                    graph.markVertex(item.ToVertex);
                    Console.Write(item.FromVertex);
                    Console.Write("  ");
                    Console.Write(item.ToVertex);
                    Console.WriteLine("   " + item.Distance);
                    item.FromVertex = item.ToVertex;
                    minDistance = item.Distance;
                    vertextQueue = graph.getToVertices(item.FromVertex);

                    while (vertextQueue.Count > 0)
                    {
                        vertex = vertextQueue.Dequeue();
                        if (!graph.isMarked(vertex))
                        {
                            saveItem = new Flights
                                           {
                                               FromVertex = item.FromVertex,
                                               ToVertex = vertex,
                                               Distance = minDistance + graph.weightIs(item.FromVertex, vertex)
                                           };
                            pq.enqueue(saveItem);
                        }
                    }
                }
            } while (!pq.isEmpty());
        }
    }

    internal class Flights : IComparable
    {
        public int Distance { get; set; }
        public object FromVertex { get; set; }
        public object ToVertex { get; set; }

        #region Implementation of IComparable

        public int CompareTo(object otherFlights)
        {
            var other = (Flights) otherFlights;
            return (other.Distance - Distance);
        }

        #endregion
    }
}