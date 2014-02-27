using System;

namespace CodingPractice.BitMagic
{
    public static class RepeatingAndMissing
    {
        private static int[] arr;
        private static int SIZE;
        private static int x;
        private static int y;

        public static void run()
        {
            arr = new[] {3, 1, 3};
            SIZE = arr.Length;
            getTwoNumbers();

            Console.WriteLine("Missing number {0} and Repeating number {1}", x, y);
        }

        private static void getTwoNumbers()
        {
            int xor1 = arr[0]; /* Will hold xor of all elements and numbers from 1 to n */
            int set_bit_no; /* Will have only single set bit of xor1 */

            for (int i = 1; i < SIZE; i++)
                xor1 = xor1 ^ arr[i];

            Console.WriteLine(xor1);

            for (int i = 1; i < SIZE; i++)
                xor1 = xor1 ^ i;

            Console.WriteLine(xor1);

            /* Get the rightmost set bit in set_bit_no */
            set_bit_no = xor1 & ~(xor1 - 1);

            Console.WriteLine(set_bit_no);

            /* Now divide elements in two sets by comparing rightmost set
            bit of xor1 with bit at same position in each element. Also, get XORs
            of two sets. The two XORs are the output elements.
            The following two for loops serve the purpose */
            for (int i = 0; i < SIZE; i++)
            {
                if ((arr[i] & set_bit_no) == 0)
                    x = x ^ arr[i]; /* arr[i] belongs to first set */
                else
                    y = y ^ arr[i]; /* arr[i] belongs to second set*/
            }
            for (int i = 1; i <= SIZE; i++)
            {
                if ((i & set_bit_no) == 0)
                    x = x ^ i; /* i belongs to first set */
                else
                    y = y ^ i; /* i belongs to second set*/
            }
        }
    }
}