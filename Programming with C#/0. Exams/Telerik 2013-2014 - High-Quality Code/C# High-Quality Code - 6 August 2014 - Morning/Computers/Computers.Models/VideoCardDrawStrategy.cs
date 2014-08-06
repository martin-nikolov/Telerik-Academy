namespace Computers.Models
{
    using System;
    using System.Linq;
    using Computers.Models.Contracts;

    public class VideoCardDrawStrategy : IDrawStrategy
    {
        public void DrawColorful(string text)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        public void DrawMonochrome(string text)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(text);
            Console.ResetColor();
        }
    }
}