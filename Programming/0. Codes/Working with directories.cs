using System;
using System.IO;

namespace WorkingWithDirectories
{
    class Drive
    {
        private System.IO.DriveInfo info;

        // - Constructor
        public Drive(String path)
        {
            info = new System.IO.DriveInfo(path);
        }

        // - Getters
        public System.IO.DriveInfo get()
        {
            return this.info;
        }

        public long getAvailableFreeSpace()
        {
            return this.info.AvailableFreeSpace;
        }

        public string getDriveFormat()
        {
            return this.info.DriveFormat;
        }

        public bool getIsReady()
        {
            return this.info.IsReady;
        }

        public string getName()
        {
            return this.info.Name;
        }

        public System.IO.DirectoryInfo getRootDirectory()
        {
            return this.info.RootDirectory;
        }

        public long getTotalFreeSpace()
        {
            return this.info.TotalFreeSpace;
        }

        public long getTotalSize()
        {
            return this.info.TotalSize;
        }

        public string getTotalVolumeLabel()
        {
            if (this.info.VolumeLabel != "")
                return this.info.VolumeLabel;
            else
                return "None";
        }
    }

    class Directory
    {
        private System.IO.FileInfo[] files;
        private System.IO.DirectoryInfo[] subDirs;

        public Directory(DirectoryInfo dir)
        {
            this.files = dir.GetFiles("*.*");
            this.subDirs = dir.GetDirectories("*.*");
        }

        // Getters
        public System.IO.FileInfo[] getFiles()
        {
            return this.files;
        }

        public System.IO.DirectoryInfo[] getSubDirectories()
        {
            return this.subDirs;
        }

        // Iterables
        public System.Collections.IEnumerable yieldFiles()
        {
            foreach (var file in this.files)
                yield return file;
        }

        public System.Collections.IEnumerable yieldSubDirectories()
        {
            foreach (var dir in this.subDirs)
                yield return dir;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Drive drive = new Drive(@"C:\");
            Console.WriteLine("Drive Class Test");
            Console.WriteLine("Available Free: " + drive.getAvailableFreeSpace());
            Console.WriteLine("Format: " + drive.getDriveFormat());
            Console.WriteLine("IsReady: " + drive.getIsReady());
            Console.WriteLine("Name: " + drive.getName());
            //There are few more things you can do with the root dir...
            Console.WriteLine("Root Dir Creation Time: " + drive.getRootDirectory().CreationTime);
            Console.WriteLine("Total Free: " + drive.getTotalFreeSpace());
            Console.WriteLine("Total Size: " + drive.getTotalSize());
            Console.WriteLine("Volume Lable: " + drive.getTotalVolumeLabel());

            Console.WriteLine();
            Console.WriteLine("Directory Class Test");

            Directory dir = new Directory(drive.getRootDirectory());

            Console.WriteLine("Files in " + drive.getName());
            foreach (var file in dir.getFiles())
                Console.WriteLine(file);

            Console.WriteLine("Sub-Directories in " + drive.getName());
            foreach (var sub in dir.yieldSubDirectories())
                Console.WriteLine(sub);

            Console.ReadLine();
        }
    }
}