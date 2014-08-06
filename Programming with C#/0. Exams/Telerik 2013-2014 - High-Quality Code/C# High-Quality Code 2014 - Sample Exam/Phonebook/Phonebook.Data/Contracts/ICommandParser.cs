namespace Phonebook.Data.Contracts
{
    using Phonebook.Models.Contracts;

    public interface ICommandParser
    {
        IPhonebookCommand Parse(string command);
    }
}