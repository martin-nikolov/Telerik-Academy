namespace Computers.Models.Contracts
{
    using System;
    using System.Linq;

    public interface IComputer
    {
        void Play(int guessNumber);
    }
}