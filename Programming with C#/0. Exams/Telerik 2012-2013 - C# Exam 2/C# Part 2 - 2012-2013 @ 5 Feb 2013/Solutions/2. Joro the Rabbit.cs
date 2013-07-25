using System;
using System.Linq;

class JoroTheRabbit
{
    static int bestLength = 0;

    static void Main()
    {
        int[] numbers = Console.ReadLine().Split(',').Select(ch => Convert.ToInt32(ch)).ToArray();

        FindBestLength(numbers);

        Console.WriteLine(bestLength);
    }

    static void FindBestLength(int[] numbers)
    {
        for (int startIndex = 0; startIndex < numbers.Length; startIndex++)
        {
            for (int step = 1; step <= numbers.Length - 1; step++)
            {
                int index = startIndex;
                int next = (index + step) % numbers.Length;
                int currentLength = 1;

                while (next != startIndex && numbers[index] < numbers[next])
                {
                    index = next;
                    next = (index + step) % numbers.Length;
                    currentLength++;
                }

                if (currentLength > bestLength) bestLength = currentLength;
            }
        }
    }
}