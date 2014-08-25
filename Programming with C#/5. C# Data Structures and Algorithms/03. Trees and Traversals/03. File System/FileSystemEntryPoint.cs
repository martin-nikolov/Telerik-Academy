/*
 * 2. Define classes File { string name, int size } and 
 * Folder { string name, File[] files, Folder[] childFolders } and using them 
 * build a tree keeping all files and folders on the hard drive starting from C:\WINDOWS. 
 * Implement a method that calculates the sum of the file sizes in given subtree 
 * of the tree and test it accordingly. 
 * Use recursive DFS traversal.
 */

namespace TreesTraversals
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using TreesTraversals.FileSystem;

    public class FileSystemEntryPoint
    {
        public static readonly Stopwatch Stopwatch = new Stopwatch();

        public const string DirectoryPath = @"C:\Program Files";

        public static void Main()
        {
            ManageFileSystem();
        }

        public static void ManageFileSystem()
        {
            Stopwatch.Start();
            {
                Console.Write("Loading...");

                var fileSystem = new FileSystemManager();
                fileSystem.BuildDirectoryTree(DirectoryPath);

                Console.WriteLine("\rTotal folders: {0}\n", fileSystem.Paths.Count);

                var baseFolder = fileSystem[DirectoryPath];
                PrintFolderInformation(baseFolder, fileSystem, prefix: "Base ");

                foreach (var childFolder in baseFolder.ChildFolders)
                {
                    PrintFolderInformation(childFolder, fileSystem, prefix: "    ");
                }
            }
            Stopwatch.Stop();

            Console.WriteLine("\nElapsed time: {0}\n", Stopwatch.Elapsed);
        }
 
        private static void PrintFolderInformation(Folder folder, FileSystemManager fileSystem, string prefix = null)
        {
            var folderSize = fileSystem.CalculateSumOfFilesSizeInSubtree(folder);
            Console.WriteLine("{2}{0} | Size: {1} bytes", folder, folderSize, prefix);
        }
    }
}