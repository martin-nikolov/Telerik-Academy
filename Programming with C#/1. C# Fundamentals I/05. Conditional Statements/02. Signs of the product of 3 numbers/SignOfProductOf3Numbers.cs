/*
* 2. Write a program that shows the sign (+ or -) of the product
* of three real numbers without calculating it.
* Use a sequence of if statements.
*/

using System;
using System.Linq;

class SignOfProductOf3Numbers
{
    static void Main()
    {
        // First example
        double first = -2.132;
        double second = 4.523;
        double third = -23.42;

        if (first * second * third < 0)
        {
            Console.WriteLine("{0} * {1} * {2} -> sign (-)\n", first, second, third);
        }
        else
        {
            Console.WriteLine("{0} * {1} * {2} -> sign (+)\n", first, second, third);
        }

        // Second example
        first = 2.132;
        second = 4.523;
        third = -23.42;

        if (first * second * third < 0)
        {
            Console.WriteLine("{0} * {1} * {2} -> sign (-)\n", first, second, third);
        }
        else
        {
            Console.WriteLine("{0} * {1} * {2} -> sign (+)\n", first, second, third);
        }
    }
}