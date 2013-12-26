using System;
using System.Diagnostics;

public class MergeSortAlgorithm
{
    static Random randomGenerator = new Random();

    static void Main()
    {
        TestRunner();
        TestForPerformance(300000);
        TestForPerformance(600000);
        TestForPerformance(1200000);
    }

    public static void MergeSort<T>(T[] elements) where T : IComparable<T>
    {
        var temp = new T[elements.Length];
        MergeSort(elements, temp, 0, elements.Length - 1);
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
        var unsortedNumbers = new int[] { 1, -2, 3, -4, 5, -6, 7, -8, 9, -10 };

        Console.Write(string.Join(" ", unsortedNumbers) + " -> ");
        MergeSort(unsortedNumbers);
        Console.WriteLine(string.Join(" ", unsortedNumbers));

        var unsortedDoubleNumbers = new double[] { 1.1, -2.2, 3.3, -4.4, 5.5, -6.6, 7.7, -8.8, 9.9, -10.10 };

        Console.Write(string.Join(" ", unsortedDoubleNumbers) + " -> ");
        MergeSort(unsortedDoubleNumbers);
        Console.WriteLine(string.Join(" ", unsortedDoubleNumbers));

        var unsortedSymbols = new string[] { "b", "d", "c", "a", "f", "w", "z" };

        Console.Write(string.Join(" ", unsortedSymbols) + " -> ");
        MergeSort(unsortedSymbols);
        Console.WriteLine(string.Join(" ", unsortedSymbols));

        var unsortedLetters = new char[] { 'z', 'b', 'd', 'c', 'w', 'a', 'f' };

        Console.Write(string.Join(" ", unsortedLetters) + " -> ");
        MergeSort(unsortedLetters);
        Console.WriteLine(string.Join(" ", unsortedLetters));
    }

    static void TestForPerformance(int capacity)
    {
        Stopwatch sw = new Stopwatch();
        var numbers = new int[capacity];

        for (int i = 0; i < capacity; i++)
            numbers[i] = randomGenerator.Next(int.MaxValue);

        sw.Start();
        MergeSort(numbers);
        sw.Stop();

        Console.WriteLine(sw.Elapsed + " -> " + capacity + " elements.");
    }
}
