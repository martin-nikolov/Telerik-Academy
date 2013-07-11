/*
* 2. Write a method ReadNumber(int start, int end) that enters an
* integer number in given range [start…end]. If an invalid number
* or non-number text is entered, the method should throw an exception.
* Using this method write a program that enters 10 numbers:
* a1, a2, … a10, such that 1 < a1 < … < a10 < 100
*/

using System;
using System.Linq;

class ReadNumbersInGivenRange
{
    static void Main()
    {
        int start = 1, end = 100;

        Console.WriteLine("Enter 10 numbers: \n");

        try
        {
            for (int i = 0; i < 10; i++)
            {
                Console.Write("Enter number [{0}] in range ({1}; {2}): ", i + 1, start, end);
                start = ReadNumber(start, end);
            }
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.Error.WriteLine("\n-> Error! Number was out of the range ({0}; {1})!\n", start, end);
        }
        catch (Exception e)
        {
            Console.Error.WriteLine("\n-> {0} -> {1}\n", e.GetType(), e.Message);
        }
    }

    static int ReadNumber(int start, int end)
    {
        int number = int.Parse(Console.ReadLine());

        if (number <= start || number >= end) throw new ArgumentOutOfRangeException();

        return number;
    }
}