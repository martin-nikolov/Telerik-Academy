/*
 * 2. Write a program to traverse the directory C:\WINDOWS and all its 
 * subdirectories recursively and to display all files matching the mask *.exe. 
 * Use the class System.IO.Directory.
 */

namespace TreesTraversals
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using TreesTraversals.Logger;
    using TreesTraversals.TraversalStrategies;

    public class DirectoryTraversalEntryPoint
    {
        public static readonly Stopwatch Stopwatch = new Stopwatch();

        public const string DirectoryPath = @"C:\Program Files\";

        public static void Main()
        {
            Console.Write("Click [ENTER] to start directory traversion...");
            Console.ReadKey(false);

            Stopwatch.Start();
            {
                var logger = new StringBuilderLogger();
                TraverseDirectory(DirectoryPath, new DirectoryTraversalDfs(logger));
                Console.WriteLine(logger.GetAllText());
            }
            Stopwatch.Stop();

            Console.WriteLine("Elapsed time: {0}\n", Stopwatch.Elapsed);
        }

        public static void TraverseDirectory(string directoryPath, IDirectoryTraversal directoryTraversalStrategy)
        {
            directoryTraversalStrategy.TraverseDirectory(directoryPath);
        }
    }
}