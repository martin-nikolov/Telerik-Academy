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
        InitializeArray(firstArray, firstArray.Length);

        Console.Write("\nEnter size of second array: ");
        int[] secondArray = new int[int.Parse(Console.ReadLine())];
        InitializeArray(secondArray, secondArray.Length);

        CompareTwoArrays(firstArray, secondArray);
    }

    static void InitializeArray(int[] array, int size)
    {
        for (int i = 0; i < size; i++)
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