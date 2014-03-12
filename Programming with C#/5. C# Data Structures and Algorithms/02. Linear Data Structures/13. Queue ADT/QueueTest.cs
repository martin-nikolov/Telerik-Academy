/*
 * 13. Implement the ADT queue as dynamic linked list. 
 * Use generics (LinkedQueue<T>) to allow storing different
 * data types in the queue.
 */

using System;

class QueueTest
{
    static void Main()
    {
        var queue = new Queue<int>();
        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);

        Console.WriteLine("Count: " + queue.Count);

        /* -------------------------------------------------------------- */

        Console.WriteLine("\nFirst Element: " + queue.Peek());
        Console.WriteLine("Count: " + queue.Count + " - Peek");

        /* -------------------------------------------------------------- */

        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine("\nElement: " + queue.Dequeue());
            Console.WriteLine("Count: " + queue.Count + " - Dequeue");
        }

        /* -------------------------------------------------------------- */

        try
        {
            queue.Dequeue();
        }
        catch (Exception e)
        {
            Console.WriteLine("\n- " + e.Message);
        }

        try
        {
            queue.Peek();
        }
        catch (Exception e)
        {
            Console.WriteLine("- " + e.Message);
        }

        /* -------------------------------------------------------------- */

        for (int i = 0; i < 1024; i++)
        {
            queue.Enqueue(i);
        }

        Console.WriteLine("\nCount: " + queue.Count);

        queue.Clear();

        Console.WriteLine("Count: " + queue.Count);
    }
}