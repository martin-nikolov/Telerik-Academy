namespace Computers.Data.Contracts
{
    using Computers.Models.Contracts;

    public interface ICommandProcessor
    {
        void Process(ICommandInfo command, ILogger logger);
    }
}