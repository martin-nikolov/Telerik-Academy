using System;

class BubbleSort
{
    static void Main()
    {
        int[] array = { 9, 8, 6, 1, 7, 2, 0, 3, 5, 4 };

        for (int i = 0; i < array.Length - 1; i++)
        {
            for (int j = 0; j < array.Length - i - 1; j++)
            {
                if (array[j] > array[j + 1])
                {
                    int swap = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = swap;
                }
            }
        }

        Console.WriteLine(string.Join(" ", array));
    }
}