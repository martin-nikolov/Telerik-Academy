namespace Computers.Models.Components
{
    using System;
    using System.Linq;
    using Computers.Models.Abstracts;
    using Computers.Models.Contracts;

    public class Cpu32Bits : Cpu
    {
        private const int BitsCount = 32;
        private const int MinNumberToCalculate = 0;
        private const int MaxNumberToCalculate32Bits = 500;

        // Dependency inversion
        public Cpu32Bits(int numberOfCores, Motherboard motherboard)
            : this(numberOfCores, motherboard, new RandomNumberProvider())
        {
        }

        public Cpu32Bits(int numberOfCores, Motherboard motherboard, IRandomNumberProvider randomNumberProvider)
            : base(numberOfCores, BitsCount, motherboard, randomNumberProvider)
        {
        }

        public override void SquareNumber()
        {
            this.CalculateSquareOfNumber(MinNumberToCalculate, MaxNumberToCalculate32Bits);
        }
    }
}