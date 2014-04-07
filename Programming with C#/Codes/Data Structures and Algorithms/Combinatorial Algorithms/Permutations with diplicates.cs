/*
 * Generate all permutations with repetitions of given multi-set. 
 * 
 * For example the multi-set {1, 3, 5, 5} has the following 12 unique permutations:
 * 
 *  { 1, 3, 5, 5 }  { 1, 5, 3, 5 }
 *  { 1, 5, 5, 3 }  { 3, 1, 5, 5 }
 *  { 3, 5, 1, 5 }  { 3, 5, 5, 1 }
 *  { 5, 1, 3, 5 }  { 5, 1, 5, 3 }
 *  { 5, 3, 1, 5 }  { 5, 3, 5, 1 }
 *  { 5, 5, 1, 3 }  { 5, 5, 3, 1 }
 *  
 * Ensure your program efficiently avoids duplicated permutations. 
 * Test it with { 1, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 }.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class PermutationsWithDuplicates
{
    //*
    static readonly SortedSet<string> uniquePermutations = new SortedSet<string>();
    /*/
    static readonly HashSet<string> uniquePermutations = new HashSet<string>(); // faster
    //*/

    //*
    static readonly int[] elements = { 1, 3, 5, 5 };
    /*/
    static readonly int[] elements = { 1, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 };
    //*/

    static void Main()
    {
        Permutations(elements.Length);

        PrintUniquePermutations();
    }

    static void Permutations(int index)
    {
        if (index == 0)
        {
            uniquePermutations.Add(GetPermutation());
            return;
        }

        Permutations(index - 1);

        for (int i = 0; i < index - 1; i++)
        {
            if (elements[i] != elements[index - 1])
            {
                Swap(ref elements[i], ref elements[index - 1]);
                Permutations(index - 1);
                Swap(ref elements[i], ref elements[index - 1]);
            }
        }
    }

    static void Swap<T>(ref T a, ref T b)
    {
        T swap = a;
        a = b;
        b = swap;
    }

    static string GetPermutation(string separator = " ")
    {
        var result = new StringBuilder();

        for (int i = 0; i < elements.Length; i++)
            result.AppendFormat("{0}{1}", elements[i], separator);

        result.Length -= separator.Length;

        return result.ToString();
    }

    static void PrintUniquePermutations()
    {
        foreach (var permutation in uniquePermutations)
            Console.WriteLine(permutation);

        Console.WriteLine("\nTotal unique permutations: {0}\n", uniquePermutations.Count);
    }
}