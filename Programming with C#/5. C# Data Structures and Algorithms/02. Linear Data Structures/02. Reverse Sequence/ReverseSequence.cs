/*
 * 2. Write a program that reads N integers from the console
 * and reverses them using a stack. Use the Stack<int> class.
 */

using System;
using System.Collections.Generic;
using System.Linq;

class ReverseSequence
{
    static void Main()
    {
        // Input elements
        var numbers = new List<int>() { 1, 2, 3, 4, 5 };

        Stack<int> elements = new Stack<int>(numbers);

        // Prints elements backwards
        while (elements.Count > 0)
        {
            Console.WriteLine(elements.Pop());
        }
    }
}