/*
 * 4. Implement the data structure "hash table" in a class 
 * HashTable<K,T>. Keep the data in array of lists of key-value
 * pairs (LinkedList<KeyValuePair<K,T>>[]) with initial 
 * capacity of 16. When the hash table load runs over 75%,
 * perform resizing to 2 times larger capacity. Implement
 * the following methods and properties: Add(key, value), 
 * Find(key) -> value, Remove( key), Count, Clear(), this[], 
 * Keys. Try to make the hash table to support iterating over
 * its elements with foreach.
 */

using System;

class HashTableTest
{
    static void Main()
    {
        var hashTable = new HashTable<int, int>();

        /* ----------------------------------------------------- */

        // Test Add method
        hashTable.Add(1, 2);
        hashTable[2] = 3;

        Console.Write("Adds 2 elements to hash table => ");
        Console.WriteLine("Count: " + hashTable.Count + Environment.NewLine); // Count: 2

        /* ----------------------------------------------------- */

        // Test GetValue method
        Console.WriteLine("hashTable[1] = " + hashTable[1]); // Value: 2
        Console.WriteLine("hashTable.GetValue(1) = " + hashTable.GetValue(1)); // Value: 2

        Console.WriteLine("\nhashTable[2] = " + hashTable[2]); // Value: 3
        Console.WriteLine("hashTable.GetValue(2) = " + hashTable.GetValue(2)); // Value: 3

        try
        {
            hashTable.GetValue(3); // The given key was not present in the hash table.
        }
        catch (Exception e)
        {
            Console.WriteLine("\nhashTable[3] -> " + e.Message + Environment.NewLine);
        }

        /* ----------------------------------------------------- */

        // Test Remove method
        Console.WriteLine("hashTable.Remove(2) = " + hashTable.Remove(2)); // True
        Console.WriteLine("hashTable.Remove(-1) = " + hashTable.Remove(-1)); // False

        Console.WriteLine("Count: " + hashTable.Count + Environment.NewLine); // Count: 1

        /* ----------------------------------------------------- */

        hashTable.Add(1, 3); // Replace 2 with 3
        hashTable.Add(1, 4); // Replace 3 with 4

        Console.WriteLine("hashTable[1] = " + hashTable[1]);

        Console.WriteLine("Count: " + hashTable.Count + Environment.NewLine); // Count: 1

        /* ----------------------------------------------------- */

        // Test Expand method -> sets new table length from 16 to 32
        for (int i = 1; i <= 12; i++)
        {
            hashTable.Add(i, 12 - i + 1);
        }

        Console.Write("Adds 12 elements to hash table => ");
        Console.WriteLine("Count: " + hashTable.Count + Environment.NewLine); // Count: 12

        /* ----------------------------------------------------- */

        // Test foreach
        foreach (var item in hashTable)
        {
            Console.WriteLine(item);
        }
    }
}