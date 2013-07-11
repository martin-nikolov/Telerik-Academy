/*
* 1. Write a program that reads an integer number and calculates
* and prints its square root. If the number is invalid or negative,
* print "Invalid number". In all cases finally print "Good bye".
* Use try-catch-finally.
*/

using System;
using System.Linq;

class SquareRootOfNumber
{
    static void Main()
    {
        try
        {
            Console.Write("Enter a non-negative integer number: ");
            ulong number = ulong.Parse(Console.ReadLine());

            Console.WriteLine("\nSquare root of number {0} is {1}\n", number, Math.Sqrt(number));
        }
        catch (ArgumentNullException ae)
        {
            PrintErrorMessage(ae);
        }
        catch (FormatException fe)
        {
            PrintErrorMessage(fe);
        }
        catch (OverflowException oe)
        {
            PrintErrorMessage(oe);
        }
        finally
        {
            Console.WriteLine("Good bye!\n");
        }
    }

    static void PrintErrorMessage(Exception error)
    {
        Console.Error.WriteLine("\nYou have entered an invalid number!\n-> {0}\n", error.Message);
    }
}