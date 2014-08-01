namespace Phonebook.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Phonebook.Data.Contracts;
    using Phonebook.Models;
    using Phonebook.Models.Contracts;
    using Wintellect.PowerCollections;

    // TODO: Implement Abstract Factory
    // TODO: Export an abstact PhonebookRepository class
    public class PhonebookRepositoryFast : IPhonebookRepository
    {
        private readonly OrderedSet<IPhoneEntry> sortedEntries;
        private readonly IDictionary<string, IPhoneEntry> entriesByName;
        private readonly MultiDictionaryBase<string, IPhoneEntry> entriesByPhone;

        //! Dependency inversion
        public PhonebookRepositoryFast()
            : this(new Dictionary<string, IPhoneEntry>(), new MultiDictionary<string, IPhoneEntry>(false))
        {
        }

        public PhonebookRepositoryFast(IDictionary<string, IPhoneEntry> entriesByName, MultiDictionaryBase<string, IPhoneEntry> entriesByPhone)
        {
            this.sortedEntries = new OrderedSet<IPhoneEntry>();
            this.entriesByName = entriesByName;
            this.entriesByPhone = entriesByPhone;
        }

        public bool AddPhone(string name, IEnumerable<string> phoneNumbers)
        {
            string nameToLowerCase = name.ToLowerInvariant();
            IPhoneEntry phoneEntry;
            bool isNewEntry = !this.entriesByName.TryGetValue(nameToLowerCase, out phoneEntry);

            if (isNewEntry)
            {
                phoneEntry = new PhoneEntry(name);
                this.entriesByName.Add(nameToLowerCase, phoneEntry);
                this.sortedEntries.Add(phoneEntry);
            }

            // TODO: Extract method
            foreach (var phoneNumber in phoneNumbers)
            {
                this.entriesByPhone.Add(phoneNumber, phoneEntry);
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

            var matchedPhoneEntries = this.sortedEntries.Where(e => e.PhoneNumbers.Contains(phoneNumber)).ToList();
            if (matchedPhoneEntries.Count == 0)
            {
                return false;
            }

            // TODO: Extract method
            foreach (var phoneEntry in matchedPhoneEntries)
            {
                if (phoneEntry.PhoneNumbers.Count == 1)
                {
                    this.sortedEntries.Remove(phoneEntry);
                    this.entriesByName.Remove(phoneEntry.Name.ToLower());
                    this.entriesByPhone.Remove(phoneEntry.Name.ToLower(), phoneEntry);
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

            //! Bottleneck -> .ToList()
            //! No fix is available.
            var matchedPhoneEntries = this.entriesByPhone[oldPhoneNumber].ToList();

            // TODO: Extract method
            foreach (var phoneEntry in matchedPhoneEntries)
            {
                phoneEntry.PhoneNumbers.Remove(oldPhoneNumber);
                this.entriesByPhone.Remove(oldPhoneNumber, phoneEntry);

                phoneEntry.PhoneNumbers.Add(newPhoneNumber);
                this.entriesByPhone.Add(newPhoneNumber, phoneEntry);
            }

            return matchedPhoneEntries.Count;
        }

        public IEnumerable<IPhoneEntry> ListEntries(int startIndex, int count)
        {
            if (startIndex < 0 || startIndex + count > this.entriesByName.Count)
            {
                throw new ArgumentOutOfRangeException("Invalid start index value. Start index is out of range.");
            }

            // TODO: Const
            if (count < 1 || count > 20)
            {
                throw new ArgumentOutOfRangeException("Count must be in range [1;20]");
            }

            var listedPhoneEntries = this.sortedEntries.Skip(startIndex).Take(count);
            return listedPhoneEntries;
        }
    }
}