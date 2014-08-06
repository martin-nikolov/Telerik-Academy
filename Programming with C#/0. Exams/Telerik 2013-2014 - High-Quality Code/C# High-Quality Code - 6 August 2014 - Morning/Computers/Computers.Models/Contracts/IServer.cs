namespace Computers.Models.Contracts
{
    using System;
    using System.Linq;

    public interface IServer
    {
        void Process(int value);
    }
}