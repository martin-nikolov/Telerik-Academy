namespace Phonebook.Data.Contracts
{
    public interface IPhoneNumberSanitizer
    {
        string Sanitize(string phoneNumber);
    }
}