/*
* 5. Write a boolean expression for finding if the bit
* 3 (counting from 0) of a given integer is 1 or 0.
*/

using System;
using System.Linq;

class ThirdBit0or1
{
    static void Main(string[] args)
    {
        Console.Write("Enter a number: ");
        int number = int.Parse(Console.ReadLine());

        Console.WriteLine("Third bit of {0} is {1}", number, (number >> 3) & 1);
    }
}