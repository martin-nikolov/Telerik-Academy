/*
* 15. *Modify your last program and try to make it work for any number type,
* not just integer (e.g. decimal, float, byte, etc.).
* Use generic method (read in Internet about generic methods in C#).
*/

using System;
using System.Linq;

class CalculatesMethodsGenericTypes
{
    static K GetMin<K>(params K[] numbers) where K : IComparable<K>
    {
        int minIndex = 0;

        for (int i = 1; i < numbers.Length; i++)
            if (numbers[i].CompareTo(numbers[minIndex]) == -1) minIndex = i;

        return numbers[minIndex];
    }

    static K GetMax <K>(params K[] numbers) where K : IComparable<K>
    {
        int maxIndex = 0;

        for (int i = 1; i < numbers.Length; i++)
            if (numbers[i].CompareTo(numbers[maxIndex]) == 1) maxIndex = i;

        return numbers[maxIndex];
    }

    static K GetSum<K>(params K[] numbers) where K : IComparable<K>
    {
        dynamic sum = 0;

        for (int i = 0; i < numbers.Length; i++) sum += numbers[i];

        return sum;
    }

    static float GetAverageSum<K>(params K[] numbers) where K : IComparable<K>
    {
        dynamic averageSum = 0;

        for (int i = 0; i < numbers.Length; i++) averageSum += numbers[i];

        return averageSum / numbers.Length;
    }

    static K GetProduct<K>(params K[] numbers) where K : IComparable<K>
    {
        dynamic product = 1;

        for (int i = 0; i < numbers.Length; i++) product *= numbers[i];

        return product;
    }

    static void Main()
    {
        Console.WriteLine("The minimum of set numbers: {0}", GetMin(1, 2, 3, 4, 5, 6, 7, 8, 9));
        Console.WriteLine("The maximum of set numbers: {0}", GetMax(1.1, 2.2, 3.3, 4.4, 5.5, 6.6, 7.7, 8.8, 9.9));
        Console.WriteLine("The average sum of set numbers: {0}", GetAverageSum(1, 2, 3, 4, 5, 6, 7, 8, 9));
        Console.WriteLine("The sum of set numbers: {0}", GetSum(0.1, 0.2, 0.3, 0.4, 0.5, 0.6, 0.7, 0.8, 0.9));
        Console.WriteLine("The product of set numbers: {0}\n", GetProduct(1, 2, 3, 4, 5, 6, 7, 8, 9));
    }
}