using System;

class Program
{
    static void Main(string[] args)
    {
        DateTime now = DateTime.Now;
        Console.WriteLine(now.ToString("d"));
        Console.WriteLine(now.ToString("D"));
        Console.WriteLine(now.ToString("f"));
        Console.WriteLine(now.ToString("F"));
        Console.WriteLine(now.ToString("g"));
        Console.WriteLine(now.ToString("G"));
        Console.WriteLine(now.ToString("m"));
        Console.WriteLine(now.ToString("M"));
        Console.WriteLine(now.ToString("o"));
        Console.WriteLine(now.ToString("O"));
        Console.WriteLine(now.ToString("s"));
        Console.WriteLine(now.ToString("t"));
        Console.WriteLine(now.ToString("T"));
        Console.WriteLine(now.ToString("u"));
        Console.WriteLine(now.ToString("U"));
        Console.WriteLine(now.ToString("y"));
        Console.WriteLine(now.ToString("Y"));
    }
}
