namespace Computers.Models.Abstracts
{
    using System;
    using Computers.Models.Components;
    using Computers.Models.Contracts;

    public abstract class Cpu
    {
        private const string NumberTooLowMessage = "Number too low.";
        private const string NumberTooHighMessage = "Number too high.";
        private const string SquareOfNumberMessage = "Square of {0} is {1}.";

        private readonly IRandomNumberProvider randomNumberProvider;

        public Cpu(int numberOfCores, int numberOfBits, Motherboard motherboard, IRandomNumberProvider randomNumberProvider)
        {
            this.NumberOfCores = numberOfCores;
            this.NumberOfBits = numberOfBits;
            this.Motherboard = motherboard;
            this.randomNumberProvider = randomNumberProvider;
        }

        public Motherboard Motherboard { get; set; }

        public int NumberOfCores { get; set; }

        public int NumberOfBits { get; set; }

        public abstract void SquareNumber();

        // Bottleneck -> fixed
        public void SetRandomRamValue(int minValue, int maxValue)
        {
            int randomValue = this.GenerateRandomNumber(minValue, maxValue);
            this.Motherboard.SaveRamValue(randomValue);
        }

        public int GenerateRandomNumber(int minValue, int maxValue)
        {
            int randomNumber = this.randomNumberProvider.GenerateRandomNumber(minValue, maxValue);
            return randomNumber;
        }

        protected void CalculateSquareOfNumber(int minValue, int maxValue)
        {
            var loadedNumber = this.Motherboard.LoadRamValue();

            if (loadedNumber < minValue)
            {
                this.Motherboard.DrawOnVideoCard(NumberTooLowMessage);
            }
            else if (loadedNumber > maxValue)
            {
                this.Motherboard.DrawOnVideoCard(NumberTooHighMessage);
            }
            else
            {
                int square = loadedNumber * loadedNumber;
                this.Motherboard.DrawOnVideoCard(string.Format(SquareOfNumberMessage, loadedNumber, square));
            }
        }
    }
}