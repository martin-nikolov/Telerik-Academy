using System;

namespace CodingPractice.Arrays
{
    public static class RecArrayReverse
    {
        private static int[] arr;
        private static int SIZE;

        public static void run()
        {
            arr = new[] {1, 2, 3, 4, 5, 6, 7, 8};
            SIZE = arr.Length - 1;
			  	reverse(0, SIZE);
            Console.WriteLine(string.Join(",", arr));
        }

        public static void reverse(int low, int high)
        {
            if (high <= low) return;
            int temp = arr[low];
            arr[low] = arr[high];
            arr[high] = temp;
        		reverse(low + 1, high - 1);
        }
    }
}