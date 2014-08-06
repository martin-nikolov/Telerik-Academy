namespace Phonebook.Data.Contracts
{
    using Phonebook.Models.Contracts;

    public interface ICommandFactory
    {
        ICommand Create(IPhonebookCommand commandInfo);
    }
}