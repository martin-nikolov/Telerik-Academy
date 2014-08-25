namespace TreesTraversals.FileSystem
{
    using System;
    using System.Linq;
    using System.Numerics;

    public class File
    {
        /// <summary>Initializes a new instance of the File
        /// class with given name and size in bytes.</summary>
        /// <param name="name">Name of the file</param>
        /// <param name="size">Size in bytes</param>
        public File(string name, BigInteger size)
        {
            this.Name = name;
            this.Size = size;
        }

        /// <summary>Gets the name of the file.</summary>
        /// <returns>The name of the file.</returns>
        public string Name { get; set; }

        /// <summary>Gets the size, in bytes, of the current file.</summary>
        /// <returns>The size of the current file in bytes.</returns>
        public BigInteger Size { get; set; }

        public override string ToString()
        {
            return string.Format("File '{0}' | Size: {1} bytes", this.Name, this.Size);
        }
    }
}