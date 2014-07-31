namespace Memento
{
    using System;

    /// <summary>
    /// The 'Originator' class
    /// </summary>
    internal class SalesProspect
    {
        private string name;
        private string phone;
        private double budget;

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.name = value;
                Console.WriteLine("Name:   " + this.name);
            }
        }

        public string Phone
        {
            get
            {
                return this.phone;
            }

            set
            {
                this.phone = value;
                Console.WriteLine("Phone:  " + this.phone);
            }
        }

        public double Budget
        {
            get
            {
                return this.budget;
            }

            set
            {
                this.budget = value;
                Console.WriteLine("Budget: " + this.budget);
            }
        }

        public Memento SaveMemento()
        {
            Console.WriteLine("\nSaving state --\n");
            return new Memento(this.name, this.phone, this.budget);
        }

        public void RestoreMemento(Memento memento)
        {
            Console.WriteLine("\nRestoring state --\n");
            this.Name = memento.Name;
            this.Phone = memento.Phone;
            this.Budget = memento.Budget;
        }
    }
}
