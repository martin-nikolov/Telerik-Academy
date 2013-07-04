/*
* 6. Write a method that returns the index of the first element
* in array that is bigger than its neighbors, or -1, if there’s 
* no such element.
* Use the method from the previous exercise.
*/

using System;
using System.Linq;

public class FirstBiggerThanNeighbours
{
    public static int FindFirstBiggerThanNeighbours(int[] numbers)
    {
        for (int index = 0; index < numbers.Length; index++)
        {
            if (IsBiggerThanItsNeighbours(numbers, index))
                return index;
        }

        return -1;
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

        int index = FindFirstBiggerThanNeighbours(numbers);

        if (index != -1)
        {
            Console.WriteLine("\nFirst number bigger than its neighbours -> number: {0} at index: {1}\n",
                numbers[index], index);
        }
        else
        {
            Console.WriteLine("\nThere is no number bigger than its neighbours...\n");
        }
    }

    static bool IsBiggerThanItsNeighbours(int[] numbers, int index)
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
}