namespace Phonebook.ConsoleClient.Visitors
{
    using System;
    using System.Linq;
    using Phonebook.Data.Contracts;

    //! Visitor pattern
    public class ConsoleLoggerVisitorWithNewLine : ILoggerVisitor
    {
        public void Visit(string text)
        {
            Console.WriteLine(text);
        }
    }
}