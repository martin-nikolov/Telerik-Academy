namespace Geometria.Utility
{
    using System;

    public class NumberUtilities
    {
        private static readonly string[] digitNames = 
        {
            "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"
        };

        public static string GetDigitName(int digit)
        {
            if (digit < 0 || digit > 9)
            {
                throw new ArgumentException("Digit must be in range [0; 9]");
            }

            return digitNames[digit];
        }

        public static void PrintAsPercent(object number)
        {
            Console.WriteLine("{0:p0}", number);
        }

        public static void PrintWithFixedPoint(object number)
        {
            Console.WriteLine("{0:f2}", number);
        }

        public static void PrintWithRightAlignment(object number)
        {
            Console.WriteLine("{0,8}", number);
        }
    }
}