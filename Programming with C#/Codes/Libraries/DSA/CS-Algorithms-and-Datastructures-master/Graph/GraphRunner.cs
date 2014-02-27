using System;

namespace CodingPractice.Graph
{
    public static class GraphRunner
    {
        public static void run()
        {
            var graph = new WeightedGraph();
            graph.addVertex("Atlanta");
            graph.addVertex("Austin");
            graph.addVertex("Chicago");
            graph.addVertex("Dallas");
            graph.addVertex("Denver");
            graph.addVertex("Houston");
            graph.addVertex("Washington");

            graph.addEdge("Atlanta", "Houston", 800);
            graph.addEdge("Atlanta", "Washington", 600);

            graph.addEdge("Austin", "Dallas", 200);
            graph.addEdge("Austin", "Houston", 160);

            graph.addEdge("Chicago", "Denver", 1000);

            graph.addEdge("Dallas", "Austin", 200);
            graph.addEdge("Dallas", "Chicago", 900);
            graph.addEdge("Dallas", "Denver", 780);

            graph.addEdge("Denver", "Atlanta", 1400);
            graph.addEdge("Denver", "Chicago", 1000);

            graph.addEdge("Houston", "Atlanta", 800);

            graph.addEdge("Washington", "Atlanta", 600);
            graph.addEdge("Washington", "Dallas", 1300);

            var depthFirstSearch = new DepthFirstSearch(graph);
            var breadthFirstSearch = new BreadthFirstSearch(graph);
            var shortestPathSearch = new ShortestPathSearch(graph);

            //Console.WriteLine(depthFirstSearch.search("Austin", "Atlanta"));
            //Console.WriteLine(breadthFirstSearch.search("Austin", "Atlanta"));

            shortestPathSearch.printShortestPath("Washington");

            //graph.addEdge(1,3,200);
            //graph.addEdge(1,5,160);

            //graph.addEdge(2,4,1000);

            //graph.addEdge(3,1,200);
            //graph.addEdge(3,2,900);
            //graph.addEdge(3,4,780);

            //graph.addEdge(4,0,1400);
            //graph.addEdge(4,2,1000);

            //graph.addEdge(5,0,800);

            //graph.addEdge(6,0,600);
            //graph.addEdge(6,3,1300);
        }
    }
}