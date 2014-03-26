using System;
using System.Collections.Generic;
using System.Linq;

// Node -> Neighbours[] / Value / IsVisited

class HamiltonianCycle
{
    static IList<List<Node>> allpaths = new List<List<Node>>();
    static HashSet<Node> currentPath = new HashSet<Node>();
    static Node startNode;
    static int nodesCount = 0;

    /// <summary>
    /// Finds all hamiltonian cycles starting from some node
    /// </summary>
    public static void FindHamiltonianCycles(Node currentNode, int level)
    {
        // Found Hamiltonian cycle -> iterated over all nodes
        if (level == nodesCount)
        {
            foreach (Node neighbour in currentNode.Neighbours)
            {
                // Check if current node is connected with the startup node
                if (neighbour == startNode)
                {
                    // Add current path to all paths
                    allPaths.Add(currentPath.ToList());
                    break;
                }
            }

            return;
        }

        // For each neighbour of current node
        for (int i = 0; i < currentNode.Neighbours.Count; i++)
        {
            if (!currentNode.Neighbours[i].IsVisited)
            {
                currentNode.Neighbours[i].IsVisited = true;

                currentPath.Add(currentNode.Neighbours[i]);
                FindHamiltonianCycles(currentNode.Neighbours[i], level + 1);
                currentPath.Remove(currentNode.Neighbours[i]);

                currentNode.Neighbours[i].IsVisited = false; // backtracking
            }
        }
    }   
}