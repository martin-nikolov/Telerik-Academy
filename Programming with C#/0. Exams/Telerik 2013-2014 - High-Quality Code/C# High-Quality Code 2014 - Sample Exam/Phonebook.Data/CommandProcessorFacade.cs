namespace Phonebook.Data
{
    using System;
    using System.Linq;
    using Phonebook.Data.Contracts;
    using Phonebook.Data.Factories;

    //! Facade
    public class CommandProcessorFacade : ICommandProcessor
    {
        private readonly ICommandParser commandParser;
        private readonly ICommandFactory commandFactory;

        //! Dependency inversion
        public CommandProcessorFacade()
            : this(new CommandParser(), new CommandFactoryWithLazyLoading())
        {
        }

        // TODO: Validation
        public CommandProcessorFacade(ICommandParser commandParser, ICommandFactory commandFactory)
        {
            this.commandParser = commandParser;
            this.commandFactory = commandFactory;
        }

        public string ProcessCommand(string @string)
        {
            var commandInfo = this.commandParser.Parse(@string);
            var command = this.commandFactory.Create(commandInfo);
            var commandResultMessage = command.Execute(commandInfo.Arguments);
            return commandResultMessage;
        }
    }
}