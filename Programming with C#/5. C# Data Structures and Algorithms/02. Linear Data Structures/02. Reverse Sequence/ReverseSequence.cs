/*
 * 2. Write a program that reads N integers from the console
 * and reverses them using a stack. Use the Stack<int> class.
 */

namespace LinearDataStructures
{
    using System;
    using System.Linq;
    using Utility;

    public class ReverseSequence
    {
        public static void Main()
        {
            #if DEBUG
            Console.SetIn(new System.IO.StreamReader("../../input.txt"));
            #endif

            var numbers = ConsoleUtility.ReadSequenceOfElements<int>();
            var elementsBackwards = new AbstractDataStructures.Stack<int>(numbers); // My implementation of Stack

            PrintElementsBackwards(elementsBackwards);
        }

        public static void PrintElementsBackwards(AbstractDataStructures.Stack<int> elements)
        {
            while (elements.Count > 0)
            {
                Console.WriteLine(elements.Pop());
            }
        }
    }
}