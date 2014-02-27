using System;

namespace CodingPractice
{
    public static class BinarySearch
    {
        public static void run()
        {
            int[] arr = {1, 2, 3, 4, 5, 6, 7, 8, 9};
            const int elementToSearch = 18;
            Console.WriteLine(binarySearch(arr, elementToSearch));
        }

        private static bool binarySearch(int[] input, int element)
        {
            int low = 0;
            int high = input.Length - 1;

            while (low <= high)
            {
                int mid = (low + high)/2;

                //if (input[mid] == element)
                //{
                //    return true;
                //}
                if (element < input[mid]) //if less than mid
                    high = mid - 1;
                else if (element > input[mid]) // if greater than mid
                    low = mid + 1;
                else
                    return true;
            }

            return false;
        }
    }
}