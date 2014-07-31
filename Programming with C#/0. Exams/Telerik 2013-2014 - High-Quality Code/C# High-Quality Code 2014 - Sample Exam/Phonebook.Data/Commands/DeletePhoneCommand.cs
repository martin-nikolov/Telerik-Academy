namespace Phonebook.Data.Commands
{
    using System;
    using System.Linq;
    using Phonebook.Data.Contracts;

    public class DeletePhoneCommand : BaseCommand, ICommand
    {
        private const string PhoneNumberDeletedMessage = "Phone number deleted";
        private const string InvalidPhoneNumberMessage = "Invalid phone number";
        private const string PhoneNumberNotFoundMessage = "Phone number could not be found";

        public DeletePhoneCommand(IPhonebookRepository phonebookRepository)
            : base(phonebookRepository)
        {
        }

        public string Execute(string[] arguments)
        {
            if (arguments == null || arguments.Length != 1)
            {
                throw new ArgumentException("Invalid input arguments collection.");
            }

            try
            {
                var phoneNumber = arguments.First();
                var hasDeletedPhoneNumbers = this.PhonebookRepository.DeletePhone(phoneNumber);
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
    }
}