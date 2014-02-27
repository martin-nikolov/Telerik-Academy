using System.Collections;

namespace CodingPractice.Graph
{
    public class BreadthFirstSearch
    {
        private readonly IWeightedGraph graph;

        public BreadthFirstSearch(IWeightedGraph graph)
        {
            this.graph = graph;
        }

        public bool search(object startVertex, object endVertex)
        {
            return breadthFirstSearch(startVertex, endVertex);
        }

        /// <summary>
        /// returns true if path exists from startVertex to endVertex
        /// </summary>
        private bool breadthFirstSearch(object startVertex, object endVertex)
        {
            var queue = new Queue();
            var vertexQueue = new Queue();
            bool found = false;

            graph.clearMarks();
            queue.Enqueue(startVertex);

            do
            {
                object vertex = queue.Dequeue();

                if (vertex == endVertex)
                    found = true;
                else
                {
                    if (!graph.isMarked(vertex))
                    {
                        graph.markVertex(vertex);
                        vertexQueue = graph.getToVertices(vertex);

                        while (vertexQueue.Count > 0)
                        {
                            object item = vertexQueue.Dequeue();
                            if (!graph.isMarked(item))
                                queue.Enqueue(item);
                        }
                    }
                }
            } while (queue.Count > 0 & !found);


            return found;
        }
    }
}