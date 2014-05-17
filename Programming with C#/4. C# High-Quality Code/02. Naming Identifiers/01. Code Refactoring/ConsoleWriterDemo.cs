namespace IOEngine
{
    using System;
    using System.Linq;

    public class ConsoleWriterDemo
    {
        public static void Main()
        {
            ConsoleWriter consolePrinter = new ConsoleWriter();
            consolePrinter.Print(true);
        }
    }
}