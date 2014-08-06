namespace Phonebook.Data.Contracts
{
    using System.Collections.Generic;
    using Phonebook.Models.Contracts;

    public interface IPhonebookRepository : IDeletablePhonebookRepository
    {
        bool AddPhone(string name, IEnumerable<string> phoneNumbers);

        int ChangePhone(string oldPhoneNumber, string newPhoneNumber);

        IEnumerable<IPhoneEntry> ListEntries(int startIndex, int count);
    }
}