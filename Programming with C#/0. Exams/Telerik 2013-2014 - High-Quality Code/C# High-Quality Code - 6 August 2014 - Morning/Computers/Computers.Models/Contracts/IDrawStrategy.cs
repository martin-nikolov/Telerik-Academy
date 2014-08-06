namespace Computers.Models.Contracts
{
    public interface IDrawStrategy
    {
        void DrawColorful(string text);

        void DrawMonochrome(string text);
    }
}