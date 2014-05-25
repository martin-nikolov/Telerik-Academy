/*
 * 2. Write a program to compare the performance of add, subtract,
 * increment, multiply, divide for int, long, float, double and decimal values.
 */

namespace Performance
{
    using System;
    using System.Diagnostics;
    using System.Linq;

    internal class MathOperationsPerformance
    {
        private static readonly Stopwatch sw = new Stopwatch();
        private static readonly Random rnd = new Random();

        private const int Count = 10000000;

        static void Main()
        {
            IntTest();
            LongTest();
            FloatTest();
            DoubleTest();
            DecimalTest();
        }

        static void IntTest()
        {
            int result = GetRandomValue();
            sw.Start();

            for (int i = 0; i < Count; i++)
            {
                unchecked
                {
                    result += GetRandomValue(); // Add
                    result -= GetRandomValue(); // Subtract
                    result++; // Increment
                    result *= GetRandomValue(); // Multiply
                    result /= GetRandomValue(); // Divide
                }
            }

            sw.Stop();
            Console.WriteLine("Int test passed. Total elapsed: " + sw.Elapsed);
            sw.Reset();
        }

        static void LongTest()
        {
            long result = GetRandomValue();
            sw.Start();

            for (int i = 0; i < Count; i++)
            {
                unchecked
                {
                    result += GetRandomValue(); // Add
                    result -= GetRandomValue(); // Subtract
                    result++; // Increment
                    result *= GetRandomValue(); // Multiply
                    result /= GetRandomValue(); // Divide
                }
            }

            sw.Stop();
            Console.WriteLine("Long test passed. Total elapsed: " + sw.Elapsed);
            sw.Reset();
        }

        static void FloatTest()
        {
            float result = GetRandomValue();
            sw.Start();

            for (int i = 0; i < Count; i++)
            {
                unchecked
                {
                    result += GetRandomValue(); // Add
                    result -= GetRandomValue(); // Subtract
                    result++; // Increment
                    result *= GetRandomValue(); // Multiply
                    result /= GetRandomValue(); // Divide
                }
            }

            sw.Stop();
            Console.WriteLine("Float test passed. Total elapsed: " + sw.Elapsed);
            sw.Reset();
        }

        static void DoubleTest()
        {
            double result = GetRandomValue();
            sw.Start();

            for (int i = 0; i < Count; i++)
            {
                unchecked
                {
                    result += GetRandomValue(); // Add
                    result -= GetRandomValue(); // Subtract
                    result++; // Increment
                    result *= GetRandomValue(); // Multiply
                    result /= GetRandomValue(); // Divide
                }
            }

            sw.Stop();
            Console.WriteLine("Double test passed. Total elapsed: " + sw.Elapsed);
            sw.Reset();
        }

        /// <summary>
        /// Problem: Cannot avoid overflow with unchecked -> multiplying is skipped
        /// </summary>
        static void DecimalTest()
        {
            decimal result = GetRandomValue();
            sw.Start();

            for (int i = 0; i < Count; i++)
            {
                result += GetRandomValue(); // Add
                result -= GetRandomValue(); // Subtract
                result++; // Increment
                //result *= GetRandomValue(); // Multiply
                result /= GetRandomValue(); // Divide
            }

            sw.Stop();
            Console.WriteLine("Decimal test passed. Total elapsed: " + sw.Elapsed);
            sw.Reset();
        }

        static int GetRandomValue()
        {
            return rnd.Next(1, int.MaxValue);
        }
    }
}