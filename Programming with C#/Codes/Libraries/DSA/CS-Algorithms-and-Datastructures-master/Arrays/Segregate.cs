using System;

namespace PlayGround
{
    public class Segregate
    {
        public static void run()
        {
            int[] arr = {0, 1, 0, 1, 0, 1};
            int arr_size = arr.Length;
            sort(arr, arr_size);

            foreach (int i in arr)
            {
                Console.Write(i);
                Console.Write(",");
            }

            Console.WriteLine();
        }

        private static void sort(int[] arr, int size)
        {
            int left = 0;
            int right = size - 1;

            //{0, 1, 0, 1, 0, 1};
            while (left < right)
            {
                while (arr[left] == 0 && left < right)
                    left++;
                while (arr[right] == 1 && left < right)
                    right--;

                if (left < right)
                {
                    arr[left] = 0;
                    arr[right] = 1;
                    left++;
                    right--;
                }
            }
        }
    }
}