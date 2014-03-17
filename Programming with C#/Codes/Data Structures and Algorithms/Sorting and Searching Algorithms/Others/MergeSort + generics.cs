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

        PrintElements(unsortedNumbers); Console.Write(" -> ");
        MergeSort(unsortedNumbers, tempNums, 0, unsortedNumbers.Length - 1);
        PrintElements(unsortedNumbers); Console.Write("\n");

        string[] unsortedSymbols = new string[] { "b", "d", "c", "a", "f", "w", "z" };
        string[] tempSymb = new string[unsortedNumbers.Length];

        PrintElements(unsortedSymbols); Console.Write(" -> ");
        MergeSort(unsortedSymbols, tempSymb, 0, unsortedSymbols.Length - 1);
        PrintElements(unsortedSymbols); Console.Write("\n");
        
        char[] unsortedLetters = { 'z', 'b', 'd', 'c', 'w', 'a', 'f' };
        char[] tempLett = new char[unsortedNumbers.Length];

        PrintElements(unsortedLetters); Console.Write(" -> ");
        MergeSort(unsortedLetters, tempLett, 0, unsortedLetters.Length - 1);
        PrintElements(unsortedLetters); Console.Write("\n");
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

    static void PrintElements<T>(T[] unsortedArr)
    {
        foreach (var item in unsortedArr)
        {
            Console.Write(item + " ");
        }
    }
}