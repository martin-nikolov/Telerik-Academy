namespace Phonebook.Data.Contracts
{
    using Phonebook.Models.Contracts;

    public interface ICommandFactory
    {
        IInputCommand Parse(string command);
    }
}