/*
* 2. Write a program that reads two arrays from the
* console and compares them element by element.
*/

using System;
using System.Linq;

class IsTwoArraysEqual
{
    static void Main()
    {
        Console.Write("Enter size of first array: ");
        int[] firstArray = new int[int.Parse(Console.ReadLine())];
        InitializeArray(firstArray);

        Console.Write("\nEnter size of second array: ");
        int[] secondArray = new int[int.Parse(Console.ReadLine())];
        InitializeArray(secondArray);

        CompareTwoArrays(firstArray, secondArray);
    }

    static void InitializeArray(int[] array)
    {
        Console.WriteLine("\nEnter a {0} number(s) to array: ", array.Length);
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write("   {0}: ", i + 1);
            array[i] = int.Parse(Console.ReadLine());
        }
    }

    static void CompareTwoArrays(int[] firstArray, int[] secondArray)
    {
        if (firstArray.Length > secondArray.Length)
        {
            Console.WriteLine("\nResult -> The first array has bigger size than the second one.\n");
        }
        else if (firstArray.Length < secondArray.Length)
        {
            Console.WriteLine("\nResult -> The second array has bigger size than the first one.\n");
        }
        else
        {
            Array.Sort(firstArray);
            Array.Sort(secondArray);

            Console.WriteLine("\nResult: ");
            Console.WriteLine("1) The two arrays have equals sizes.");

            // Compares two arrays element-by-element 
            for (int i = 0; i < firstArray.Length; i++)
            {
                if (firstArray[i] != secondArray[i])
                {
                    Console.WriteLine("2) And different elements.\n");
                    return;
                }
            }

            Console.WriteLine("2) And equal elements.\n");
        }
    }
}