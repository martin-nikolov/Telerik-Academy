namespace Phonebook.Data.Commands
{
    using System;
    using Phonebook.Data.Contracts;

    //! Command pattern
    public class ChangePhoneCommand : BaseCommand
    {
        private const string PhoneEntriesChangedMessage = "{0} numbers changed";
        private readonly IPhoneNumberSanitizer sanitizer;

        public ChangePhoneCommand(IPhonebookRepository phonebookRepository, IPhoneNumberSanitizer sanitizer)
            : base(phonebookRepository)
        {
            this.sanitizer = sanitizer;
        }

        public override string Execute(string[] arguments)
        {
            this.CheckForNullArguments(arguments);

            var oldPhoneNumber = this.sanitizer.Sanitize(arguments[0]);
            var newPhoneNumber = this.sanitizer.Sanitize(arguments[1]);

            var numberOfChangedPhones = this.PhonebookRepository.ChangePhone(oldPhoneNumber, newPhoneNumber);
            return string.Format(PhoneEntriesChangedMessage, numberOfChangedPhones);
        }
    }
}