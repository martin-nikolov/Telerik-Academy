namespace Phonebook.Models
{
    using System;
    using System.Collections.Generic;
    using Phonebook.Models.Contracts;

    public class PhoneEntry : IPhoneEntry
    {
        private string name;
        private ISet<string> phoneNumbers;

        public PhoneEntry(string name)
        {
            this.Name = name;
            this.phoneNumbers = new SortedSet<string>();
        }

        public string Name
        {
            get 
            { 
                return this.name; 
            }
            
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Phone entry name cannot be null or empty.");
                }
                
                this.name = value;
            }
        }

        public ISet<string> PhoneNumbers
        {
            get 
            {
                return this.phoneNumbers;
            }

            set
            { 
                if (value == null)
                {
                    throw new NullReferenceException("Phone numbers collection cannot be null.");
                }

                this.phoneNumbers = value;
            }
        }

        public override string ToString()
        {
            var mergedPhoneNumbersText = string.Join(", ", this.PhoneNumbers);
            var output = string.Format("[{0}: {1}]", this.Name, mergedPhoneNumbersText);
            return output.ToString();
        }

        public int CompareTo(IPhoneEntry other)
        {
            return string.Compare(this.Name, other.Name, true);
        }
    }
}