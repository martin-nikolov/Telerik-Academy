/*
 * 12. Implement the ADT stack as auto-resizable array.
 * Resize the capacity on demand (when no space is available 
 * to add / insert a new element).
 */

using System;

class StackTest
{
    static void Main()
    {
        var stack = new Stack<int>();
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);

        Console.WriteLine("Count: " + stack.Count);

        /* -------------------------------------------------------------- */

        Console.WriteLine("\nFirst Element: " + stack.Peek());
        Console.WriteLine("Count: " + stack.Count + " - Peek");

        /* -------------------------------------------------------------- */

        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine("\nElement: " + stack.Pop());
            Console.WriteLine("Count: " + stack.Count + " - Pop");
        }

        /* -------------------------------------------------------------- */

        try
        {
            stack.Pop();
        }
        catch (Exception e)
        {
            Console.WriteLine("\n- " + e.Message);
        }

        try
        {
            stack.Peek();
        }
        catch (Exception e)
        {
            Console.WriteLine("- " + e.Message);
        }

        /* -------------------------------------------------------------- */

        for (int i = 0; i < 930; i++)
        {
            stack.Push(i);
        }

        Console.WriteLine("\nCount: " + stack.Count);
        Console.WriteLine("Capacity: " + stack.Capacity);

        /* -------------------------------------------------------------- */

        stack.TrimExcess();
        Console.WriteLine("\nTrimExcess -> Count: " + stack.Count);
        Console.WriteLine("TrimExcess -> Capacity: " + stack.Capacity);

        for (int i = 0; i < 10; i++)
        {
            stack.Pop();
        }

        stack.TrimExcess();
        Console.WriteLine("\nTrimExcess -> Count: " + stack.Count);
        Console.WriteLine("TrimExcess -> Capacity: " + stack.Capacity);

        stack.Clear();

        Console.WriteLine("\nCount: " + stack.Count);
        Console.WriteLine("Capacity: " + stack.Capacity);
    }
}