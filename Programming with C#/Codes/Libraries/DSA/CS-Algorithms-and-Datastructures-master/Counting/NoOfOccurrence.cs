using System;

namespace CodingPractice.Counting
{
    public static class NoOfOccurrence
    {
        private static int[] arr;
        private static int SIZE;

        public static void run()
        {
            arr = new[] {1, 1, 2, 2, 2, 3, 3};
            SIZE = arr.Length;
            Console.WriteLine(count(2));
        }

        private static int count(int c)
        {
            int i = first(0, SIZE - 1, c);

            int j = last(0, SIZE - 1, c);

            return j - i + 1;
        }

        private static int first(int low, int high, int c)
        {
            if (low <= high)
            {
                int mid = (low + high)/2;

                if ((mid == 0 || c > arr[mid - 1]) && arr[mid] == c)
                    return mid;
                else if (c > arr[mid])
                    return first(mid + 1, high, c);
                else
                    return first(low, mid - 1, c);
            }

            return -1;
        }

        private static int last(int low, int high, int c)
        {
            if (low <= high)
            {
                int mid = (low + high)/2;

                if ((mid == SIZE - 1 || c < arr[mid + 1]) && arr[mid] == c)
                    return mid;
                else if (c < arr[mid])
                    return last(low, mid - 1, c);
                else
                    return last(mid + 1, high, c);
            }

            return -1;
        }
    }
}