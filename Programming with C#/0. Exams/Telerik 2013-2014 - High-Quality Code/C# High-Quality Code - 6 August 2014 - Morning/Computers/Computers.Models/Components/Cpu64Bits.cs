namespace Computers.Models.Components
{
    using System;
    using System.Linq;
    using Computers.Models.Abstracts;
    using Computers.Models.Contracts;

    public class Cpu64Bits : Cpu
    {
        private const int BitsCount = 128;
        private const int MinNumberToCalculate = 0;
        private const int MaxNumberToCalculate64Bits = 1000;

        // Dependency inversion
        public Cpu64Bits(int numberOfCores, Motherboard motherboard)
            : this(numberOfCores, motherboard, new RandomNumberProvider())
        {
        }

        public Cpu64Bits(int numberOfCores, Motherboard motherboard, IRandomNumberProvider randomNumberProvider)
            : base(numberOfCores, BitsCount, motherboard, randomNumberProvider)
        {
        }

        public override void SquareNumber()
        {
            this.CalculateSquareOfNumber(MinNumberToCalculate, MaxNumberToCalculate64Bits);
        }
    }
}