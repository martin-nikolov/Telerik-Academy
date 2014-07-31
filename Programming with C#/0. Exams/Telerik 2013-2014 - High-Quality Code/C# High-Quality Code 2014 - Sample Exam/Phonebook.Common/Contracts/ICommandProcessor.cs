namespace Phonebook.Common.Contracts
{
    public interface ICommandProcessor
    {
        string ProcessCommand(ICommand command);
    }
}