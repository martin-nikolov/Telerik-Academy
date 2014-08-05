namespace Phonebook.Data.Commands
{
    using System;
    using System.Linq;
    using Phonebook.Data.Contracts;

    //! Command pattern
    public class ListPhonesCommand : BaseCommand
    {
        private const string InvalidRangeMessage = "Invalid range";

        public ListPhonesCommand(IPhonebookRepository phonebookRepository)
            : base(phonebookRepository)
        {
        }

        public override string Execute(string[] arguments)
        {
            this.CheckForNullArguments(arguments);

            var startIndex = int.Parse(arguments[0]);
            var count = int.Parse(arguments[1]);

            try
            {
                var listedPhoneEntries = this.PhonebookRepository.ListEntries(startIndex, count).ToList();
                var output = string.Join(Environment.NewLine, listedPhoneEntries.Select(e => e)).Trim();
                return output;
            }
            catch (ArgumentOutOfRangeException)
            {
                return InvalidRangeMessage;
            }
        }
    }
}