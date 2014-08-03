namespace Phonebook.Data
{
    using System;
    using System.Linq;
    using Phonebook.Data.Contracts;
    using Phonebook.Models;
    using Phonebook.Models.Contracts;

    //! Strategy
    public class CommandParser : ICommandParser
    {
        public IPhonebookCommand Parse(string command)
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
            var commandArgsCollection = commandArgsString.Split(',')
                                                         .Select(c => c.Trim())
                                                         .ToArray();

            var parsedCommand = new CommandInfo { Name = commandName, Arguments = commandArgsCollection };
            return parsedCommand;
        }
    }
}