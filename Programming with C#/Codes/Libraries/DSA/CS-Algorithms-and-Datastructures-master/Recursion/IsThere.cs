using System;

namespace CodingPractice.Recursion
{
    public static class IsThere
    {
        private static int[] arr;

        public static void run()
        {
            arr = new[] {1, 2, 3, 4, 5, 6, 7, 8};
            Console.WriteLine(isThere(76, 0));
        }

        private static bool isThere(int n, int pos)
        {
            if (pos > arr.Length - 1)
                return false;

            if (arr[pos] == n)
                return true;

            return isThere(n, pos + 1);
        }
    }
}