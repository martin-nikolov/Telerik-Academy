namespace Phonebook.Models.Contracts
{
    public interface IInputCommand
    {
        string Name { get; set; }

        string[] Arguments { get; set; }
    }
}