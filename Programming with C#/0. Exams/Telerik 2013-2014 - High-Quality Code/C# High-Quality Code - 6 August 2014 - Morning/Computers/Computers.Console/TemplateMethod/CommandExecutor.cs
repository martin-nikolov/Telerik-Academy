namespace Computers.Console.TemplateMethod
{
    using System;
    using System.Linq;
    using Computers.Console.Strategy;
    using Computers.Data;
    using Computers.Data.Contracts;
    using Computers.Models.Contracts;

    public class CommandExecutor : CommandExecutorTemplateMethod
    {
        private readonly ICommandParser commandParser;
        private readonly ICommandProcessor commandProcessor;
        private readonly ILogger logger;

        // Dependency inversion
        public CommandExecutor(ICommandProcessor commandProcessor)
            : this(new CommandParser(), commandProcessor, new ConsoleLoggerWithNewLine())
        {
        }

        public CommandExecutor(ICommandParser commandParser, ICommandProcessor commandProcessor, ILogger logger)
        {
            this.commandParser = commandParser;
            this.commandProcessor = commandProcessor;
            this.logger = logger;
        }

        public override ICommandInfo ParseCommand(string commandString)
        {
            var parsedCommand = this.commandParser.Parse(commandString);
            return parsedCommand;
        }

        public override void ProcessCommand(ICommandInfo commandInfo)
        {
            this.commandProcessor.Process(commandInfo, this.logger);
        }
    }
}