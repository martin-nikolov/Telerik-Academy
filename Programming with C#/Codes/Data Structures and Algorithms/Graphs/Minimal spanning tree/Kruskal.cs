// Graph may not be connected
// Edge -> StartNode / EndNode / Weight

class KruskalAlgorithm
{
    public static List<Edge> Edges = new List<Edge>(); // must be sorted
    public static List<Edge> MpdNodes = new List<Edge>();
    public static int InitialNodeValue = 1;

    static int[] tree;

    public static int FindMinimumSpanningTree()
    {
        tree = new int[Edges.Count];
        Edges.Sort(); // sorting ...

        foreach (var edge in Edges)
        {
            if (tree[edge.StartNode] == 0) // not visited
            {
                if (tree[edge.EndNode] == 0) // both ends are not visited
                {
                    tree[edge.StartNode] = tree[edge.EndNode] = InitialNodeValue;
                    InitialNodeValue++;
                }
                else
                {
                    // attach the start node to the tree of the end node
                    tree[edge.StartNode] = tree[edge.EndNode];
                }

                MpdNodes.Add(edge);
            }
            else // the start is part of a tree
            {
                if (tree[edge.EndNode] == 0)
                {
                    //attach the end node to the tree;
                    tree[edge.EndNode] = tree[edge.StartNode];
                    MpdNodes.Add(edge);
                }
                else if (tree[edge.EndNode] != tree[edge.StartNode]) // combine the trees
                {
                    int oldTreeNumber = tree[edge.EndNode];

                    for (int i = 0; i < tree.Length; i++)
                        if (tree[i] == oldTreeNumber)
                            tree[i] = tree[edge.StartNode];

                    MpdNodes.Add(edge);
                }
            }
        }

        return InitialNodeValue;
    }
}