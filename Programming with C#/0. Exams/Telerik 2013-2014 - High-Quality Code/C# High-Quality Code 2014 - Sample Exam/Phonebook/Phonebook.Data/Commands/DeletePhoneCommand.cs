namespace Phonebook.Data.Commands
{
    using System;
    using System.Linq;
    using Phonebook.Data.Contracts;

    //! Command pattern
    public class DeletePhoneCommand : BaseCommand
    {
        private const string PhoneNumberDeletedMessage = "Phone number deleted";
        private const string InvalidPhoneNumberMessage = "Invalid phone number";
        private const string PhoneNumberNotFoundMessage = "Phone number could not be found";

        public DeletePhoneCommand(IPhonebookRepository phonebookRepository)
            : base(phonebookRepository)
        {
        }

        public override string Execute(string[] arguments)
        {
            this.CheckForNullArguments(arguments);

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