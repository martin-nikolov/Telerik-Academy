/*
* 5. Write a method that calculates the number of workdays between 
* today and given date, passed as parameter. Consider that workdays
* are all days from Monday to Friday except a fixed list of public 
* holidays specified preliminary as array.
*/

using System;
using System.Linq;

class Workdays
{
    static readonly DateTime[] holidays =
    {
        new DateTime(2013, 7, 12), new DateTime(2013, 7, 16), new DateTime(2013, 7, 17),
        new DateTime(2013, 7, 22), new DateTime(2013, 7, 23), new DateTime(2013, 7, 24),
        new DateTime(2013, 7, 26), new DateTime(2013, 7, 30), new DateTime(2013, 7, 31),
        new DateTime(2013, 8, 6), new DateTime(2013, 8, 13), new DateTime(2013, 8, 20),
        new DateTime(2013, 8, 27), new DateTime(2013, 9, 3), new DateTime(2013, 9, 10)
    };

    static void Main()
    {
        DateTime dateNow = new DateTime(2013, 7, 1);
        DateTime dateFuture = new DateTime(2013, 9, 30);  

        Console.WriteLine("Checking work days from {0:dd/MM/yyyy} to {1:dd/MM/yyyy}...\n", 
            dateNow, dateFuture);

        Console.WriteLine("Total work days: {0}\n", GetNumberOfWorkDays(dateNow, dateFuture));
    }

    static int GetNumberOfWorkDays(DateTime dateNow, DateTime dateFuture)
    {
        int numberOfWorkDays = 0;

        if (dateNow > dateFuture)
        {
            DateTime swap = dateNow;
            dateNow = dateFuture;
            dateFuture = swap;
        }

        while (dateNow <= dateFuture)
        {
            if (!holidays.Contains(dateNow) && dateNow.DayOfWeek != DayOfWeek.Saturday &&
                dateNow.DayOfWeek != DayOfWeek.Sunday)
            {
                numberOfWorkDays++;
            }

            dateNow = dateNow.AddDays(1);
        }

        return numberOfWorkDays;
    }
}