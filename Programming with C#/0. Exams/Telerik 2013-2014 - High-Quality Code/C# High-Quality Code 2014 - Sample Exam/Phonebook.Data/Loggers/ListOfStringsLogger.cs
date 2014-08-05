namespace Phonebook.Data.Loggers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Phonebook.Data.Contracts;

    //! Strategy pattern
    public class ListOfStringsLogger : ILogger
    {
        private readonly IList<string> output = new List<string>();

        public void AppendLine(string text)
        {
            this.output.Add(text);
        }

        public void Accept(ILoggerVisitor visitor)
        {
            var output = string.Join(Environment.NewLine, this.output);
            visitor.Visit(output);
        }
    }
}