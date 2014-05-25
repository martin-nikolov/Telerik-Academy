/*
 * 3. Write a program to compare the performance of square root,
 * natural logarithm, sinus for float, double and decimal values.
 */

namespace Performance
{
    using System;
    using System.Diagnostics;
    using System.Linq;

    internal class MathFuncPerformance
    {
        private static readonly Stopwatch sw = new Stopwatch();
        private static readonly Random rnd = new Random();

        private const int Count = 5000000;
        private const int SquareRootPower = 2;

        static void Main()
        {
            FloatTest();
            DoubleTest();
            DecimalTest();
        }

        static void FloatTest()
        {
            sw.Start();
            float result = 0f;

            for (int i = 0; i < Count; i++)
            {
                result = (float)Math.Pow(GetRandomDouble(), SquareRootPower); // Square root
                result = (float)Math.Log10(GetRandomDouble()); // Natural Log
                result = (float)Math.Sin(GetRandomDouble()); // Sinus
            }

            sw.Stop();
            Console.WriteLine("Float test passed. Total elapsed: " + sw.Elapsed);
            sw.Reset();
        }

        static void DoubleTest()
        {
            sw.Start();
            double result = 0d;

            for (int i = 0; i < Count; i++)
            {
                result = Math.Pow(GetRandomDouble(), SquareRootPower); // Square root
                result = Math.Log10(GetRandomDouble()); // Natural Log
                result = Math.Sin(GetRandomDouble()); // Sinus
            }

            sw.Stop();
            Console.WriteLine("Double test passed. Total elapsed: " + sw.Elapsed);
            sw.Reset();
        }

        static void DecimalTest()
        {
            sw.Start();
            decimal result = 0m;

            for (int i = 0; i < Count; i++)
            {
                result = (decimal)Math.Pow(GetRandomDouble(), SquareRootPower); // Square root
                result = (decimal)Math.Log10(GetRandomDouble()); // Natural Log
                result = (decimal)Math.Sin(GetRandomDouble()); // Sinus
            }

            sw.Stop();
            Console.WriteLine("Decimal test passed. Total elapsed: " + sw.Elapsed);
            sw.Reset();
        }

        static double GetRandomDouble()
        {
            var randomDouble = rnd.NextDouble() * rnd.Next(1, int.MaxValue);
            return randomDouble;            
        }
    }
}