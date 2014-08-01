namespace Phonebook.Data.Commands
{
    using System;
    using System.Linq;
    using System.Text;
    using Phonebook.Data.Contracts;

    public class ListPhonesCommand : BaseCommand
    {
        private const string InvalidRangeMessage = "Invalid range";

        public ListPhonesCommand(IPhonebookRepository phonebookRepository)
            : base(phonebookRepository)
        {
        }

        public override string Execute(string[] arguments)
        {
            if (arguments == null || arguments.Length != 2)
            {
                throw new ArgumentException("Invalid input arguments collection.");
            }

            var startIndex = int.Parse(arguments[0]);
            var count = int.Parse(arguments[1]);

            try
            {
                var output = new StringBuilder();
                var listedPhoneEntries = this.PhonebookRepository.ListEntries(startIndex, count).ToList();
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