namespace Phonebook.ConsoleClient
{
    using System;
    using System.Linq;
    using Phonebook.Data.Contracts;

    public class ConsoleLoggerVisitorWithNewLine : ILoggerVisitor
    {
        public void Visit(string text)
        {
            Console.WriteLine(text);
        }
    }
}