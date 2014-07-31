namespace Phonebook.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Phonebook.Common.Contracts;
    using Phonebook.Models;
    using Wintellect.PowerCollections;

    public class PhonebookRepositoryFast : IPhonebookRepository
    {
        private readonly OrderedSet<IPhoneEntry> sortedPhoneEntries;
        private readonly IDictionary<string, IPhoneEntry> oneEntryByName;
        private readonly MultiDictionary<string, IPhoneEntry> multiEntriesByName;

        public PhonebookRepositoryFast()
        {
            this.sortedPhoneEntries = new OrderedSet<IPhoneEntry>();
            this.oneEntryByName = new Dictionary<string, IPhoneEntry>();
            this.multiEntriesByName = new MultiDictionary<string, IPhoneEntry>(false);
        }

        public bool AddPhone(string name, IEnumerable<string> phoneNumbers)
        {
            string nameToLowerCase = name.ToLowerInvariant();
            IPhoneEntry phoneEntry;
            bool isNewEntry = !this.oneEntryByName.TryGetValue(nameToLowerCase, out phoneEntry);

            if (isNewEntry)
            {
                phoneEntry = new PhoneEntry()
                {
                    Name = name
                };

                this.oneEntryByName.Add(nameToLowerCase, phoneEntry);
                this.sortedPhoneEntries.Add(phoneEntry);
            }

            foreach (var phoneNumber in phoneNumbers)
            {
                this.multiEntriesByName.Add(phoneNumber, phoneEntry);
            }

            phoneEntry.PhoneNumbers.UnionWith(phoneNumbers);
            return isNewEntry;
        }

        // TODO: Validation
        public bool DeletePhone(string phoneNumber)
        {
            if (string.IsNullOrEmpty(phoneNumber))
            {
                throw new ArgumentException("Phone number cannot be null or empty.");
            }

            var matchedPhoneEntries = this.sortedPhoneEntries.Where(e => e.PhoneNumbers.Contains(phoneNumber)).ToList();
            if (matchedPhoneEntries.Count == 0)
            {
                return false;
            }

            foreach (var phoneEntry in matchedPhoneEntries)
            {
                if (phoneEntry.PhoneNumbers.Count == 1)
                {
                    this.sortedPhoneEntries.Remove(phoneEntry);
                    this.oneEntryByName.Remove(phoneEntry.Name.ToLower());
                    this.multiEntriesByName.Remove(phoneEntry.Name.ToLower(), phoneEntry);
                }
                else
                {
                    phoneEntry.PhoneNumbers.Remove(phoneNumber);
                }
            }

            return true;
        }

        public int ChangePhone(string oldPhoneNumber, string newPhoneNumber)
        {
            if (string.IsNullOrEmpty(oldPhoneNumber) || string.IsNullOrEmpty(newPhoneNumber))
            {
                throw new ArgumentException("Phone numbers cannot be null or empty.");
            }

            var matchedPhoneEntries = this.multiEntriesByName[oldPhoneNumber].ToList();

            foreach (var phoneEntry in matchedPhoneEntries)
            {
                phoneEntry.PhoneNumbers.Remove(oldPhoneNumber);
                this.multiEntriesByName.Remove(oldPhoneNumber, phoneEntry);

                phoneEntry.PhoneNumbers.Add(newPhoneNumber);
                this.multiEntriesByName.Add(newPhoneNumber, phoneEntry);
            }

            return matchedPhoneEntries.Count;
        }

        public IEnumerable<IPhoneEntry> ListEntries(int startIndex, int count)
        {
            if (startIndex < 0 || startIndex + count > this.oneEntryByName.Count)
            {
                throw new ArgumentOutOfRangeException("Invalid start index value. Start index is out of range.");
            }

            // TODO: Const
            if (count < 1 || count > 20)
            {
                throw new ArgumentOutOfRangeException("Count must be in range [1;20]");
            }

            var listedPhoneEntries = this.sortedPhoneEntries.Skip(startIndex).Take(count);
            return listedPhoneEntries;
        }
    }
}