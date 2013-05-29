using System;

class Program
{
    static int BinSearch(int[] array, int key)
    {
        Array.Sort(array);
        int min = 0;
        int max = array.Length - 1;

        while (max >= min)
        {
            int point = (min + max) / 2;

            if (array[point] > key)
            {
                max = point - 1;
            }
            else if (array[point] < key)
            {
                min = point + 1;
            }
            else if (array[point] == key)
            {
                return point;
            }
        }

        return -1;
    }

    static void Main(string[] args)
    {
        int[] myArray = { 9, 1, 0, 2, 8, 5, 7, 6, 3, 4 };
        int key = 0;

        Console.WriteLine(BinSearch(myArray, key));
    }
}
