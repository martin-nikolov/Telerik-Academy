using System;
using System.Collections.Generic;
using System.Linq;

class PinsInSwissCheese
{
    static void Main()
    {
        var input = Console.ReadLine();
        var numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        var pins = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        var numbersIndeces = FindPositiveNumbersIndeces(numbers);

        Console.WriteLine(string.Join(" ", FindIndeces(numbers, pins, numbersIndeces)));
    }

    static int[] FindIndeces(int[] numbers, int[] pins, IList<int> numbersIndeces)
    {
        int[] choosenIndeces = new int[pins.Length];

        // 100% of numbers are zeroes => no middle index
        if (numbersIndeces.Count == 0) return choosenIndeces;

        int middleIndex = numbersIndeces[numbersIndeces.Count / 2]; // Binary Search Median

        for (int i = 0; i < pins.Length; i++)
        {
            int startIndex = 0, endIndex = numbersIndeces.Count - 1, currentIndex = numbersIndeces[0];

            // Optimization -> Binary Search
            if (numbers[middleIndex] > pins[i]) endIndex = middleIndex;
            else startIndex = numbersIndeces.Count / 2;

            // Check if index 0 or last index are answers
            if (numbers[currentIndex] >= pins[i])
            {
                choosenIndeces[i] = 0; 
                continue;
            }
            else if (numbers[numbersIndeces[numbersIndeces.Count - 1]] < pins[i])
            {
                choosenIndeces[i] = numbersIndeces[numbersIndeces.Count - 1] + 1; 
                continue;
            }
              
            for (int j = startIndex; j <= endIndex; j++)
            {
                currentIndex = numbersIndeces[j];

                if (numbers[currentIndex] >= pins[i])
                {
                    choosenIndeces[i] = numbersIndeces[j - 1] + 1;
                    break;
                }
            }
        }

        return choosenIndeces;
    }

    static IList<int> FindPositiveNumbersIndeces(int[] numbers)
    {
        var numbersIndeces = new List<int>();

        for (int i = 0; i < numbers.Length; i++)
            if (numbers[i] != 0) numbersIndeces.Add(i);

        return numbersIndeces;
    }
}