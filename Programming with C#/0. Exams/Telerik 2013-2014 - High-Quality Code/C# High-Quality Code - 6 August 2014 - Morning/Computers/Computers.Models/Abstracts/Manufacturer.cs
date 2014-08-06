namespace Computers.Models.Abstracts
{
    using System;
    using System.Linq;
    using Computers.Models.Contracts;

    public abstract class Manufacturer
    {
        public abstract IComputer CreatePersonalComputer();

        public abstract IServer CreateServer();

        public abstract ILaptop CreateLaptop();
    }
}