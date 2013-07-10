using System;
using System.Linq;

class WorkDays
{
    static DateTime[] holidays =
    {
        new DateTime(2013, 3, 27), new DateTime(2013, 3, 28), new DateTime(2013, 3, 29),
        new DateTime(2013, 4, 8), new DateTime(2013, 4, 12), new DateTime(2013, 4, 30),
        new DateTime(2013, 5, 20), new DateTime(2013, 5, 21), new DateTime(2013, 4, 22)
    };

    static DateTime[] workSaturdays =
    {
        new DateTime(2013, 3, 30),
        new DateTime(2013, 4, 13), new DateTime(2013, 4, 27),
        new DateTime(2013, 5, 25)
    };

    static void Main(string[] args)
    {
        //Now: 16.03.2013
        DateTime dateNow = new DateTime(2013, 3, 16);
        DateTime futureDay = new DateTime(2013, 5, 27);

        Console.WriteLine("Today is: {0:dd/MM/yyyy}", dateNow);
        Console.WriteLine("Checking work days from {0:dd/MM/yyyy} to {1:dd/MM/yyyy}",
            dateNow, futureDay);
        Console.WriteLine();

        //First check which is the best day, then to go Method GetNumberOfWorkDays
        Console.Write("Total work days: ");
        GetBetterDay(ref dateNow, ref futureDay);

        //Swaping dateNow with futureDay to check if our if-constructions are right
        dateNow = new DateTime(2013, 5, 27);
        futureDay = new DateTime(2013, 3, 16);

        //First check which is the best day, then to go Method GetNumberOfWorkDays
        Console.Write("Total work days (the same, but swaped days): ");
        GetBetterDay(ref futureDay, ref dateNow);
    }

    private static void GetBetterDay(ref DateTime dateNow, ref DateTime futureDay)
    {
        if (futureDay < dateNow)
        {
            Console.WriteLine(GetNumberOfWorkDays(ref futureDay, dateNow));
        }
        else
        {
            Console.WriteLine(GetNumberOfWorkDays(ref dateNow, futureDay));
        }
    }

    private static int GetNumberOfWorkDays(ref DateTime dayNow, DateTime futureDay)
    {
        int numberOfWorkDays = 0;

        do
        {
            if (!holidays.Contains(dayNow))
            {
                if (dayNow.DayOfWeek != DayOfWeek.Saturday &&
                    dayNow.DayOfWeek != DayOfWeek.Sunday ||
                    workSaturdays.Contains(dayNow))
                {
                    numberOfWorkDays++;
                }
            }

            dayNow = dayNow.AddDays(1);
        }
        while (dayNow <= futureDay);

        return numberOfWorkDays;
    }
}