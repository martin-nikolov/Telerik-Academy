namespace Phonebook.Common.Contacts
{
    public interface IInputCommand
    {
        string Name { get; set; }

        string[] Arguments { get; set; }
    }
}