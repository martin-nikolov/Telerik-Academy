using System;
using System.Linq;
 
class Program
{
    static void CompareAndSort(int[] unsorted_arr, int[] temp, int left, int middle, int right)
    {
        int left_unsorted = left, middle_unsorted = middle + 1, left_temp = left;
 
        while (left_unsorted <= middle && middle_unsorted <= right)
            if (unsorted_arr[left_unsorted] < unsorted_arr[middle_unsorted]) temp[left_temp++] = unsorted_arr[left_unsorted++];
            else temp[left_temp++] = unsorted_arr[middle_unsorted++];
 
        while (left_unsorted <= middle) temp[left_temp++] = unsorted_arr[left_unsorted++];
        while (middle_unsorted <= right) temp[left_temp++] = unsorted_arr[middle_unsorted++];
 
        for (int index = left; index <= right; index++)
        {
            unsorted_arr[index] = temp[index];
        }
    }
 
    static void MergeSort(int[] unsorted_arr, int[] temp, int left, int right)
    {
        if (left >= right) return; // Array with 1 element
 
        int middle = left + (right - left) / 2; // Define middle of the array
 
        MergeSort(unsorted_arr, temp, left, middle); // Start from the beggining to the middle
        MergeSort(unsorted_arr, temp, middle + 1, right); // Start from the middle+1 to the end
 
        CompareAndSort(unsorted_arr, temp, left, middle, right);
    }
 
    static void Main()
    {
        int[] unsorted_arr = { 1, -2, 3, -4, 5, -6 };
 
        int[] temp = new int[unsorted_arr.Length];
 
        MergeSort(unsorted_arr, temp, 0, unsorted_arr.Length - 1);
 
        for (int index = 0; index < unsorted_arr.Length; index++)
        {
            Console.Write(unsorted_arr[index] + " ");
        }
    }
}