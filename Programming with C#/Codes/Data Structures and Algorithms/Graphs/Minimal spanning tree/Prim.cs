// Graph must be connected
// Edge -> StartNode / EndNode / Weight

class PrimAlgorithm
{
    public static IList<Edge> Edges;
    public static List<Edge> MpdNodes = new List<Edge>();

    static PriorityQueue<Edge> queue = new PriorityQueue<Edge>();
    static bool[] visitedNodes;

    public static void FindMinimumSpanningTree()
    {
        visitedNodes = new bool[Edges.Count + 1];

        // Get childs of startup node
        for (int i = 0; i < Edges.Count; i++)
            if (Edges[i].StartNode == Edges[0].StartNode)
                queue.Add(Edges[i]);

        visitedNodes[Edges[0].StartNode] = true;

        while (queue.Count > 0)
        {
            Edge edge = queue.RemoveFirst();

            if (!visitedNodes[edge.EndNode])
            {
                visitedNodes[edge.EndNode] = true;
                MpdNodes.Add(edge);
                AddEdges(edge);
            }
        }
    }

    static void AddEdges(Edge edge)
    {
        for (int i = 0; i < Edges.Count; i++)
            if (!MpdNodes.Contains(Edges[i]))
                if (edge.EndNode == Edges[i].StartNode && !visitedNodes[Edges[i].EndNode])
                    queue.Add(Edges[i]);
    }
}