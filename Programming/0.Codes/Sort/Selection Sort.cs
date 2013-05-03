using System;

class Program
{
    static void Main(string[] args)
    {
        int[] array = { 9, 8, 6, 1, 7, 2, 0, 3, 5, 4 };
        int currentValue, indexOfCurrentValue, swap;

        for (int i = 0; i < array.Length - 1; i++)
        {
            currentValue = array[i];
            indexOfCurrentValue = i;

            for (int j = i + 1; j < array.Length; j++)
            {
                if (array[j] < currentValue)
                {
                    currentValue = array[j];
                    indexOfCurrentValue = j;
                }
            }

            swap = array[i];
            array[i] = array[indexOfCurrentValue];
            array[indexOfCurrentValue] = swap;
        }

        for (int i = 0; i < array.Length; i++)
        {
            Console.WriteLine(array[i]);
        }
    }
}
