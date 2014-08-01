namespace Phonebook.Models.Contracts
{
    public interface IPhonebookCommand
    {
        string Name { get; set; }

        string[] Arguments { get; set; }
    }
}