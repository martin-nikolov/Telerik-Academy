namespace ToyStore.ConsoleClient
{
    using System;
    using System.Linq;
    using ToyStore.DataGenerators.Contracts;

    public class ConsoleLogger : ILogger
    {
        public void Log(string text)
        {
            Console.Write(text);
        }
    }
}