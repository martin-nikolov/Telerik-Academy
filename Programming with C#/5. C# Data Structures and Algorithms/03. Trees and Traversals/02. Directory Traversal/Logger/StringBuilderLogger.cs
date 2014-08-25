namespace TreesTraversals.Logger
{
    using System;
    using System.Text;

    public class StringBuilderLogger : ILogger
    {
        private readonly StringBuilder output = new StringBuilder();

        public void Log(string format, params object[] parameters)
        {
            this.output.AppendLine(string.Format(format, parameters));
        }

        public string GetAllText()
        {
            return this.output.ToString();
        }
    }
}