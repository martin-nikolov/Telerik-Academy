using System.Collections;

namespace CodingPractice.Graph
{
    public class WeightedGraph : IWeightedGraph
    {
        public static int NULL_EDGE;
        private readonly int[,] edges;
        private readonly bool[] marks;
        private readonly int maxVertices;
        private readonly object[] vertices;
        private int numVertices;

        public WeightedGraph()
        {
            numVertices = 0;
            maxVertices = 50;
            vertices = new object[50];
            marks = new bool[50];
            edges = new int[50,50];
        }

        public WeightedGraph(int maxV)
        {
            numVertices = 0;
            maxVertices = maxV;
            vertices = new object[maxV];
            marks = new bool[maxV];
            edges = new int[maxV,maxV];
        }

        #region Implementation of IWeightedGraph

        public bool isEmpty()
        {
            return numVertices == 0;
        }

        public bool isFull()
        {
            return maxVertices == numVertices;
        }

        /// <summary>
        /// vertex has been stored in vertices.
        /// </summary>
        public void addVertex(object vertex)
        {
            vertices[numVertices] = vertex;

            for (int i = 0; i < numVertices; i++)
            {
                edges[numVertices, i] = NULL_EDGE; // corresponding row and column of edges has been set to NULL_EDGE
                edges[i, numVertices] = NULL_EDGE;
            }

            numVertices++;
        }

        /// <summary>
        /// Edge(from vertex, to vertex) is stored in edges
        /// </summary>
        public void addEdge(object fromVertex, object toVertex, int weight)
        {
            int row;
            int column;

            row = indexIs(fromVertex);
            column = indexIs(toVertex);

            edges[row, column] = weight;
        }

        /// <summary>
        /// sets marks for all vertices to false
        /// </summary>
        public void clearMarks()
        {
            for (int i = 0; i < numVertices; i++)
            {
                marks[i] = false;
            }
        }

        /// <summary>
        /// sets mark for vertex to true
        /// </summary>
        public void markVertex(object vertex)
        {
            int index = indexIs(vertex);

            if (!isMarked(vertex))
                marks[index] = true;
        }

        /// <summary>
        /// determines if vertex has been marked or not
        /// </summary>
        public bool isMarked(object vertex)
        {
            int index = indexIs(vertex);

            return marks[index];
        }

        /// <summary>
        /// returns weight associated with the edge
        /// </summary>
        public int weightIs(object fromVertex, object toVertex)
        {
            int row = indexIs(fromVertex);
            int column = indexIs(toVertex);

            return edges[row, column];
        }

        /// <summary>
        /// returns a queue of the vertices that are adjacent from vertex
        /// </summary>
        public Queue getToVertices(object vertex)
        {
            var adjVertices = new Queue();
            int fromIndex = indexIs(vertex);

            for (int toIndex = 0; toIndex < numVertices; toIndex++)
            {
                if (edges[fromIndex, toIndex] != NULL_EDGE)
                    adjVertices.Enqueue(vertices[toIndex]);
            }
            return adjVertices;
        }

        #endregion

        /// <summary>
        /// returns index of vertex in vertices
        /// </summary>
        private int indexIs(object vertex)
        {
            int i = 0;
            while (vertex != vertices[i]) i++;
            return i;
        }
    }
}