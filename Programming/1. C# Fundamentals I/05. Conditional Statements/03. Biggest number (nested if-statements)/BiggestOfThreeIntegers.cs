/*
* Enter discription of the problem...
*/

using System;
using System.Linq;

class BiggestOfThreeIntegers
{
    static void Main()
    {
        Console.WriteLine("Enter three numbers: ");
        Console.Write("   1: "); decimal first = decimal.Parse(Console.ReadLine());
        Console.Write("   2: "); decimal second = decimal.Parse(Console.ReadLine());
        Console.Write("   3: "); decimal third = decimal.Parse(Console.ReadLine());

        if (first > second)
        {
            if (second > third)
            {
                Console.WriteLine("\nBiggest number: {0}\n", first);
            }
            else if (third > second)
            {
                if (third > first)
                {
                    Console.WriteLine("\nBiggest number: {0}\n", third);
                }
                else
                {
                    Console.WriteLine("\nBiggest number: {0}\n", first);
                }
            }
        }
        else if (second > third)
        {
            Console.WriteLine("\nBiggest number: {0}\n", second);
        }
        else
        {
            Console.WriteLine("\nBiggest number: {0}\n", third);
        }
    }
}