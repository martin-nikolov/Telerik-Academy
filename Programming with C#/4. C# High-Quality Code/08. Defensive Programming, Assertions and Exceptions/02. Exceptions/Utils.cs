namespace StudentSystem
{
    using System;
    using System.Linq;

    public static class Utils
    {
        public static T[] Subsequence<T>(T[] arr, int startIndex, int count)
        {
            if (arr == null)
            {
                throw new ArgumentException("Array cannot be null");
            }

            if (count < 0)
            {
                throw new ArgumentException("Invalid count value.");
            }

            var result = arr.Skip(startIndex).Take(count).ToArray();
            return result;
        }

        public static string ExtractEnding(string str, int count)
        {
            if (count < 0)
            {
                throw new ArgumentException("Invalid count value.");
            }

            if (count > str.Length)
            {
                count = str.Length;
            }

            var result = str.Substring(str.Length - count);
            return result;
        }

        public static bool CheckPrime(int number)
        {
            if (number <= 0)
            {
                throw new ArgumentException("Number cannot be less or equal to zero.");
            }

            bool isPrime = true;

            for (int divisor = 2; divisor <= Math.Sqrt(number); divisor++)
            {
                if (number % divisor == 0)
                {
                    isPrime = false;
                    break;
                }
            }

            return isPrime;
        }
    }
}