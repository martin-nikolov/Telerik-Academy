namespace Computers.Models.HpComputers
{
    using System;
    using System.Linq;
    using Computers.Models.Abstracts;
    using Computers.Models.Contracts;

    public class HpManufacturer : Manufacturer
    {
        public override IComputer CreatePersonalComputer()
        {
            var personalComputer = new HpPersonalComputer();
            return personalComputer;
        }

        public override IServer CreateServer()
        {
            var server = new HpServer();
            return server;
        }

        public override ILaptop CreateLaptop()
        {
            var laptop = new HpLaptop();
            return laptop;
        }
    }
}