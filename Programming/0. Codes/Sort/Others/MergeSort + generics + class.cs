using System;

class MergeSortAlgorithm
{
    static void Main()
    {
        TestRunner();
    }

    static void TestRunner()
    {
        Array<int> numbers = new Array<int>(1, -2, 3, -4, 5, -6, 7, -8, 9, -10);
        Array<string> symbols = new Array<string>("b", "d", "c", "a", "f", "w", "z");
        Array<char> letters = new Array<char>('z', 'b', 'd', 'c', 'w', 'a', 'f');
        Array<byte> empty = new Array<byte>();

        numbers.Sort();
        symbols.Sort();
        letters.Sort();
        empty.Sort();

        numbers.PrintElementsByDescending();
        numbers.PrintElementsByAscending();

        symbols.PrintElementsByDescending();
        symbols.PrintElementsByAscending();

        letters.PrintElementsByDescending();
        letters.PrintElementsByAscending();

        empty.PrintElementsByDescending();
        empty.PrintElementsByAscending();
    }

    static void MergeSort<T>(T[] unsortedArr, T[] tempArr, int left, int right) where T : IComparable<T>
    {
        // Array with 1 element
        if (left >= right)
            return;

        // Define middle of the array
        int middle = left + (right - left) / 2;

        MergeSort(unsortedArr, tempArr, left, middle);
        MergeSort(unsortedArr, tempArr, middle + 1, right);

        CompareAndSort(unsortedArr, tempArr, left, middle, right);
    }

    static void CompareAndSort<T>(T[] arr, T[] tempArr, int left, int middle, int right) where T : IComparable<T>
    {
        int leftIndexArr = left, middleIndexArr = middle + 1, leftTemp = left;

        while (leftIndexArr <= middle && middleIndexArr <= right)
            if (arr[leftIndexArr].CompareTo(arr[middleIndexArr]) < 0)
                tempArr[leftTemp++] = arr[leftIndexArr++];
            else
                tempArr[leftTemp++] = arr[middleIndexArr++];

        while (leftIndexArr <= middle)
            tempArr[leftTemp++] = arr[leftIndexArr++];

        while (middleIndexArr <= right)
            tempArr[leftTemp++] = arr[middleIndexArr++];

        for (int index = left; index <= right; index++)
            arr[index] = tempArr[index];
    }

    public class Array<T> where T : IComparable<T>
    {
        private readonly T[] array;

        public Array(params T[] array)
        {
            this.array = array;
        }

        public void Sort()
        { 
            T[] temp = new T[array.Length];
            MergeSort(array, temp, 0, array.Length - 1);     
        }

        public void PrintElementsByDescending()
        {
            if (array.Length == 0)
            {
                Console.WriteLine("No items in array for sorting!");
                return;
            }

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }

            Console.WriteLine();
        }

        public void PrintElementsByAscending()
        {
            if (array.Length == 0)
            {
                Console.WriteLine("No items in array for sorting!");
                return;
            }

            for (int i = array.Length - 1; i >= 0; i--)
            {
                Console.Write(array[i] + " ");
            }

            Console.WriteLine();
        }
    }
}