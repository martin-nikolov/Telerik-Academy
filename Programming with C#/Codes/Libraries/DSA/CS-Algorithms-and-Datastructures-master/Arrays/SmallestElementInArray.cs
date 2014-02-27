using System;

namespace CodingPractice
{
    public static class SmallestElementInArray
    {
        public static void run()
        {
            int[] arr = {98, 88, 53, 15, 88, 415, 68, 2};

            Console.WriteLine(minElement(arr));
        }

        private static int minElement(int[] input)
        {
            int min = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] < input[min])
                {
                    min = i;
                }
            }


            return input[min];
        }
    }
}