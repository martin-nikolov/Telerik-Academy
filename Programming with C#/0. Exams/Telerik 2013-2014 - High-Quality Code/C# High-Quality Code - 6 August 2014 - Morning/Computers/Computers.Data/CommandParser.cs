namespace Computers.Data
{
    using System;
    using System.Linq;
    using Computers.Data.Contracts;
    using Computers.Models;
    using Computers.Models.Contracts;

    public class CommandParser : ICommandParser
    {
        private const char SplitChar = ' ';
        private const string InvalidCommandMessage = "Invalid command!";

        public ICommandInfo Parse(string text)
        {
            var arguments = text.Split(new[] { SplitChar }, StringSplitOptions.RemoveEmptyEntries);
            if (arguments.Length != 2)
            {
                throw new ArgumentException(InvalidCommandMessage);
            }

            var commandName = arguments[0];
            var commandArgument = int.Parse(arguments[1]);

            var commandInfo = new CommandInfo(commandName, commandArgument);
            return commandInfo;
        }
    }
}