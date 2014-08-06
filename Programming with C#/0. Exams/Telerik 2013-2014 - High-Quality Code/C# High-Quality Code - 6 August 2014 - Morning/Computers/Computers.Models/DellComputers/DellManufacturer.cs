namespace Computers.Models.DellComputers
{
    using System;
    using Computers.Models.Abstracts;
    using Computers.Models.Contracts;

    public class DellManufacturer : Manufacturer
    {
        public override IComputer CreatePersonalComputer()
        {
            var personalComputer = new DellPersonalComputer();
            return personalComputer;
        }

        public override IServer CreateServer()
        {
            var server = new DellServer();
            return server;
        }

        public override ILaptop CreateLaptop()
        {
            var laptop = new DellLaptop();
            return laptop;
        }
    }
}