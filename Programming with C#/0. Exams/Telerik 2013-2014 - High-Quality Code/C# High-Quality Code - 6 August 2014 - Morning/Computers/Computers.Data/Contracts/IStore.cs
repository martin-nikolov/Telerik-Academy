namespace Computers.Data.Contracts
{
    using System;
    using System.Linq;
    using Computers.Models.Contracts;

    public interface IStore
    {
        IComputer PersonalComputer { get; set; }

        IServer Server { get; set; }

        ILaptop Laptop { get; set; }
    }
}