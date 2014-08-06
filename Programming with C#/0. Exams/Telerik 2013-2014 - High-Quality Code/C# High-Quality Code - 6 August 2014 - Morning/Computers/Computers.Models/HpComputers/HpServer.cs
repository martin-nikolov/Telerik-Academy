namespace Computers.Models.HpComputers
{
    using System;
    using System.Linq;
    using Computers.Models.Abstracts;
    using Computers.Models.Components;
    using Computers.Models.Enumerations;

    public class HpServer : Server
    {
        private const int RamMemoryAmount = 64;
        private const int CpuCoresCount = 4;
        private const int HardDriverCapacity = 32;

        public HpServer()
        {
            this.Type = ComputerType.Server;
            this.RamMemory = new RamMemory(RamMemoryAmount);
            this.VideoCard = new VideoCard(false);
            this.Motherboard = new Motherboard(this.RamMemory, this.VideoCard);
            this.Cpu = new Cpu32Bits(CpuCoresCount, this.Motherboard);

            var hardDriversCollection = this.GetHardDriversCollection();
            this.HardDrivers = hardDriversCollection;
        }
 
        private HardDriver[] GetHardDriversCollection()
        {
            var hardDriversCollection = new HardDriver[] 
            {
                new HardDriver(HardDriverCapacity, false, 0),
                new HardDriver(HardDriverCapacity, false, 0)
            };
            return hardDriversCollection;
        }
    }
}