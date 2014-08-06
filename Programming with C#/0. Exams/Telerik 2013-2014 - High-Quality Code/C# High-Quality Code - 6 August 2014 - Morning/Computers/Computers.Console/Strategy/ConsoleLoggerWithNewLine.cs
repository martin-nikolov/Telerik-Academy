namespace Computers.Console.Strategy
{
    using System;
    using System.Linq;
    using Computers.Data.Contracts;

    public class ConsoleLoggerWithNewLine : ILogger
    {
        public void Print(string message)
        {
            Console.WriteLine(message);
        }
    }
}