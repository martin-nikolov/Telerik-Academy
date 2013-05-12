/*
* 2. Write a boolean expression that checks for given integer if
* it can be divided (without remainder) by 7 and 5 in the same time.
*/

using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter a number: ");
        int number = int.Parse(Console.ReadLine());
        Console.WriteLine(
            "Number {0} can be devided (without remainder) by 7 and 5 in the same time: {1}", number, number % 35 == 0);
    }
}