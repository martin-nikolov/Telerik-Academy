namespace Computers.Console.TemplateMethod
{
    using System;
    using System.Linq;
    using Computers.Models.Contracts;

    public abstract class CommandExecutorTemplateMethod
    {
        /// <summary>
        /// Template method -> defines steps - abstract methods
        /// </summary>
        /// <param name="commandString"></param>
        public void Execute(string commandString)
        {
            var commandInfo = this.ParseCommand(commandString);
            this.ProcessCommand(commandInfo);
        }

        public abstract ICommandInfo ParseCommand(string commandString);
    
        public abstract void ProcessCommand(ICommandInfo commandInfo);
    }
}