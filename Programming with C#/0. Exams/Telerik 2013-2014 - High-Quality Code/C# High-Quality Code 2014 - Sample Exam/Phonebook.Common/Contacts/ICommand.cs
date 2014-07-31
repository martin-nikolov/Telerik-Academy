namespace Phonebook.Common.Contacts
{
    using System;
    using System.Linq;

    public interface ICommand
    {
        string Execute(string[] arguments);
    }
}