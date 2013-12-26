using System;
using System.Diagnostics;

class MergeSortAlgorithm
{ 
    static Random rnd = new Random();
    static Stopwatch sw = new Stopwatch();

    static void Main()
    {
        TestRunner();
        TestForPerformance(300000);
        TestForPerformance(600000);
        TestForPerformance(1200000);
    }

    static void MergeSort<T>(T[] unsortedArr, T[] tempArr, int left, int right) where T : IComparable<T>
    {
        // Array with 1 element
        if (left >= right) return;

        // Define a middle of the array
        int middle = (left + right) / 2;

        MergeSort(unsortedArr, tempArr, left, middle);
        MergeSort(unsortedArr, tempArr, middle + 1, right);

        CompareAndSort(unsortedArr, tempArr, left, middle, right);
    }

    static void CompareAndSort<T>(T[] arr, T[] tempArr, int left, int middle, int right) where T : IComparable<T>
    {
        int i = left; // 'temp' indexes
        int l = left, m = middle + 1; // 'arr' indexes

        while (l <= middle && m <= right)
            if (arr[l].CompareTo(arr[m]) < 0) tempArr[i++] = arr[l++];
            else tempArr[i++] = arr[m++];

        while (l <= middle) tempArr[i++] = arr[l++];

        while (m <= right) tempArr[i++] = arr[m++];

        Array.Copy(tempArr, left, arr, left, right - left + 1);
    }

    static void TestRunner()
    {
        int[] unsortedNumbers = { 1, -2, 3, -4, 5, -6, 7, -8, 9, -10 };
        int[] tempNums = new int[unsortedNumbers.Length];

        Console.Write(string.Join(" ", unsortedNumbers) + " -> ");
        MergeSort(unsortedNumbers, tempNums, 0, unsortedNumbers.Length - 1);
        Console.WriteLine(string.Join(" ", unsortedNumbers));

        var unsortedDoubleNumbers = new double[] { 1.1, -2.2, 3.3, -4.4, 5.5, -6.6, 7.7, -8.8, 9.9, -10.10 };
        var tempDoubleNums = new double[unsortedDoubleNumbers.Length];

        Console.Write(string.Join(" ", unsortedDoubleNumbers) + " -> ");
        MergeSort(unsortedDoubleNumbers, tempDoubleNums, 0, unsortedDoubleNumbers.Length - 1);
        Console.WriteLine(string.Join(" ", unsortedDoubleNumbers));

        string[] unsortedSymbols = new string[] { "b", "d", "c", "a", "f", "w", "z" };
        string[] tempSymb = new string[unsortedDoubleNumbers.Length];

        Console.Write(string.Join(" ", unsortedSymbols) + " -> ");
        MergeSort(unsortedSymbols, tempSymb, 0, unsortedSymbols.Length - 1);
        Console.WriteLine(string.Join(" ", unsortedSymbols));

        char[] unsortedLetters = { 'z', 'b', 'd', 'c', 'w', 'a', 'f' };
        char[] tempLett = new char[unsortedDoubleNumbers.Length];

        Console.Write(string.Join(" ", unsortedLetters) + " -> ");
        MergeSort(unsortedLetters, tempLett, 0, unsortedLetters.Length - 1);
        Console.WriteLine(string.Join(" ", unsortedLetters));
    }

    static void TestForPerformance(int capacity)
    {
        var numbers = new int[capacity];
        var temp = new int[capacity];

        for (int i = 0; i < capacity; i++)
            numbers[i] = rnd.Next(int.MaxValue);

        sw.Start();
        MergeSort(numbers, temp, 0, capacity - 1);
        sw.Stop();

        Console.WriteLine(sw.Elapsed + " -> " + capacity + " elements.");
    }
}
