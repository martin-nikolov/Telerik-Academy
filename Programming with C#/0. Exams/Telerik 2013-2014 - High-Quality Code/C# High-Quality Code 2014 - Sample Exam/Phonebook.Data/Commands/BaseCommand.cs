namespace Phonebook.Data.Commands
{
    using System;
    using System.Linq;
    using Phonebook.Data.Contracts;

    public class BaseCommand
    {
        private IPhonebookRepository phonebookRepository;

        public BaseCommand(IPhonebookRepository phonebookRepository)
        {
            this.PhonebookRepository = phonebookRepository;
        }

        public IPhonebookRepository PhonebookRepository
        {
            get 
            { 
                return this.phonebookRepository; 
            }

            protected set
            {
                if (value == null)
                {
                    throw new NullReferenceException("Phonebook repository instance cannot be null.");
                }

                this.phonebookRepository = value;
            }
        }
    }
}