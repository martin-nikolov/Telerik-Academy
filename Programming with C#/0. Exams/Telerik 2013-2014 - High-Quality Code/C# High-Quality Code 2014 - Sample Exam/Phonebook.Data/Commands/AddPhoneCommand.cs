namespace Phonebook.Data.Commands
{
    using System;
    using System.Linq;
    using Phonebook.Common;
    using Phonebook.Data.Contracts;

    public class AddPhoneCommand : BaseCommand, ICommand
    {
        private const string PhoneEntryCreatedMessage = "Phone entry created";
        private const string PhoneEntryMergedMessage = "Phone entry merged";

        public AddPhoneCommand(IPhonebookRepository phonebookRepository)
            : base(phonebookRepository)
        {
        }

        public string Execute(string[] arguments)
        {
            if (arguments == null || arguments.Length < 2)
            {
                throw new ArgumentException("Invalid input arguments collection.");
            }

            var name = arguments[0];
            var phoneNumbers = arguments.Skip(1).ToArray();

            for (int i = 0; i < phoneNumbers.Length; i++)
            {
                phoneNumbers[i] = phoneNumbers[i].ConvertPhoneToCannonicalForm();
            }

            bool isNewEntry = this.PhonebookRepository.AddPhone(name, phoneNumbers);
            if (isNewEntry)
            {
                return PhoneEntryCreatedMessage;
            }
            else
            {
                return PhoneEntryMergedMessage;
            }
        }
    }
}