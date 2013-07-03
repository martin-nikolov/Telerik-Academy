/*
* 5. Write program that asks for a digit and depending on the
* input shows the name of that digit (in English) using
* a switch statement.
*/

using System;
using System.Linq;

class NameOfDigit
{
    static void Main()
    {
        Console.Write("Enter a digit [0;9]: ");
        byte digit = byte.Parse(Console.ReadLine());
        Console.Write("\nResult: ");
        GetNameOfDigit(digit);

        Console.WriteLine("\nList of all numbers:");
        for (byte i = 0; i <= 9; i++)
            GetNameOfDigit(i);
    }
  
    static void GetNameOfDigit(byte digit)
    {
        switch (digit)
        {
            case 0:
                Console.WriteLine("{0} -> Zero", digit);
                break;
            case 1:
                Console.WriteLine("{0} -> One", digit);
                break;
            case 2:
                Console.WriteLine("{0} -> Two", digit);
                break;
            case 3:
                Console.WriteLine("{0} -> Three", digit);
                break;
            case 4:
                Console.WriteLine("{0} -> Four", digit);
                break;
            case 5:
                Console.WriteLine("{0} -> Five", digit);
                break;
            case 6:
                Console.WriteLine("{0} -> Six", digit);
                break;
            case 7:
                Console.WriteLine("{0} -> Seven", digit);
                break;
            case 8:
                Console.WriteLine("{0} -> Eight", digit);
                break;
            case 9:
                Console.WriteLine("{0} -> Nine", digit);
                break;
            default:
                Console.WriteLine("Value [{0}] is out of the range [0,9]...", digit);
                break;
        }
    }
}