using System;

class MergeSortAlgorithm
{
    static void Main()
    {
        TestRunner();
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

        for (int index = left; index <= right; index++) arr[index] = tempArr[index];
    }
}
