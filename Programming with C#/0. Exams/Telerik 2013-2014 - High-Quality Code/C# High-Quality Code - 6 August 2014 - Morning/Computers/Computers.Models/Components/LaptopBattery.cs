namespace Computers.Models.Components
{
    using System;

    public class LaptopBattery
    {
        private const int MinPercentage = 0;
        private const int MaxPercentage = 100;

        private int percentage;

        public LaptopBattery()
        {
            this.Percentage = MaxPercentage / 2;
        }

        public int Percentage
        {
            get
            {
                return this.percentage;
            }

            set
            {
                if (value < MinPercentage || value > MaxPercentage)
                {
                    throw new ArgumentOutOfRangeException("Invalid percentage value.");
                }

                this.percentage = value;
            }
        }

        public void Charge(int percentage)
        {
            var newPercentageValue = this.Percentage + percentage;

            if (newPercentageValue > MaxPercentage)
            {
                newPercentageValue = MaxPercentage;
            }
            else if (newPercentageValue < MinPercentage)
            {
                newPercentageValue = MinPercentage;
            }

            this.Percentage = newPercentageValue;
        }
    }
}