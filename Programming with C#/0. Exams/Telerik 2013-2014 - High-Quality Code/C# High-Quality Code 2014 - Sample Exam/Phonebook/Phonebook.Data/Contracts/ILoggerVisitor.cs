namespace Phonebook.Data.Contracts
{
    using System;
    using System.Linq;

    public interface ILoggerVisitor
    {
        void Visit(string text);
    }
}