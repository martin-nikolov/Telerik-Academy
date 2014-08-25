namespace TreesTraversals.FileSystem
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Numerics;

    public class FileSystemManager
    {
        private readonly IDictionary<string, Folder> subtreesByPath = new Dictionary<string, Folder>();

        /// <summary>
        /// Gets all indexed directory paths.
        /// </summary>
        public IList<string> Paths
        {
            get
            {
                return this.subtreesByPath.Keys.ToList();
            }
        }

        /// <summary>
        /// Return a Folder by given paths if exists.
        /// If the specified paths does not exists the exception is thrown.
        /// </summary>
        /// <param name="path">Path of the folder to be get.</param>
        /// <returns>An indexed Folder instance.</returns>
        public Folder this[string path]
        {
            get
            {
                return this.subtreesByPath[path];
            }
        }

        /// <summary>
        /// Traverse directory by given path and build a tree keeping all files and 
        /// folders on the hard drive starting from given startup directory path.
        /// The traverse of the directory is performed via Recursively Depth-First Search algorithm.
        /// </summary>
        /// <param name="startupDirectoryPath">The startup directory path to traverse.</param>
        public void BuildDirectoryTree(string startupDirectoryPath)
        {
            if (string.IsNullOrEmpty(startupDirectoryPath))
            {
                throw new ArgumentException("Directory path cannot be null or empty.");
            }

            if (!Directory.Exists(startupDirectoryPath))
            {
                throw new ArgumentException("Could not find a path: " + startupDirectoryPath);
            }

            var directoryInfo = new DirectoryInfo(startupDirectoryPath);
            var baseFolder = new Folder(directoryInfo.Name, directoryInfo.FullName);
            this.BuildDirectoryTreeUsingRecursivelyDfs(directoryInfo, baseFolder);
        }

        /// <summary>
        /// Gets total size in bytes for given subtree specified by directory path.
        /// </summary>
        /// <param name="directoryPath">Path represented the location of the directory.</param>
        /// <returns>Total size in bytes for the given subtree.</returns>
        public BigInteger CalculateSumOfFilesSizeInSubtree(string directoryPath)
        {
            var folder = this.subtreesByPath[directoryPath];
            return this.CalculateSumOfFilesSizeInSubtree(folder);
        }

        /// <summary>
        ///  Gets total size in bytes for the given subtree specified by instance of Folder class.
        /// </summary>
        /// <param name="folder">An instance of Folder class represented a subtree of directories.</param>
        /// <returns>Total size in bytes for the given subtree.</returns>
        public BigInteger CalculateSumOfFilesSizeInSubtree(Folder folder)
        {
            return this.GetFolderSize(folder);
        }

        private void BuildDirectoryTreeUsingRecursivelyDfs(DirectoryInfo dirInfo, Folder currentFolder)
        {
            this.AddFilesToFolder(currentFolder, dirInfo.GetFiles());
            this.subtreesByPath[currentFolder.Path] = currentFolder;

            foreach (var dir in dirInfo.GetDirectories())
            {
                try
                {
                    var folder = new Folder(dir.Name, dir.FullName);
                    currentFolder.ChildFolders.Add(folder);
                    this.BuildDirectoryTreeUsingRecursivelyDfs(dir, folder);
                }
                catch (Exception)
                {
                    continue;
                }
            }
        }

        private BigInteger GetFolderSize(Folder folder, BigInteger totalSize = new BigInteger())
        {
            totalSize += this.GetSizeOfFiles(folder.Files);

            foreach (var childFolder in folder.ChildFolders)
            {
                totalSize += this.GetFolderSize(childFolder);
            }

            return totalSize;
        }

        private BigInteger GetSizeOfFiles(IList<File> files)
        {
            BigInteger filesSize = 0;

            foreach (var file in files)
            {
                filesSize += file.Size;
            }

            return filesSize;
        }

        private void AddFilesToFolder(Folder folder, FileInfo[] files)
        {
            foreach (var file in files)
            {
                folder.Files.Add(new File(file.Name, file.Length));
            }
        }
    }
}