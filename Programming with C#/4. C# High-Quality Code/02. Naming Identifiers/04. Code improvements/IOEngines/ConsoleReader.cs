namespace Games.IOEngines
{
    using System;
    using System.Linq;
    using Games.Interfaces;

    public class ConsoleReader : IReader
    {
        public string ReadCommand()
        {
            string command = Console.ReadLine();

            return command.Trim();
        }
    }
}