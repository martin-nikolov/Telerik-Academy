using System;

class Program
{
    static void Main(string[] args)
    {
        int[] array = { 9, 8, 6, 1, 7, 2, 0, 3, 5, 4 };

        //Sorting array
        for (int i = 0; i < array.Length - 1; i++)
        {
            int min = array[i];

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

        //Printing the sorted array
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(array[i] + " ");
        }
    }
}
