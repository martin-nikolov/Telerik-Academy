/*
* 16. Write a program that reads two dates in the format: day.month.year
* and calculates the number of days between them. 
* 
* Example:
* Enter the first date: 27.02.2006
* Enter the second date: 3.03.2006
* Distance: 4 days
*/

using System;
using System.Globalization;
using System.Linq;

class DaysBetweenTwoDates
{
    static void Main()
    {
        string startDate = "27.2.2006";
        string endDate = "3.03.2006";

        DateTime start = DateTime.ParseExact(startDate, "d.M.yyyy", CultureInfo.InvariantCulture);
        DateTime end = DateTime.ParseExact(endDate, "d.M.yyyy", CultureInfo.InvariantCulture);

        Console.WriteLine("Distance between {0} and {1} -> {2} days\n", startDate, endDate, Math.Abs((end - start).TotalDays));
    }
}