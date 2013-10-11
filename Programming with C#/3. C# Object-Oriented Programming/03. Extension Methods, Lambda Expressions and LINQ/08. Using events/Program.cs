/*
* 8. * Read in MSDN about the keyword event in C# and
* how to publish events. Re-implement the above using
* .NET events and following the best practices.
*/

using System;
using System.Threading;

class Program
{
    static event EventHandler<ConsoleKey> HandleEnter;

    static void CaptureKeyPressed(ConsoleKey key)
    {
        if (key == ConsoleKey.Enter)
        {
            HandleEnter(null, ConsoleKey.Enter);
        }
    }

    static void HandleKeyPress(object sender, ConsoleKey key)
    {
        Console.Clear();
        Stopwatch.Seconds = 0;
    }

    static void TickerCount(object sender, ConsoleKey key)
    {
        Console.WriteLine("Starting Stopwatch...");
        Console.WriteLine("\nPress [ENTER] to reset the Stopwatch.\n");

        var action = Stopwatch.Action;

        while (!Console.KeyAvailable || Console.ReadKey().Key != ConsoleKey.Enter)
        {
            Thread.Sleep(1000);
            action();
        }
    }

    static void Main()
    {
        Console.WriteLine("Press [ENTER] to start the Stopwatch!");

        HandleEnter = HandleKeyPress;

        HandleEnter += TickerCount;

        while (true)
        {
            if (Console.KeyAvailable)
            {
                CaptureKeyPressed(Console.ReadKey().Key);
            }
        }
    }
}