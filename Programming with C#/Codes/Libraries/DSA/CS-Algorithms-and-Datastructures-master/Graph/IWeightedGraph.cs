using System.Collections;

namespace CodingPractice.Graph
{
    public interface IWeightedGraph
    {
        bool isEmpty();
        bool isFull();
        void addVertex(object vertex);
        void addEdge(object fromVertex, object toVertex, int weight);
        void clearMarks();
        void markVertex(object vertex);
        bool isMarked(object vertex);
        int weightIs(object fromVertex, object toVertex);
        Queue getToVertices(object vertex);
    }
}