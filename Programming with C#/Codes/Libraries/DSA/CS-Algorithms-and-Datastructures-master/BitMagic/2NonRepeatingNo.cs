using System;

namespace CodingPractice.BitMagic
{
    public static class _2NonRepeatingNo
    {
        private static int[] arr;
        private static int x;
        private static int y;
        private static int SIZE;

        public static void run()
        {
            arr = new[] {2, 3, 7, 9, 11, 2, 3, 11};
            SIZE = arr.Length;
            set2NonRepeatingNos();
            Console.WriteLine(x);
            Console.WriteLine(y);
        }

        private static void set2NonRepeatingNos()
        {
            int xor = arr[0];
            int set_bit_no;
            int i;

            for (i = 0; i < SIZE - 1; i++)
            {
                xor = xor ^ arr[i];
            }

            set_bit_no = xor & ~(xor - 1);

            for (i = 0; i < SIZE; i++)
            {
                if ((arr[i] == set_bit_no)) //not working ... actual code is with & operator
                    x = x ^ arr[i]; /*XOR of first set */
                else
                    y = y ^ arr[i]; /*XOR of second set*/
            }
        }
    }
}