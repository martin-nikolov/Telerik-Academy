/*
* 5. Write a generic class GenericList<T> that keeps a list of elements
* of some parametric type T. Keep the elements of the list in an array
* with fixed capacity which is given as parameter in the class constructor.
* Implement methods for adding element, accessing element by index, removing
* element by index, inserting element at given position, clearing the list,
* finding element by its value and ToString(). Check all input parameters to
* avoid accessing elements at invalid positions.
*
* 6. Implement auto-grow functionality: when the internal array is full,
* create a new array of double size and move all elements to it.
*
* 7. Create generic methods Min<T>() and Max<T>() for finding the minimal
* and maximal element in the  GenericList<T>. You may need to add a generic
* constraints for the type T.
*/

using System;
using Generic;

class Program
{
    static void Main()
    {
        GenericList<int> elements = new GenericList<int>();

        // Empty list
        Console.WriteLine(elements);
        Console.WriteLine("Count: {0}", elements.Count);
        Console.WriteLine("Capacity: {0}", elements.Capacity);

        // Auto-grow functionality
        elements = new GenericList<int>(3);
        elements.Add(1);
        elements.Add(2);
        elements.Add(3);
        elements.Add(4);

        Console.WriteLine("\n" + elements);
        Console.WriteLine("Count: {0}", elements.Count);
        Console.WriteLine("Capacity: {0}", elements.Capacity);

        // Insert, RemoveAt
        elements.Clear();

        elements.Insert(0, 4);
        elements.Insert(0, 3);
        elements.Insert(0, 2);
        elements.Insert(0, 1);

        elements.RemoveAt(0);
        elements.RemoveAt(elements.Count - 1);

        Console.WriteLine("\n" + elements);
        Console.WriteLine("Count: {0}", elements.Count);
        Console.WriteLine("Capacity: {0}", elements.Capacity);
        
        // Contains, IndexOf
        Console.WriteLine("\nContain element 2: {0}", elements.Contains(2));
        Console.WriteLine("Index of element 3: {0}", elements.IndexOf(3));
       
        // Max, Min
        Console.WriteLine("\nMin: {0}", elements.Min());
        Console.WriteLine("Max: {0}", elements.Max());
    }
}