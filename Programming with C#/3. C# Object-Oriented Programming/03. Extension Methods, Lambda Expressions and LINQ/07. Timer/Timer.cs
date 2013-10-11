using System;
using System.Linq;

public delegate void Ticker();

public static class Timer
{
    public static readonly Action Action = new Action(() => Console.WriteLine(++Seconds));

    public static int Seconds { get; private set; }
}