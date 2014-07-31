namespace Phonebook.Data
{
    using System;
    using System.Linq;
    using Phonebook.Data.Contracts;
    using Phonebook.Models;
    using Phonebook.Models.Contracts;

    public class CommandFactory : ICommandFactory
    {
        public IInputCommand Parse(string command)
        {
            if (string.IsNullOrEmpty(command))
            {
                throw new ArgumentNullException("Command string cannot be null or empty.");
            }

            int firstOpenBracket = command.IndexOf('(');
            if (firstOpenBracket == -1)
            {
                throw new ArgumentException("Invalid command parameters.");
            }

            string commandName = command.Substring(0, firstOpenBracket);
            string commandArgsString = command.Substring(firstOpenBracket + 1, command.Length - commandName.Length - 2); // Bug fixed
            var commandArgs = commandArgsString.Split(',')
                                               .Select(c => c.Trim())
                                               .ToArray();

            var parsedCommand = new InputCommand { Name = commandName, Arguments = commandArgs };
            return parsedCommand;
        }
    }
}