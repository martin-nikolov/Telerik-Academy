namespace Phonebook.Data.Loggers
{
    using System;
    using System.Linq;
    using System.Text;
    using Phonebook.Data.Contracts;

    //! Strategy pattern
    public class StringBuilderLogger : ILogger
    {
        private readonly StringBuilder output = new StringBuilder();

        public void AppendLine(string text)
        {
            this.output.AppendLine(text);
        }

        public void Accept(ILoggerVisitor visitor)
        {
            visitor.Visit(this.output.ToString());
        }
    }
}