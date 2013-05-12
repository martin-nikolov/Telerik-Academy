/*
* 13. Create a program that assigns null values to an integer and to double variables.
* Try to print them on the console, try to add some values or the null literal
* to them and see the result.
*/

using System;

class NullableValuesTest
{
    static void Main(string[] args)
    {
        int? x = null;
        double? y = null;

        Console.WriteLine(x); // white space
        Console.WriteLine(y); // white space

        x = x + 5;
        y = y + 0.55;

        Console.WriteLine(x); // again white space
        Console.WriteLine(y); // again white space

        x = 5;
        y = 0.55;

        Console.WriteLine(x); // 5
        Console.WriteLine(y); // 0.55
    }
}