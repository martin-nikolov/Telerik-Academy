namespace Computers.Models
{
    using System;
    using System.Linq;
    using Computers.Models.Contracts;

    public class RandomNumberProvider : IRandomNumberProvider
    {
        private readonly Random randomGenerator = new Random();

        public int GenerateRandomNumber(int maxValue)
        {
            return this.GenerateRandomNumber(0, maxValue);
        }

        public int GenerateRandomNumber(int minValue, int maxValue)
        {
            var randomNumber = this.randomGenerator.Next(minValue, maxValue);
            return randomNumber;
        }
    }
}