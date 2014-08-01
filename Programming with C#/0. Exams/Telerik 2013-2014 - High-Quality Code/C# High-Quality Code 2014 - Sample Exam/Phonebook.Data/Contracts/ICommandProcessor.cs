namespace Phonebook.Data.Contracts
{
    using Phonebook.Models.Contracts;

    public interface ICommandProcessor
    {
        string ProcessCommand(IPhonebookCommand command);
    }
}