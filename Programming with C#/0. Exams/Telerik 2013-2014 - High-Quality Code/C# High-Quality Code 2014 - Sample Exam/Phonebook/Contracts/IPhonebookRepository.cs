namespace Phonebook.Contracts
{
    using System.Collections.Generic;

    public interface IPhonebookRepository
    {
        bool AddPhone(string name, IEnumerable<string> phoneNumbers);

        int ChangePhone(string oldPhoneNumber, string newPhoneNumber);

        bool RemovePhone(string phoneNumber);

        IEnumerable<IPhoneEntry> ListEntries(int startIndex, int count);
    }
}