namespace ProgramDioptase
{
    using System;
    using System.Linq;
    using System.Windows;
    using ProgramDioptase.Interfaces.DatabaseManager;

    public partial class App : Application
    {
        public static IFileManager FileManager = new DataManager();
        public static Resources Resources = new Resources(FileManager);
    }
}