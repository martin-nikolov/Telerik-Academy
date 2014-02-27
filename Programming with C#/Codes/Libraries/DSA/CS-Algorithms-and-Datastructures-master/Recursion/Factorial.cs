using System;

namespace CodingPractice.Recursion
{
    public static class Factorial
    {
        public static void run()
        {
            Console.WriteLine(factorial(4));
        }

        private static int factorial(int n)
        {
            if (n == 0)
                return 1;

            return n*factorial(n - 1);
        }
    }
}