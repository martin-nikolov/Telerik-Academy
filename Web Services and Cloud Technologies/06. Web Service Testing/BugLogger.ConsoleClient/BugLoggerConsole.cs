namespace BugLogger.ConsoleClient
{
    using System;
    using System.Linq;
    using BugLogger.Data;
    using BugLogger.Data.Contracts;

    public class BugLoggerConsole
    {
        private static readonly IBugLoggerData bugLoggerData = new BugLoggerData();

        internal static void Main()
        {
            Console.WriteLine("Number of bugs: {0}", bugLoggerData.Bugs.All().Count());
        }
    }
}