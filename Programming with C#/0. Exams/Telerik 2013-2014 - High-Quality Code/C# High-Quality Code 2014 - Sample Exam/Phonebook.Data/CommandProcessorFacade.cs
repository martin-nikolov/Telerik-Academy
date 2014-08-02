namespace Phonebook.Data
{
    using System;
    using System.Linq;
    using Phonebook.Data.Contracts;
    using Phonebook.Data.Factories;

    //! Facade
    public class CommandProcessorFacade : ICommandProcessor
    {
        private ICommandParser commandParser;
        private ICommandFactory commandFactory;

        //! Dependency inversion
        public CommandProcessorFacade()
            : this(new CommandParser(), new CommandFactoryWithLazyLoading())
        {
        }

        // TODO: Validation
        public CommandProcessorFacade(ICommandParser commandParser, ICommandFactory commandFactory)
        {
            this.CommandParser = commandParser;
            this.CommandFactory = commandFactory;
        }

        private ICommandParser CommandParser
        {
            get
            {
                return this.commandParser;
            }

            set
            { 
                if (value == null)
                {
                    throw new NullReferenceException("Command Parser object instance cannot be null.");
                }

                this.commandParser = value;
            }
        }

        private ICommandFactory CommandFactory
        {
            get
            {
                return this.commandFactory;
            }

            set
            {
                if (value == null)
                {
                    throw new NullReferenceException("Command Factory object instance cannot be null.");
                }
                
                this.commandFactory = value;
            }
        }

        public string ProcessCommand(string @string)
        {
            var commandInfo = this.CommandParser.Parse(@string);
            var command = this.CommandFactory.Create(commandInfo);
            var commandResultMessage = command.Execute(commandInfo.Arguments);
            return commandResultMessage;
        }
    }
}