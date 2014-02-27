using System;

namespace CodingPractice.Recursion
{
    public static class count7
    {
        public static void run()
        {
            count(217);
        }

        private static void count(int n)
        {
            int temp;

            if (n > 1)
            {
                temp = n%10;
                Console.Write(temp);
                count(n/10);
            }
        }
    }
}