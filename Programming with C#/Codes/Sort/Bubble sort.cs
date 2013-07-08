using System;

class BubbleSort
{
    static void Main()
    {
        int[] numbers = { 9, 8, 6, 1, 7, 2, 0, 3, 5, 4 };
        bool flag = false; // Optimization

        for (int i = 0; i < numbers.Length - 1; i++)
        {
            for (int j = 0; j < numbers.Length - i - 1; j++)
            {
                if (numbers[j] > numbers[j + 1])
                {
                    int swap = numbers[j];
                    numbers[j] = numbers[j + 1];
                    numbers[j + 1] = swap;
                    flag = true;
                }
            }

            if (!flag) break;
        }

        Console.WriteLine(string.Join(" ", numbers));
    }
}