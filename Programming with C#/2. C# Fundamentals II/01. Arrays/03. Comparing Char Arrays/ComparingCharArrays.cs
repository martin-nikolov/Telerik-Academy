/*
* 3. Write a program that compares two char arrays 
* lexicographically (letter by letter).
*/

using System;
using System.Linq;

class ComparingCharArrays
{
    static void Main()
    {
        // String is array of char elements

        Console.Write("Enter first word (on one line, without spaces): ");
        string firstWord = Console.ReadLine();

        Console.Write("\nEnter second word (on one line, without spaces): ");
        string secondWord = Console.ReadLine();

        CompareTwoCharArrays(firstWord, secondWord);

        /* Other way by using prepared comparing method 
           array1.CompareTo(array2) from the .NET library. */

        // CompareMethodByDotNET(firstWord, secondWord);
    }

    // Compares two char arrays lexicographically (letter by letter).
    static void CompareTwoCharArrays(string firstArray, string secondArray)
    {
        int smallerSize = Math.Min(firstArray.Length, secondArray.Length);

        for (int i = 0; i < smallerSize; i++)
        {
            if (firstArray[i] < secondArray[i])
            {
                Console.WriteLine("\nResult -> The first array is lexicographically before the second one.\n");
                return;
            }
            else if (firstArray[i] > secondArray[i])
            {
                Console.WriteLine("\nResult -> The second array is lexicographically before the first one.\n");
                return;
            }
            else if (i == smallerSize - 1 && firstArray.Length != secondArray.Length)
            {
                Console.WriteLine(
                    "\nResult -> The {0} array is lexicographically before the {1} one.\n",
                    firstArray.Length > secondArray.Length ? "second" : "first",
                    firstArray.Length > secondArray.Length ? "first" : "second");
                return;
            }
        }

        // Out of for-loop => equal elements
        Console.WriteLine("\nResult -> The arrays have equal element!\n");
    }

    // Prepared comparing method from the .NET library.
    static void CompareMethodByDotNET(string firstWord, string secondWord)
    {
        if (firstWord.CompareTo(secondWord) == -1)
        {
            Console.WriteLine("Result -> The first array is lexicographically before the second one.\n");
        }
        else if (firstWord.CompareTo(secondWord) == 0)
        {
            Console.WriteLine("Result -> The arrays have equal element!\n");
        }
        else
        {
            Console.WriteLine( "Result -> The second array is lexicographically before the first one.\n");
        }
    }
}