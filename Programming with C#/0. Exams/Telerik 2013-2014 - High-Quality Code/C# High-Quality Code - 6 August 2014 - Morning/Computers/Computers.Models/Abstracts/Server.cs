namespace Computers.Models.Abstracts
{
    using System;
    using System.Linq;
    using Computers.Models.Contracts;

    public abstract class Server : Machine, IServer
    {
        public virtual void Process(int value)
        {
            this.Motherboard.SaveRamValue(value);
            this.Cpu.SquareNumber();
        }
    }
}