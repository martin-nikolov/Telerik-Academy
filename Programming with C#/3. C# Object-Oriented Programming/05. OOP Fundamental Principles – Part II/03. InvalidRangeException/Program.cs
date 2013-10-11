/*
* 3. Define a class InvalidRangeException<T> that holds information
* about an error condition related to invalid range. It should hold
* error message and a range definition [start … end].
* Write a sample application that demonstrates the InvalidRangeException<int>
* and InvalidRangeException<DateTime> by entering numbers in the range
* [1..100] and dates in the range [1.1.1980 … 31.12.2013].
*/

using System;
using System.Linq;

class Program
{
    static void Main()
    {
        try
        {
            int begin = 1;
            int last = 100;

            int number = 150;

            if (begin < number && number > last)
                throw new InvalidRangeException<int>(begin, last);
        }
        catch (InvalidRangeException<int> ire)
        {
            Console.WriteLine(ire.Message);
            Console.WriteLine("Begin: {0}, Last: {1}", ire.Begin, ire.Last);
        }

        Console.WriteLine();

        try
        {
            DateTime begin = new DateTime(1980, 1, 1);
            DateTime last = new DateTime(2013, 12, 31);

            DateTime date = new DateTime(2014, 2, 1);

            if (begin < date && date > last)
                throw new InvalidRangeException<DateTime>(begin, last);
        }
        catch (InvalidRangeException<DateTime> ire)
        {
            Console.WriteLine(ire.Message);
            Console.WriteLine("Begin: {0}, Last: {1}", ire.Begin, ire.Last);
        }
    }
}