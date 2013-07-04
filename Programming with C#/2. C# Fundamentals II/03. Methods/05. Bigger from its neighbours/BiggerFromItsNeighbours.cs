/*
* 5. Write a method that checks if the element at given position
* in given array of integers is bigger than its two neighbors (when such exist).
*/

using System;
using System.Linq;

public class BiggerFromItsNeighbours
{
    public static bool IsBiggerThanItsNeighbours(int[] numbers, int index)
    {
        // Note: If exist only one neighbour method compares numbers[index] to 
        // its neighbour and return result of their comparison [true/false]...

        if (index < 0 || index >= numbers.Length)
            throw new IndexOutOfRangeException();

        else if (index == numbers.Length - 1 && numbers.Length > 1)
        {
            return numbers[index - 1] < numbers[index];
        }
        else if (index == 0 && numbers.Length > 1)
        {
            return numbers[index] > numbers[index + 1];
        }
        else
        {
            // Number is between other two numbers
            return numbers[index - 1] < numbers[index] && numbers[index] > numbers[index + 1];
        }
    }

    static void Main()
    {
        Console.Write("Enter a number N (size of array): ");
        int n = int.Parse(Console.ReadLine());

        int[] numbers = new int[n];
        Console.WriteLine("\nEnter a {0} number(s) to array: ", n);
        for (int i = 0; i < numbers.Length; i++)
        {
            Console.Write("   {0}: ", i);
            numbers[i] = int.Parse(Console.ReadLine());
        }

        Console.Write("\nEnter the position (index) of number in array: ");
        int index = int.Parse(Console.ReadLine());

        Console.WriteLine("\nNumber {0} (at index {1}) is bigger than its neighbours -> {2}\n",
            numbers[index], index, IsBiggerThanItsNeighbours(numbers, index));
    }
}