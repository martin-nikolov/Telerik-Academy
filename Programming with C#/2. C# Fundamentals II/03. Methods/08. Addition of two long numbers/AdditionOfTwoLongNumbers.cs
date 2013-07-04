/*
* 8. Write a method that adds two positive integer numbers
* represented as arrays of digits (each array element arr[i] 
* contains a digit; the last digit is kept in arr[0]). Each of 
* the numbers that will be added could have up to 10 000 digits.
*/

using System;
using System.Collections.Generic;
using System.Linq;

class AdditionOfTwoLongNumbers
{
    static void Main()
    {
        Console.Write("Enter first non-negative number: ");
        string first = Console.ReadLine();

        Console.Write("Enter second non-negative number: ");
        string second = Console.ReadLine();

        if (IsCorrectNumber(first) && IsCorrectNumber(second))
        {
            List<int> result = AccumulateTwoNumbers(first, second);

            Console.Write("\nResult: ");
            PrintResult(result);
        }
        else
        {
            Console.WriteLine("\n-> You have entered an invalid number(s)...\n");
        }
    }

    static bool IsCorrectNumber(string number)
    {
        for (int i = 0; i < number.Length; i++)
            if (number[i] < '0' || number[i] > '9')
                return false;

        return true;
    }

    static List<int> AccumulateTwoNumbers(string first, string second)
    {
        // Here convert string to int[] Array, because
        // according assignment we must represent numbers in Array
        var a = first.Select(ch => ch - '0').ToArray();
        var b = second.Select(ch => ch - '0').ToArray();

        Array.Reverse(a);
        Array.Reverse(b);

        List<int> result = new List<int>(Math.Max(a.Length, b.Length));

        int carry = 0;

        for (int i = 0; i < result.Capacity; i++)
        {
            int num = (i < a.Length ? a[i] : 0) + (i < b.Length ? b[i] : 0) + carry;
            carry = num / 10;
            result.Add(num % 10);
        }

        if (carry > 0) result.Add(carry);

        return result;
    }

    static void PrintResult(List<int> result)
    {
        for (int i = result.Count - 1; i >= 0; i--)
            Console.Write(result[i]);

        Console.WriteLine("\n");
    }
}