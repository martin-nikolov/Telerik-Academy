namespace Computers.Models.DellComputers
{
    using System;
    using System.Linq;
    using Computers.Models.Abstracts;
    using Computers.Models.Components;
    using Computers.Models.Enumerations;

    public class DellLaptop : Laptop
    {
        private const int RamMemoryAmount = 8;
        private const int CpuCoresCount = 4;
        private const int HardDriverCapacity = 1000;

        public DellLaptop()
        {
            this.Type = ComputerType.Laptop;
            this.RamMemory = new RamMemory(RamMemoryAmount);
            this.VideoCard = new VideoCard(false);
            this.Motherboard = new Motherboard(this.RamMemory, this.VideoCard);
            this.Cpu = new Cpu32Bits(CpuCoresCount, this.Motherboard);
            this.HardDrivers = new[] { new HardDriver(HardDriverCapacity, false, 0) };
            this.LaptopBattery = new LaptopBattery();
        }
    }
}