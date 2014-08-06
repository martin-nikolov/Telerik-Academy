namespace Computers.Models.DellComputers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Computers.Models.Abstracts;
    using Computers.Models.Components;
    using Computers.Models.Enumerations;

    public class DellServer : Server
    {
        private const int RamMemoryAmount = 64;
        private const int CpuCoresCount = 8;
        private const int HardDriverCapacity = 2000;

        public DellServer()
        {
            this.Type = ComputerType.Server;
            this.RamMemory = new RamMemory(RamMemoryAmount);
            this.VideoCard = new VideoCard(false);
            this.Motherboard = new Motherboard(this.RamMemory, this.VideoCard);
            this.Cpu = new Cpu64Bits(CpuCoresCount, this.Motherboard);

            var hardDriversCollection = this.GetHardDriversCollection();
            this.HardDrivers = hardDriversCollection;
        }
 
        private HardDriver[] GetHardDriversCollection()
        {
            var hardDriversInRaid = new List<HardDriver>
            {
                new HardDriver(HardDriverCapacity, false, 0),
                new HardDriver(HardDriverCapacity, false, 0)
            };

            var hardDriversCollection = new HardDriver[]
            {
                new HardDriver(0, true, 2, hardDriversInRaid)
            };
            return hardDriversCollection;
        }
    }
}