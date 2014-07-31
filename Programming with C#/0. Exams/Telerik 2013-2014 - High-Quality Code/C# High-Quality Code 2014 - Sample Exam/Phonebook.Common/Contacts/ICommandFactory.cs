namespace Phonebook.Common.Contacts
{
    using System;
    using System.Linq;

    public interface ICommandFactory
    {
        IInputCommand Parse(string command);
    }
}