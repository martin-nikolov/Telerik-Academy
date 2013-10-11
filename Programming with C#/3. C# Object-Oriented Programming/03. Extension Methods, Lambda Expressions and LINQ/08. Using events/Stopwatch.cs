using System;
using System.Linq;

public delegate void Ticker();

public static class Stopwatch
{
    public static readonly Action Action = new Action(() => Console.WriteLine(++Seconds));

    public static int Seconds { get; set; }
}