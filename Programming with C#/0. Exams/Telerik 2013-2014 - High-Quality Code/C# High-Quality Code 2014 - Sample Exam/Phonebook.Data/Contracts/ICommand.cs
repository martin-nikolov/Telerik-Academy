namespace Phonebook.Data.Contracts
{
    using System;
    using System.Linq;

    public interface ICommand
    {
        string Execute(string[] arguments);
    }
}