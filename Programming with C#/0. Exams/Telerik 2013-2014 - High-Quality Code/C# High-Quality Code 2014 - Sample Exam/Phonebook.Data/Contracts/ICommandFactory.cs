namespace Phonebook.Data.Contracts
{
    using System;
    using System.Linq;
    using Phonebook.Models.Contracts;

    public interface ICommandFactory
    {
        IInputCommand Parse(string command);
    }
}