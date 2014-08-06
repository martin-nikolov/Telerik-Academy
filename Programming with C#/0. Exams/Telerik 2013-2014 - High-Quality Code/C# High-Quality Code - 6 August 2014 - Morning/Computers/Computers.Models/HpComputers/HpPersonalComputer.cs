namespace Computers.Models.HpComputers
{
    using System;
    using System.Linq;
    using Computers.Models.Abstracts;
    using Computers.Models.Components;
    using Computers.Models.Enumerations;

    public class HpPersonalComputer : Computer
    {
        private const int RamMemoryAmount = 2;
        private const int CpuCoresCount = 2;
        private const int HardDriverCapacity = 500;

        public HpPersonalComputer()
        {
            this.Type = ComputerType.PersonalComputer;
            this.RamMemory = new RamMemory(RamMemoryAmount);
            this.VideoCard = new VideoCard(false);
            this.Motherboard = new Motherboard(this.RamMemory, this.VideoCard);
            this.Cpu = new Cpu32Bits(CpuCoresCount, this.Motherboard);
            this.HardDrivers = new[] { new HardDriver(HardDriverCapacity, false, 0) };
        }
    }
}