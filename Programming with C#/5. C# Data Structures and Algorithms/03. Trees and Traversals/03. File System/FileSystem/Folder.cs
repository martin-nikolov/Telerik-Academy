namespace TreesTraversals.FileSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Folder
    {
        /// <summary>Initializes a new instance of the Folder
        /// class with given name and full path to the directory.</summary>
        /// <param name="name">Name of the folder</param>
        /// <param name="path">Full path directory</param>
        public Folder(string name, string path)
        {
            this.Name = name;
            this.Path = path;
            this.Files = new List<File>();
            this.ChildFolders = new List<Folder>();
        }

        /// <summary>Gets the name of the folder.</summary>
        /// <returns>The name of the folder.</returns>
        public string Name { get; set; }

        /// <summary>Gets the full path of the folder.</summary>
        /// <returns>The full path of the folder.</returns>
        public string Path { get; set; }

        /// <summary>Returns a collection of direct files from the current directory.</summary>
        /// <returns>An array of type File.</returns>
        public IList<File> Files { get; set; }

        /// <summary>Returns a collection of direct subdirectories of the current directory.</summary>
        /// <returns>An array of Folder objects.</returns>
        public IList<Folder> ChildFolders { get; set; }

        public override string ToString()
        {
            return string.Format("Folder -> '{0}' | Files: {1} | Folders: {2}",
                this.Path, this.Files.Count, this.ChildFolders.Count);
        }
    }
}