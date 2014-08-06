namespace Computers.Tests
{
    using System;
    using System.Linq;
    using Computers.Models.Contracts;

    public class CustomRandomNumberProvider : IRandomNumberProvider
    {
        private readonly int customValue;

        public CustomRandomNumberProvider(int customValue)
        {
            this.customValue = customValue;
        }

        public int GenerateRandomNumber(int maxValue)
        {
            return this.customValue;
        }

        public int GenerateRandomNumber(int minValue, int maxValue)
        {
            return this.customValue;
        }
    }
}