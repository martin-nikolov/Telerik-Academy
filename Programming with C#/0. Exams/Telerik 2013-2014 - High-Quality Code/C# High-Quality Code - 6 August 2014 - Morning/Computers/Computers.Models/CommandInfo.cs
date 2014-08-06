namespace Computers.Models
{
    using System;
    using System.Linq;
    using Computers.Models.Contracts;

    public class CommandInfo : ICommandInfo
    {
        private string name;
        private int number;

        public CommandInfo(string name, int number)
        {
            this.Name = name;
            this.Argument = number;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.name = value;
            }
        }

        public int Argument
        {
            get
            {
                return this.number;
            }

            set
            {
                this.number = value;
            }
        }
    }
}