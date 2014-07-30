namespace Phonebook
{
    using System;
    using System.Linq;
    using System.Text;
    using Phonebook.Contracts;

    public class CommandProcessor : ICommandProcessor
    {
        private const string AddPhoneCommandName = "AddPhone";
        private const string DeletePhoneCommandName = "DeletePhone";
        private const string ChangePhoneCommandName = "ChangePhone";
        private const string ListPhonesCommandName = "List";

        private const string PhoneEntryCreatedMessage = "Phone entry created";
        private const string PhoneEntryMergedMessage = "Phone entry merged";
        private const string PhoneEntriesChangedMessage = "{0} numbers changed";
        private const string PhoneNumberDeletedMessage = "Phone number deleted";
        private const string InvalidPhoneNumberMessage = "Invalid phone number";
        private const string PhoneNumberNotFoundMessage = "Phone number could not be found";
        private const string InvalidRangeMessage = "Invalid range";

        private IPhonebookRepository phonebookRepository;

        public CommandProcessor(IPhonebookRepository phonebookRepository)
        {
            this.PhonebookRepository = phonebookRepository;
        }

        public IPhonebookRepository PhonebookRepository
        {
            get { return this.phonebookRepository; }

            private set
            {
                if (value == null)
                {
                    throw new NullReferenceException("Phonebook repository instance cannot be null.");
                }

                this.phonebookRepository = value;
            }
        }

        public string ProcessCommand(ICommand command)
        {
            if (command == null)
            {
                throw new NullReferenceException("Command instance cannot be null.");
            }

            if ((command.Name == AddPhoneCommandName) && (command.Arguments.Length >= 2))
            {
                return this.ProcessAddPhoneEntryCommand(command.Arguments);
            }

            if ((command.Name == ChangePhoneCommandName) && (command.Arguments.Length == 2))
            {
                return this.ProcessChangePhoneEntryCommand(command.Arguments);
            }

            if ((command.Name == DeletePhoneCommandName) && (command.Arguments.Length == 1))
            {
                return this.ProcessDeletePhoneCommand(command.Arguments[0]);
            }

            if ((command.Name == ListPhonesCommandName) && (command.Arguments.Length == 2))
            {
                return this.ProcessListEventsCommand(command.Arguments);
            }
         
            throw new ArgumentException("You have entered unknown command name.");
        }

        private string ProcessAddPhoneEntryCommand(string[] arguments)
        {
            var name = arguments[0];
            var phoneNumbers = arguments.Skip(1).ToArray();

            for (int i = 0; i < phoneNumbers.Length; i++)
            {
                phoneNumbers[i] = phoneNumbers[i].ConvertPhoneToCannonicalForm();
            }

            bool isNewEntry = this.phonebookRepository.AddPhone(name, phoneNumbers);
            if (isNewEntry)
            {
                return PhoneEntryCreatedMessage;
            }
            else
            {
                return PhoneEntryMergedMessage;
            }
        }

        private string ProcessChangePhoneEntryCommand(string[] phoneNumbers)
        {
            var oldPhoneNumber = phoneNumbers[0].ConvertPhoneToCannonicalForm();
            var newPhoneNumber = phoneNumbers[1].ConvertPhoneToCannonicalForm();

            var numberOfChangedPhones = this.phonebookRepository.ChangePhone(oldPhoneNumber, newPhoneNumber);
            return string.Format(PhoneEntriesChangedMessage, numberOfChangedPhones);
        }

        private string ProcessDeletePhoneCommand(string phoneNumber)
        {
            try
            {
                var hasDeletedPhoneNumbers = this.phonebookRepository.RemovePhone(phoneNumber);
                if (hasDeletedPhoneNumbers)
                {
                    return PhoneNumberDeletedMessage;
                }
                else
                {
                    return PhoneNumberNotFoundMessage;
                }
            }
            catch (ArgumentException)
            {
                return InvalidPhoneNumberMessage;
            }
        }

        private string ProcessListEventsCommand(string[] arguments)
        {
            var startIndex = int.Parse(arguments[0]);
            var count = int.Parse(arguments[1]);

            try
            {
                var output = new StringBuilder();
                var listedPhoneEntries = this.phonebookRepository.ListEntries(startIndex, count).ToList();
                listedPhoneEntries.ForEach(entry => output.AppendLine(entry.ToString()));
                return output.ToString().Trim();
            }
            catch (ArgumentOutOfRangeException)
            {
                return InvalidRangeMessage;
            }
        }
    }
}