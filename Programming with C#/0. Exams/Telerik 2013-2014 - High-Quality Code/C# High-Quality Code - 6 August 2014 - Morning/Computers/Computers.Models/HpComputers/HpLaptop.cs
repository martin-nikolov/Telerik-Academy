namespace Computers.Models.HpComputers
{
    using System;
    using System.Linq;
    using Computers.Models.Abstracts;
    using Computers.Models.Components;
    using Computers.Models.Enumerations;

    public class HpLaptop : Laptop
    {
        private const int RamMemoryAmount = 4;
        private const int CpuCoresCount = 4;
        private const int HardDriverCapacity = 500;

        public HpLaptop()
        {
            this.Type = ComputerType.Laptop;
            this.RamMemory = new RamMemory(RamMemoryAmount);
            this.VideoCard = new VideoCard(false);
            this.Motherboard = new Motherboard(this.RamMemory, this.VideoCard);
            this.Cpu = new Cpu64Bits(CpuCoresCount, this.Motherboard);
            this.HardDrivers = new[] { new HardDriver(HardDriverCapacity, false, 0) };
            this.LaptopBattery = new LaptopBattery();
        }
    }
}