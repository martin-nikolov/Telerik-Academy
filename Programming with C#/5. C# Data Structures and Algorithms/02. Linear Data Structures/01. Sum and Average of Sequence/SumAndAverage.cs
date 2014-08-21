/*
 * 1. Write a program that reads from the console a sequence 
 * of positive integer numbers. The sequence ends when empty 
 * line is entered. Calculate and print the sum and average 
 * of the elements of the sequence. Keep the sequence in List<int>.
 */

namespace LinearDataStructures
{
    using System;
    using System.Linq;
    using Utility;

    public class SumAndAverage
    {
        public static void Main()
        {
            #if DEBUG
            Console.SetIn(new System.IO.StreamReader("../../input.txt"));
            #endif

            var numbers = ConsoleUtility.ReadSequenceOfElements<int>();
            var sumOfNumbers = numbers.Where(a => a > 0).Sum();
            var averageOfNumbers = numbers.Where(a => a > 0).Average();

            PrintResult(sumOfNumbers, averageOfNumbers);
        }
         
        public static void PrintResult(int sumOfNumbers, double averageOfNumbers)
        {
            Console.WriteLine("Sum: " + sumOfNumbers);
            Console.WriteLine("Average: " + averageOfNumbers);
        }
    }
}