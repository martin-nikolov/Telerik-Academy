/*
* 7. Write a method that reverses the digits of given decimal number. 
* Example: 256 -> 652
*/

using System;
using System.Linq;

class ReverseDigitsOfNumber
{
    static void Main()
    {
        Console.Write("Enter a number (real or integer): ");
        decimal number = decimal.Parse(Console.ReadLine());

        Console.WriteLine("\n{0} -> {1}\n", number, ReverseNumber(number));
    }

    static decimal ReverseNumber(decimal number)
    {
        string temp = number.ToString();
        string result = string.Empty;

        for (int i = temp.Length - 1; i >= 0; i--)
            result += temp[i];

        return decimal.Parse(result);
    }
}