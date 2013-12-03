using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

public static class DirectoryTraversers
{
    ///<summary>
    /// Sample class, which traverses given directory
    /// based on the Breath-First-Search (BFS) algorithm
    /// 
    /// Sample class, which traverses recursively given directory
    /// based on the Depth-First-Search (DFS) algorithm
    ///</summary>
    public static void Main()
    {
        Console.OutputEncoding = Encoding.Unicode;
        //TraverseDirBFS("D:\\");
        TraverseDirDFS("D:\\");
    }

    ///<summary>
    /// Traverses and prints given directory with BFS
    ///</summary>
    ///<param name="directoryPath">the path to the directory
    /// which should be traversed</param>
    public static void TraverseDirBFS(string directoryPath)
    {
        Queue<DirectoryInfo> visitedDirsQueue = new Queue<DirectoryInfo>();
        visitedDirsQueue.Enqueue(new DirectoryInfo(directoryPath));

        while (visitedDirsQueue.Count > 0)
        {
            try
            {
                DirectoryInfo currentDir = visitedDirsQueue.Dequeue();
                Console.WriteLine(currentDir.FullName);
                DirectoryInfo[] children = currentDir.GetDirectories();
                
                foreach (DirectoryInfo child in children)
                {
                    visitedDirsQueue.Enqueue(child);
                }
            }
            catch (UnauthorizedAccessException)
            {
                continue;
            }
        }
    }

    ///<summary>
    /// Traverses and prints given directory recursively
    ///</summary>
    ///<param name="directoryPath">the path to the directory
    /// whichshould be traversed</param>
    public static void TraverseDirDFS(string directoryPath)
    {
        TraverseDirDFS(new DirectoryInfo(directoryPath), string.Empty);
    }

    ///<summary>
    /// Traverses and prints given directory recursively
    ///</summary>
    ///<param name="dir">the directory to be traversed</param>
    ///<param name="spaces">the spaces used for representation
    /// of the parent-child relation</param>
    private static void TraverseDirDFS(DirectoryInfo dir, string spaces)
    {
        // Visit the current directory
        Console.WriteLine(spaces + dir.FullName);

        DirectoryInfo[] children = dir.GetDirectories();

        // For each child go and visit its subtree
        foreach (DirectoryInfo child in children)
        {
            try
            {
                TraverseDirDFS(child, spaces + "  ");
            }
            catch (UnauthorizedAccessException)
            {
                continue;
            }
        }
    }
}