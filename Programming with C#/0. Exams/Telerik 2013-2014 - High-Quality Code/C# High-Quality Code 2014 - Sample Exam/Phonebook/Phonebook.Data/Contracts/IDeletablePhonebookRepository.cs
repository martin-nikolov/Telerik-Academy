namespace Phonebook.Data.Contracts
{
    public interface IDeletablePhonebookRepository
    {
        bool DeletePhone(string phoneNumber);
    }
}