/*
 * 11. Implement the data structure linked list. Define a class
 * ListItem<T> that has two fields: value (of type T) and NextItem
 * (of type ListItem<T>). Define additionally a class LinkedList<T>
 * with a single field FirstElement (of type ListItem<T>).
 */

using System;

class LinkedListTest
{
    static void Main()
    {
        var linkedList = new DynamicList.LinkedList<int>();

        /* ------------------------------------------------------------------------ */

        // Test AddFirst Method
        linkedList.AddFirst(3); // 3
        linkedList.AddFirst(2); // 1 2
        linkedList.AddFirst(1); // 1 2 3

        // Test AddLastMethod
        linkedList.AddLast(4); // 1 2 3 4
        linkedList.AddLast(7); // 1 2 3 4 7

        Console.WriteLine("First: " + linkedList.First); // 1
        Console.WriteLine("Last: " + linkedList.Last); // 7
        Console.WriteLine("Count: " + linkedList.Count); // 5

        Console.WriteLine("\nElements: " + string.Join(" ", linkedList) + Environment.NewLine);

        /* ------------------------------------------------------------------------ */

        // Test Find Method
        var firstNode = linkedList.FindFirst(1); // Exists
        var lastNode = linkedList.FindFirst(7); // Exists
        var nullNode = linkedList.FindFirst(0); // Null

        Console.WriteLine("firstNode == linkedList.First: {0}", firstNode == linkedList.First); // True
        Console.WriteLine("lastNode == linkedList.Last: {0}", lastNode == linkedList.Last); // True
        Console.WriteLine("nullNode == null: {0}", nullNode == null); // True

        /* ------------------------------------------------------------------------ */

        // Test AddBefore Method
        linkedList.AddBefore(linkedList.First, 0); // 0 1 2 3 4 7
        linkedList.AddBefore(linkedList.Last, 6); // 0 1 2 3 4 6 7
        linkedList.AddBefore(linkedList.FindFirst(6), 5); // 0 1 2 3 4 5 6 7

        Console.WriteLine("\nElements: " + string.Join(" ", linkedList) + Environment.NewLine);

        /* ------------------------------------------------------------------------ */

        // Test AddAfter Method
        linkedList.AddAfter(linkedList.First, -111); // 0 -111 1 2 3 4 5 6 7
        linkedList.AddAfter(linkedList.Last, 8); // 0 -111 1 2 3 4 5 6 7 8
        linkedList.AddAfter(linkedList.FindFirst(6), -777); // 0 -111 1 2 3 4 5 6 -777 7 8

        Console.WriteLine("Elements: " + string.Join(" ", linkedList) + Environment.NewLine);

        /* ------------------------------------------------------------------------ */

        // Test RemoveFirst Method
        linkedList.AddFirst(-111); // -111 0 -111 1 2 3 4 5 6 -777 7 8
        linkedList.AddLast(-777); // -111 0 -111 1 2 3 4 5 6 -777 7 8 -777

        Console.WriteLine("Elements: " + string.Join(" ", linkedList) + Environment.NewLine);

        linkedList.RemoveFirst(-111); // 0 -111 1 2 3 4 5 6 -777 7 8 -777
        linkedList.RemoveLast(-111); // 0 1 2 3 4 5 6 -777 7 8 -777

        linkedList.RemoveLast(-777); // 0 1 2 3 4 5 6 -777 7 8
        linkedList.RemoveFirst(-777); // 0 1 2 3 4 5 6 7 8

        Console.WriteLine("Elements: " + string.Join(" ", linkedList) + Environment.NewLine);

        /* ------------------------------------------------------------------------ */

        // Test GetEnumerator => foreach
        Console.Write("Foreach: ");

        foreach (var node in linkedList) // 0 -111 1 2 3 4 5 6 -777 7 8
            Console.Write(node + " ");

        /* ------------------------------------------------------------------------ */

        // Test Clear Method
        linkedList.Clear();

        Console.WriteLine("\n\nCount: " + linkedList.Count); // 0
        Console.WriteLine("Elements: " + string.Join(" ", linkedList) + Environment.NewLine);
    }
}