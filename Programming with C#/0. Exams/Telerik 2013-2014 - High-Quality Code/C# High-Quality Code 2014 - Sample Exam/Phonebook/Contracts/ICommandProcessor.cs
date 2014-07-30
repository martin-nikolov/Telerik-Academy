namespace Phonebook.Contracts
{
    public interface ICommandProcessor
    {
        string ProcessCommand(ICommand command);
    }
}