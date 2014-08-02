namespace Phonebook.Data.Contracts
{
    public interface ICommandProcessor
    {
        string ProcessCommand(string @string);
    }
}