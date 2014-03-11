namespace PathFinder
{
    using System;
    using System.Linq;
    using PathFinders;

    class PathInLabyrinth
    {
        static void Main()
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

            // Using BFS Algorithm -> Queue
            var bfsLabyrinth = BfsPathFinder.FindAllPaths((string[,])labyrinth.Clone());
            PrintMatrix(bfsLabyrinth, " BFS Traversal:");

            /* ----------------------------------- */

            // Using DFS Algorithm -> Stack
            var dfsLabyrinth = DfsPathFinder.FindAllPaths((string[,])labyrinth.Clone());
            PrintMatrix(dfsLabyrinth, " DFS Traversal:");

            /* ----------------------------------- */

            // Using recursion with bottom function
            var recursiveLabyrinth = RecursivePathFinder.FindAllPaths((string[,])labyrinth.Clone());
            PrintMatrix(recursiveLabyrinth, " Recursively Traversal:");
        }

        static void PrintMatrix<T>(T[,] matrix, string message)
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