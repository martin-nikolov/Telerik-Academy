namespace Computers.Models.Components
{
    using System;

    public class RamMemory
    {
        private int amount;
        private int valueInMemory;

        public RamMemory(int amount)
        {
            this.Amount = amount;
        }

        public int Amount
        {
            get
            {
                return this.amount;
            }

            set
            {
                this.amount = value;
            }
        }

        public void SaveValue(int newValue)
        {
            this.valueInMemory = newValue;
        }

        public int LoadValue()
        {
            return this.valueInMemory;
        }
    }
}