namespace Computers.Models.Contracts
{
    public interface ICommandInfo
    {
        string Name { get; set; }

        int Argument { get; set; }
    }
}