// 7. Create a console application that prints the current date and time.

using System;

class CurrentDateAndTime
{
    static void Main(string[] args)
    {
        DateTime timeNow = DateTime.Now;

        Console.WriteLine("Current date and time: {0:F}", timeNow);
    }
}
