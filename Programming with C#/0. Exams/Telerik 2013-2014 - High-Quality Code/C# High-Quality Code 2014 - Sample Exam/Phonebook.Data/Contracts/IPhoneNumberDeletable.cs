namespace Phonebook.Data.Contracts
{
    public interface IPhoneNumberDeletable
    {
        bool DeletePhone(string phoneNumber);
    }
}