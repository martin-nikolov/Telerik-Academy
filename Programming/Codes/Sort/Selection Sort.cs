using System;

class SelectionSort
{
    static void Main()
    {
        int[] array = { 9, 8, 6, 1, 7, 2, 0, 3, 5, 4 };

        for (int i = 0; i < array.Length - 1; i++)
        {
            int index = i;

            for (int j = i + 1; j < array.Length; j++)
                if (array[j] < array[index])
                    index = j;

            int swap = array[i];
            array[i] = array[index];
            array[index] = swap;
        }

        Console.WriteLine(string.Join(" ", array));
    }
}