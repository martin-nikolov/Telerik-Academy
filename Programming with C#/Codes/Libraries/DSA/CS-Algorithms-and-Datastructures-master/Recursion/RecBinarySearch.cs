using System;
using System.Threading;

namespace CodingPractice.Recursion
{
    public static class RecBinarySearch
    {
        private static int[] numbers;

        public static void run()
        {
            numbers = new[] {1, 2, 3, 4};
            Console.WriteLine(search(2, 0, numbers.Length - 1));

			  Thread.Sleep(1000);
        }

        private static bool search(int n, int low, int high)
        {
            if (low > high)
                return false;
            int mid = (low + high)/2;

            if (numbers[mid] == n)
                return true;
            if (n > numbers[mid])
                low = mid + 1;
            if (n < numbers[mid])
                high = mid - 1;

            return search(n, low, high);
        }
    }
}