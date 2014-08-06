namespace Computers.Data
{
    using System;
    using System.Linq;
    using Computers.Data.Contracts;
    using Computers.Models.Contracts;

    public class CommandProcessor : ICommandProcessor
    {
        private const string ChargeCommandString = "Charge";
        private const string ProcessCommandString = "Process";
        private const string PlayCommandString = "Play";
        private const string InvalidCommandString = "Invalid command!";

        public CommandProcessor(IStore store)
        {
            this.Store = store;
        }

        private IStore Store { get; set; }

        public void Process(ICommandInfo command, ILogger logger)
        {
            if (command.Name == ChargeCommandString)
            {
                this.Store.Laptop.ChargeBattery(command.Argument);
            }
            else if (command.Name == ProcessCommandString)
            {
                this.Store.Server.Process(command.Argument);
            }
            else if (command.Name == PlayCommandString)
            {
                this.Store.PersonalComputer.Play(command.Argument);
            }
            else
            {
                logger.Print(InvalidCommandString);
            }
        }
    }
}