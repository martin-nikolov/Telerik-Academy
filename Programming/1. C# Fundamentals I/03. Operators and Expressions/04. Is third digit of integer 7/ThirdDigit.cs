/*
* 4. Write an expression that checks for given integer if
* its third digit (right-to-left) is 7. E. g. 1732 -> true
*/

using System;
using System.Linq;

class ThirdDigit
{
    static void Main(string[] args)
    {
        Console.Write("Enter a number (greater than 99): ");
        int number = int.Parse(Console.ReadLine());

        Console.WriteLine("Third digit of {0} is 7: {1}", number, number / 100 % 10 == 7);
    }
}