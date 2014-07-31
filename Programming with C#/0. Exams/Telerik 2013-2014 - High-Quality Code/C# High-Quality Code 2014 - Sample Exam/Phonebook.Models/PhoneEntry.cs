namespace Phonebook.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Phonebook.Common.Contracts;

    public class PhoneEntry : IPhoneEntry
    {
        private string name;
        private ISet<string> phoneNumbers;

        public PhoneEntry()
        {
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
            var output = new StringBuilder();
            output.AppendFormat("[{0}: {1}]", this.Name, string.Join(", ", this.PhoneNumbers));
            return output.ToString();
        }

        public int CompareTo(IPhoneEntry other)
        {
            return string.Compare(this.Name, other.Name, true);
        }
    }
}