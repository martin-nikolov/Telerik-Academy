namespace Computers.Models.LenovoComputers
{
    using System;
    using System.Linq;
    using Computers.Models.Abstracts;
    using Computers.Models.Contracts;

    public class LenovoManufacturer : Manufacturer
    {
        public override IComputer CreatePersonalComputer()
        {
            var personalComputer = new LenovoPersonalComputer();
            return personalComputer;
        }

        public override IServer CreateServer()
        {
            var server = new LenovoServer();
            return server;
        }

        public override ILaptop CreateLaptop()
        {
            var laptop = new LenovoLaptop();
            return laptop;
        }
    }
}