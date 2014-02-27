using System;
using CodingPractice.Sorts;

namespace CodingPractice
{
    public static class AreConsecutive
    {
        private static int[] arr;
        private static int SIZE;

        public static void run()
        {
            arr = new[] {83, 78, 80, 81, 79, 82};
            SIZE = arr.Length;

            Console.WriteLine(areConsecutive());
        }


        private static bool areConsecutive()
        {
            bool areConsecutive = true;
            arr = QuickSort.sort(arr);

            for (int i = 1; i < SIZE; i++)
            {
                if (arr[i] - arr[i - 1] > 1)
                {
                    areConsecutive = false;
                }
            }

            return areConsecutive;
        }
    }
}