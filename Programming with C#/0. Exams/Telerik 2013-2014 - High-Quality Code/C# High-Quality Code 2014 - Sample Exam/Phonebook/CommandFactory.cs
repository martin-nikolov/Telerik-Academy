namespace Phonebook
{
    using System;
    using System.Linq;
    using Phonebook.Contracts;

    public class CommandFactory : ICommandFactory
    {
        public ICommand Parse(string command)
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
            string commandArgsString = command.Substring(firstOpenBracket + 1, command.Length - commandName.Length - 2);
            var commandArgs = commandArgsString.Split(',')
                                               .Select(c => c.Trim())
                                               .ToArray();

            var parsedCommand = new Command { Name = commandName, Arguments = commandArgs };
            return parsedCommand;
        }
    }
}