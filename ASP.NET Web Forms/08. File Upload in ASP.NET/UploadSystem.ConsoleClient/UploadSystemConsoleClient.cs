namespace UploadSystem.ConsoleClient
{
    using System;
    using System.Linq;
    using UploadSystem.Data;

    public class UploadSystemConsoleClient
    {
        private static readonly UploadSystemDbContext uploadSystemDbContext = new UploadSystemDbContext();

        internal static void Main()
        {
            var files = uploadSystemDbContext.ZipFileContent
                                             .Select(a => a.Content);

            Console.WriteLine(string.Join("\n\n", files));
        }
    }
}