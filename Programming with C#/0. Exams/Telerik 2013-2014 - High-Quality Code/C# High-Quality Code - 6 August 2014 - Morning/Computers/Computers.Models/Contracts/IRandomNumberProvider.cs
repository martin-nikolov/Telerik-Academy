namespace Computers.Models.Contracts
{
    using System;
    using System.Linq;

    public interface IRandomNumberProvider
    {
        int GenerateRandomNumber(int maxValue);

        int GenerateRandomNumber(int minValue, int maxValue);
    }
}