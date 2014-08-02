namespace Phonebook.Data.Factories
{
    using System;
    using System.Linq;
    using Phonebook.Data.Commands;
    using Phonebook.Data.Contracts;
    using Phonebook.Data.Repositories;
    using Phonebook.Models.Contracts;

    //! Factory pattern
    public class CommandFactoryWithLazyLoading : ICommandFactory
    {
        private const string AddPhoneCommandName = "AddPhone";
        private const string DeletePhoneCommandName = "DeletePhone";
        private const string ChangePhoneCommandName = "ChangePhone";
        private const string ListPhonesCommandName = "List";

        private readonly Lazy<AddPhoneCommand> addPhoneCommand;
        private readonly Lazy<ChangePhoneCommand> changePhoneCommand;
        private readonly Lazy<DeletePhoneCommand> deletePhoneCommand;
        private readonly Lazy<ListPhonesCommand> listPhonesCommand;

        private IPhonebookRepository phonebookRepository;

        //! Dependency inversion
        public CommandFactoryWithLazyLoading()
            : this(new PhonebookRepositoryFast(), new PhonebookSanitizer())
        {
        }

        public CommandFactoryWithLazyLoading(IPhonebookRepository phonebookRepository, IPhoneNumberSanitizer sanitizer)
        {
            this.PhonebookRepository = phonebookRepository;

            //! Lazy loading
            this.addPhoneCommand = new Lazy<AddPhoneCommand>(() => new AddPhoneCommand(this.PhonebookRepository, sanitizer));
            this.changePhoneCommand = new Lazy<ChangePhoneCommand>(() => new ChangePhoneCommand(this.PhonebookRepository, sanitizer));
            this.deletePhoneCommand = new Lazy<DeletePhoneCommand>(() => new DeletePhoneCommand(this.PhonebookRepository));
            this.listPhonesCommand = new Lazy<ListPhonesCommand>(() => new ListPhonesCommand(this.PhonebookRepository));
        }

        private IPhonebookRepository PhonebookRepository
        {
            get
            { 
                return this.phonebookRepository; 
            }

            set
            { 
                if (value == null)
                {
                    throw new NullReferenceException("Phone repository object instance cannot be null.");
                }
                
                this.phonebookRepository = value;
            }
        }

        public ICommand Create(IPhonebookCommand commandInfo)
        {
            ICommand command = null;

            if (commandInfo.Name == AddPhoneCommandName && commandInfo.Arguments.Length >= 2)
            {
                command = this.addPhoneCommand.Value;
            }
            else if (commandInfo.Name == ChangePhoneCommandName && commandInfo.Arguments.Length == 2)
            {
                command = this.changePhoneCommand.Value;
            }
            else if (commandInfo.Name == DeletePhoneCommandName && commandInfo.Arguments.Length == 1)
            {
                command = this.deletePhoneCommand.Value;
            }
            else if (commandInfo.Name == ListPhonesCommandName && commandInfo.Arguments.Length == 2)
            {
                command = this.listPhonesCommand.Value;
            }
            else
            {
                throw new ArgumentException("Invalid command info parameters.");
            }

            return command;
        }
    }
}