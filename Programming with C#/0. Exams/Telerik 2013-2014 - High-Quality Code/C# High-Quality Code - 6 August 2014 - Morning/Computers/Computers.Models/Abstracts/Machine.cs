namespace Computers.Models.Abstracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Computers.Models.Components;
    using Computers.Models.Enumerations;

    public abstract class Machine
    {
        private VideoCard videoCard;

        public Motherboard Motherboard { get; set; }

        public ComputerType Type { get; set; }

        public RamMemory RamMemory { get; set; }

        public VideoCard VideoCard
        {
            get
            {
                return this.videoCard;
            }

            set
            {
                this.videoCard = value;

                if (this.Type != ComputerType.Laptop && this.Type != ComputerType.PersonalComputer)
                {
                    this.videoCard.IsMonochrome = true;
                }
            }
        }

        public IEnumerable<HardDriver> HardDrivers { get; set; }

        public Cpu Cpu { get; set; }
    }
}