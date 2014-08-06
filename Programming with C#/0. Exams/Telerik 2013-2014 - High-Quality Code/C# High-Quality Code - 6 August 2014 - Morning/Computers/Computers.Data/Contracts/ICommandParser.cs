namespace Computers.Data.Contracts
{
    using Computers.Models.Contracts;

    public interface ICommandParser
    {
        ICommandInfo Parse(string text);
    }
}