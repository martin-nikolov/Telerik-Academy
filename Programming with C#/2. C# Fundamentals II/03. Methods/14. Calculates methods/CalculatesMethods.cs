/*
* 14. Write methods to calculate minimum, maximum, average, sum 
* and product of given set of integer numbers. 
* Use variable number of arguments.
*/

using System;
using System.Linq;

class CalculatesMethods
{
    static int GetMin(params int[] numbers)
    {
        int min = numbers[0];

        for (int i = 1; i < numbers.Length; i++)
            if (numbers[i] < min) min = numbers[i];

        return min;
    }

    static int GetMax(params int[] numbers)
    {
        int max = numbers[0];

        for (int i = 1; i < numbers.Length; i++)
            if (numbers[i] > max) max = numbers[i];

        return max;
    }

    static int GetSum(params int[] numbers)
    {
        int sum = 0;

        for (int i = 0; i < numbers.Length; i++) sum += numbers[i];

        return sum;
    }

    static float GetAverageSum(params int[] numbers)
    {
        return GetSum(numbers) / numbers.Length;
    }

    static int GetProduct(params int[] numbers)
    {
        int product = 1;

        for (int i = 0; i < numbers.Length; i++) product *= numbers[i];

        return product;
    }

    static void Main()
    {
        Console.WriteLine("The Minimum of set integers: {0}", GetMin(1, 2, 3, 4, 5, 6, 7, 8, 9));
        Console.WriteLine("The Maximum of set integers: {0}", GetMax(1, 2, 3, 4, 5, 6, 7, 8, 9));
        Console.WriteLine("The Average Sum of set integers: {0}", GetAverageSum(1, 2, 3, 4, 5, 6, 7, 8, 9));
        Console.WriteLine("The Sum of set integers: {0}", GetSum(1, 2, 3, 4, 5, 6, 7, 8, 9));
        Console.WriteLine("The Product of set integers: {0}\n", GetProduct(1, 2, 3, 4, 5, 6, 7, 8, 9));
    }
}