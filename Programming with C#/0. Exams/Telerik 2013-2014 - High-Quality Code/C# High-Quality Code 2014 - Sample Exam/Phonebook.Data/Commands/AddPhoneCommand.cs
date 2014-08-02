namespace Phonebook.Data.Commands
{
    using System;
    using System.Linq;
    using Phonebook.Common;
    using Phonebook.Data.Contracts;

    //! Command pattern
    public class AddPhoneCommand : BaseCommand
    {
        private const string PhoneEntryCreatedMessage = "Phone entry created";
        private const string PhoneEntryMergedMessage = "Phone entry merged";

        public AddPhoneCommand(IPhonebookRepository phonebookRepository)
            : base(phonebookRepository)
        {
        }

        public override string Execute(string[] arguments)
        {
            this.CheckForNullArguments(arguments);

            var name = arguments[0];
            var phoneNumbers = arguments.Skip(1).ToArray(); // at least 1 and at most 10
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