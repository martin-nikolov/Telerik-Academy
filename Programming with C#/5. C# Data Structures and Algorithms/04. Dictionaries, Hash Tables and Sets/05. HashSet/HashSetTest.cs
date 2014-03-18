/*
 * 5. Implement the data structure "set" in a class HashedSet<T>
 * using your class HashTable<K,T> to hold the elements. 
 * Implement all standard set operations like Add(T), Find(T),
 * Remove(T), Count, Clear(), union and intersect.
 */

using System;
using System.Collections.Generic;

class HashSetTest
{
    static void Main()
    {
        var hashSet = new HashSet<int>();

        /* -------------------------------------------------------- */

        // Test Add Method
        Console.WriteLine(hashSet.Add(1));
        Console.WriteLine(hashSet.Add(2));
        Console.WriteLine(hashSet.Add(2)); // 1 2

        Console.WriteLine("Elements: " + string.Join(" ", hashSet) + Environment.NewLine);

        /* -------------------------------------------------------- */

        // Test Union Method
        int[] unionArray = { 2, 3, 4, 5 };
        hashSet.UnionWith(unionArray); // 1 2 3 4 5

        Console.WriteLine("Union: " + string.Join(" ", hashSet) + Environment.NewLine);

        /* -------------------------------------------------------- */

        // Test Intersect Method
        int[] intersectArray = { 2, 3 };
        hashSet.IntersectWith(intersectArray); // 2 3

        Console.WriteLine("Intersect: " + string.Join(" ", hashSet) + Environment.NewLine);

        /* -------------------------------------------------------- */

        // Test Count and Contains Method
        Console.WriteLine("Count: " + hashSet.Count);
        Console.WriteLine("Contains 3: " + hashSet.Contains(3));
        Console.WriteLine("Contains 4: " + hashSet.Contains(4) + Environment.NewLine);

        /* -------------------------------------------------------- */

        // Test Remove Method
        Console.WriteLine("Removed 3: " + hashSet.Remove(3));
        Console.WriteLine("Removed 4: " + hashSet.Remove(4) + Environment.NewLine);

        /* -------------------------------------------------------- */

        hashSet.Add(3);
        hashSet.Add(4);
        hashSet.Add(5);

        // Test GetEnumerator Method => foreach
        Console.Write("Foreach: ");

        foreach (var item in hashSet)
        {
            Console.Write(item + " ");
        }

        Console.WriteLine(Environment.NewLine);

        /* -------------------------------------------------------- */

        // Test Keys Property
        var enumerableKeys = hashSet.Keys;
        var listKeys = new List<int>(hashSet.Keys);

        Console.WriteLine("Keys: " + string.Join(" ", enumerableKeys));
        Console.WriteLine("Keys: " + string.Join(" ", listKeys) + Environment.NewLine);

        /* -------------------------------------------------------- */

        // Test Clear Method
        hashSet.Clear();
        Console.WriteLine("Count: " + hashSet.Count);
    }
}