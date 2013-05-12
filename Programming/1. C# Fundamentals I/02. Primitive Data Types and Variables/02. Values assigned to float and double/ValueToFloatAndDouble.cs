/*
* 2. Which of the following values can be assigned to a variable of type float and
* which to a variable of type double: 34.567839023, 12.345, 8923.1234857, 3456.091 ?
*/

using System;

class ValueToFloatAndDouble
{
    static void Main(string[] args)
    {
        double first = 34.567839023;
        float second = 12.345f;
        double third = 8923.1234857;
        float fourth = 3456.091f;

        Console.WriteLine(first + " -> " + first.GetTypeCode());
        Console.WriteLine(second + " -> " + second.GetTypeCode());
        Console.WriteLine(third + " -> " + third.GetTypeCode());
        Console.WriteLine(fourth + " -> " + fourth.GetTypeCode() + Environment.NewLine);
    }
}