namespace PathFinders
{
    using System;
    using System.Linq;
    using PathFinders.PathFinderStrategies;

    public class PathInLabyrinth
    {
        public static void Main()
        {
            //string[,] labyrinth = 
            //{
            //    { "0", "0", "0", "x", "0", "0", "0", },
            //    { "x", "x", "0", "x", "0", "x", "0", },
            //    { "0", "0", "0", "0", "0", "0", "0", },
            //    { "0", "x", "x", "x", "x", "x", "0", },
            //    { "0", "0", "0", "0", "0", "0", "*", }
            //};

            string[,] labyrinth = 
            {
                { "0", "0", "0", "x", "0", "x" },
                { "0", "x", "0", "x", "0", "x" },
                { "0", "*", "x", "0", "x", "0" },
                { "0", "x", "0", "0", "0", "0" },
                { "0", "0", "0", "x", "x", "0" },
                { "0", "0", "0", "x", "0", "x" }
            };

            var pathFinder = new PathFinder();

            // Using BFS Algorithm -> Queue
            var bfsLabyrinth = pathFinder.FindAllPaths(labyrinth, new BfsPathFinder());
            PrintMatrix(bfsLabyrinth, " BFS Traversal:");

            // Using DFS Algorithm -> Stack
            var dfsLabyrinth = pathFinder.FindAllPaths(labyrinth, new DfsPathFinder());
            PrintMatrix(dfsLabyrinth, " DFS Traversal:");

            // Using Recursion -> Bottom function
            var recursiveLabyrinth = pathFinder.FindAllPaths(labyrinth, new RecursivePathFinder());
            PrintMatrix(recursiveLabyrinth, " Recursively Traversal:");
        }

        public static void PrintMatrix<T>(T[,] matrix, string message)
        {
            Console.WriteLine(message + Environment.NewLine);

            for (int i = 0; i < matrix.GetLongLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLongLength(1); j++)
                {
                    Console.Write("{0,4}", matrix[i, j]);
                }

                Console.WriteLine();
            }

            Console.WriteLine("\n----------------------------------\n");
        }
    }
}