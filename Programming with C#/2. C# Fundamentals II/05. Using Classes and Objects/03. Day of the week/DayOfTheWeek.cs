/*
* 3. Write a program that prints to the console which day of the week is today. Use System.DateTime.
*/

using System;
using System.Linq;

class DayOfTheWeek
{
    static void Main()
    {
        Console.WriteLine("Today is {0:d} -> {1}\n", DateTime.Now, DateTime.Now.DayOfWeek);
    }
}