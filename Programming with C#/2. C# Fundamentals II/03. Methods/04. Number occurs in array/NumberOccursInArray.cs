/*
* 4. Write a method that counts how many times given number
* appears in given array. Write a test program to check if 
* the method is working correctly.
*/

using System;
using System.Linq;

public class NumberOccursInArray
{
    public static int GetNumberOfOccurs(int[] numbers, int searchedNumber)
    {
        int count = 0;

        for (int i = 0; i < numbers.Length; i++)
            if (numbers[i] == searchedNumber)
                count++;

        return count;
    }

    static void Main()
    {
        Console.Write("Enter a number N (size of array): ");
        int n = int.Parse(Console.ReadLine());

        int[] numbers = new int[n];
        Console.WriteLine("\nEnter a {0} number(s) to array: ", n);
        for (int i = 0; i < numbers.Length; i++)
        {
            Console.Write("   {0}: ", i + 1);
            numbers[i] = int.Parse(Console.ReadLine());
        }

        Console.Write("\nEnter a searched number: ");
        int searchedNumber = int.Parse(Console.ReadLine());

        Console.WriteLine("\nNumber {0} occurs {1} time(s) in the array!\n", searchedNumber,
            GetNumberOfOccurs(numbers, searchedNumber));
    }
}