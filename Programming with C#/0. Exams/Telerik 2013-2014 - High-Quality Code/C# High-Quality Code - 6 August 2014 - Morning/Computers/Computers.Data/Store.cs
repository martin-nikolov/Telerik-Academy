namespace Computers.Data
{
    using System;
    using System.Linq;
    using Computers.Data.Contracts;
    using Computers.Models.Abstracts;
    using Computers.Models.Contracts;

    public class Store : IStore
    {
        public Store(Manufacturer manufacturer)
        {
            this.PersonalComputer = manufacturer.CreatePersonalComputer();
            this.Server = manufacturer.CreateServer();
            this.Laptop = manufacturer.CreateLaptop();
        }

        public IComputer PersonalComputer { get; set; }

        public IServer Server { get; set; }

        public ILaptop Laptop { get; set; }
    }
}