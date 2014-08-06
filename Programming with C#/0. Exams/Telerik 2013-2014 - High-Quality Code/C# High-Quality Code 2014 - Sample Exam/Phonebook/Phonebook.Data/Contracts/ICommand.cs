namespace Phonebook.Data.Contracts
{
    public interface ICommand
    {
        string Execute(string[] arguments);
    }
}