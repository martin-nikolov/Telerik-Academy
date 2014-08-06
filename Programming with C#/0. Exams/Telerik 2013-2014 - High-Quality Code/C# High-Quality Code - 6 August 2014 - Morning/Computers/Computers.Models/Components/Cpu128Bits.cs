namespace Computers.Models.Components
{
    using System;
    using System.Linq;
    using Computers.Models.Abstracts;
    using Computers.Models.Contracts;

    public class Cpu128Bits : Cpu
    {
        private const int BitsCount = 128;
        private const int MinNumberToCalculate = 0;
        private const int MaxNumberToCalculate128Bits = 2000;

        // Dependency inversion
        public Cpu128Bits(int numberOfCores, Motherboard motherboard)
            : this(numberOfCores, motherboard, new RandomNumberProvider())
        {
        }

        public Cpu128Bits(int numberOfCores, Motherboard motherboard, IRandomNumberProvider randomNumberProvider)
            : base(numberOfCores, BitsCount, motherboard, randomNumberProvider)
        {
        }

        public override void SquareNumber()
        {
            this.CalculateSquareOfNumber(MinNumberToCalculate, MaxNumberToCalculate128Bits);
        }
    }
}