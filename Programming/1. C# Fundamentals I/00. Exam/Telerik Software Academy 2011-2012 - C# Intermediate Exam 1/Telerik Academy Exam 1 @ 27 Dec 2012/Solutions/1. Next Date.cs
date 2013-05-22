using System;
using System.Linq;

class NextDate
{
    static void Main()
    {
        int day = int.Parse(Console.ReadLine());
        int month = int.Parse(Console.ReadLine());
        int year = int.Parse(Console.ReadLine());
        Console.WriteLine("{0:d.M.yyyy}", new DateTime(year, month, day).AddDays(1));
    }
}