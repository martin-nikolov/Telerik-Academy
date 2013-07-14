/*
* 17. Write a program that reads a date and time given in the format:
* day.month.year hour:minute:second 
* and prints the date and time after 6 hours and 30 minutes (in the same format)
* along with the day of week in Bulgarian.
*/

using System;
using System.Globalization;
using System.Linq;

class DateTimeFormat
{
    static void Main()
    {
        string str = "02.3.2013 12:30:00";

        DateTime date = DateTime.ParseExact(str, "d.M.yyyy H:mm:ss", CultureInfo.InvariantCulture).AddMinutes(390);

        Console.WriteLine("Date after 6 hours and 30 mins: {0}\n", date.ToString("dddd dd.MM.yyyy HH:mm:ss", new CultureInfo("bg-BG")));
    }
}