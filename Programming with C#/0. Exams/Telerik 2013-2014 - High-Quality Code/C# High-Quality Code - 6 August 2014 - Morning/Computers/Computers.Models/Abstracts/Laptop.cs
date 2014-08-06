namespace Computers.Models.Abstracts
{
    using System;
    using System.Linq;
    using Computers.Models.Components;
    using Computers.Models.Contracts;

    public abstract class Laptop : Machine, ILaptop
    {
        private const string BatteryStatusMessage = "Battery status: {0}%";

        public LaptopBattery LaptopBattery { get; set; }
    
        public virtual void ChargeBattery(int percentage)
        {
            this.LaptopBattery.Charge(percentage);
            this.Motherboard.DrawOnVideoCard(
                string.Format(BatteryStatusMessage, this.LaptopBattery.Percentage));
        }
    }
}