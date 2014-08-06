namespace Computers.Models.Contracts
{
    using System;
    using System.Linq;

    public interface ILaptop
    {
        void ChargeBattery(int percentage);
    }
}