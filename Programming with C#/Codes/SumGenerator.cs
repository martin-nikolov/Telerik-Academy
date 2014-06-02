using System;
using System.Linq;

public class UniqueSumGenerator
{
    private static readonly int myNumber = 20;
    private static readonly int maxElements = 6;
    private static readonly int maxNumber = 5;
    private static readonly int[] numbers = new int[maxElements];

    static void GenerateSums(int number, int index)
    {
        int kMax = Math.Min(number, maxNumber);
        for (int k = kMax; k >= 1; k--)
        {
            numbers[index] = k;
            if (index == 0 || numbers[index] <= numbers[index - 1])
            {
                if (number - k == 0)
                {
                    var elements = numbers.Take(index + 1);
                    Console.WriteLine("{0} = {1}", elements.Sum(), string.Join(" + ", elements));
                }
                else if (index < numbers.Length - 1)
                {
                    GenerateSums(number - k, index + 1);
                }
            }
        }
    }

    static void Main()
    {
        GenerateSums(myNumber, 0);
    }
}