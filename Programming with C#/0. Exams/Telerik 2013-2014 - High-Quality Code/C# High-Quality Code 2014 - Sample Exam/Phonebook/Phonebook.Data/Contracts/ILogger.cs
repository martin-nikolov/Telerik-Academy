namespace Phonebook.Data.Contracts
{
    using System;
    using System.Linq;

    public interface ILogger
    {
        void AppendLine(string text);

        void Accept(ILoggerVisitor visitor);
    }
}