namespace Computers.Models.Components
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class HardDriver
    {
        private int capacity;

        public HardDriver()
            : this(0, false, 0)
        {
        }

        public HardDriver(int capacity, bool isInRaid, int hardDrivesInRaid)
            : this(capacity, isInRaid, hardDrivesInRaid, new List<HardDriver>())
        {
        }

        public HardDriver(int capacity, bool isInRaid, int hardDrivesInRaid, IList<HardDriver> hardDrives)
        {
            this.Capacity = capacity;
            this.IsInRaid = isInRaid;
            this.HardDrivesInRaid = hardDrivesInRaid;
            this.HardDrivers = hardDrives;
        }

        public bool IsInRaid { get; set; }

        public int HardDrivesInRaid { get; set; }

        public IList<HardDriver> HardDrivers { get; set; }

        public int Capacity
        {
            get
            {
                if (this.IsInRaid)
                {
                    if (this.HardDrivers.Count == 0)
                    {
                        return 0;
                    }

                    return this.HardDrivers.First().Capacity;
                }
                else
                {
                    return this.capacity;
                }
            }

            private set
            {
                this.capacity = value;
            }
        }
    }
}