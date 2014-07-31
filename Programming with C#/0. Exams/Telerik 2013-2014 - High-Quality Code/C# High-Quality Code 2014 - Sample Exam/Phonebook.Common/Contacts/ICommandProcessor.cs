namespace Phonebook.Common.Contacts
{
    public interface ICommandProcessor
    {
        string ProcessCommand(IInputCommand command);
    }
}