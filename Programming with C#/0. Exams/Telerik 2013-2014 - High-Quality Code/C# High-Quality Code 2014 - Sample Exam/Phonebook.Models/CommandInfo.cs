namespace Phonebook.Models
{
    using System;
    using Phonebook.Models.Contracts;

    public class CommandInfo : IPhonebookCommand
    {
        private string name;
        private string[] arguments;

        public string Name
        {
            get 
            { 
                return this.name; 
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Command name cannot be null or empty.");
                }

                this.name = value;
            }
        }

        public string[] Arguments
        {
            get 
            { 
                return this.arguments; 
            }

            set
            {
                if (value == null || value.Length == 0)
                {
                    throw new NullReferenceException("Command arguments cannot be null or empty.");
                }

                this.arguments = value;
            }
        }
    }
}