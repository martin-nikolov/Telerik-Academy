using System.Collections;

namespace CodingPractice.Graph
{
    public class DepthFirstSearch
    {
        private readonly IWeightedGraph graph;

        public DepthFirstSearch(IWeightedGraph graph)
        {
            this.graph = graph;
        }

        public bool search(object startVertex, object endVertex)
        {
            return depthFirstSearch(startVertex, endVertex);
        }

        /// <summary>
        /// returns true if path exists from startVertex to endVertex
        /// </summary>
        private bool depthFirstSearch(object startVertex, object endVertex)
        {
            var stack = new Stack();
            var vertextQueue = new Queue();
            bool found = false;

            graph.clearMarks();
            stack.Push(startVertex);
            do
            {
                object vertex = stack.Pop();

                if (vertex == endVertex) // general case when path is found
                    found = true;
                else
                {
                    if (!graph.isMarked(vertex)) // if not marked
                    {
                        graph.markVertex(vertex); // then mark that vertex
                        vertextQueue = graph.getToVertices(vertex); //get all adjecent vertexes

                        while (vertextQueue.Count > 0) // then for each of those adjecent vertexes
                        {
                            object item = vertextQueue.Dequeue();

                            if (!graph.isMarked(item))
                                stack.Push(item);
                        }
                    }
                }
            } while (stack.Count > 0 && !found);

            return found;
        }
    }
}