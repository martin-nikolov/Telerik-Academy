namespace Computers.Models.LenovoComputers
{
    using System;
    using System.Linq;
    using Computers.Models.Abstracts;
    using Computers.Models.Components;
    using Computers.Models.Enumerations;

    public class LenovoPersonalComputer : Computer
    {
        private const int RamMemoryAmount = 4;
        private const int CpuCoresCount = 2;
        private const int HardDriverCapacity = 2000;

        public LenovoPersonalComputer()
        {
            this.Type = ComputerType.PersonalComputer;
            this.RamMemory = new RamMemory(RamMemoryAmount);
            this.VideoCard = new VideoCard(true);
            this.Motherboard = new Motherboard(this.RamMemory, this.VideoCard);
            this.Cpu = new Cpu64Bits(CpuCoresCount, this.Motherboard);
            this.HardDrivers = new[] { new HardDriver(HardDriverCapacity, false, 0) };
        }
    }
}