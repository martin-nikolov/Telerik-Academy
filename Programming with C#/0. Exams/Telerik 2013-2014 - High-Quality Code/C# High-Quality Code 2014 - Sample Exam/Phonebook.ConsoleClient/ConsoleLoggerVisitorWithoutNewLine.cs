namespace Phonebook.ConsoleClient
{
    using System;
    using System.Linq;
    using Phonebook.Data.Contracts;

    public class ConsoleLoggerVisitorWithoutNewLine : ILoggerVisitor
    {
        public void Visit(string text)
        {
            Console.Write(text);
        }
    }
}