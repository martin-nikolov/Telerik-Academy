/*
* 5. Define a class BitArray64 to hold 64 bit values inside an ulong value.
* 
* Implement IEnumerable<int> and Equals(…), GetHashCode(), [], == and !=.
*/

using System;
using System.Linq;

class Program
{
    static void Main()
    {
        var number1 = new BitArray64();
        number1[4] = 1;
        number1[10] = 1;

        Console.WriteLine(number1);

        var number2 = new BitArray64(1040);

        Console.WriteLine(number2);

        /* -------------- */

        Console.WriteLine(new string('-', 40));
        Console.WriteLine("number1.Equals(number2): {0}", number1.Equals(number2));
        Console.WriteLine("number1 == number2: {0}", number1 == number2);
        Console.WriteLine("number1 != number2: {0}\n", number1 != number2);

        Console.WriteLine("number1.GetHashCode(): {0}", number1.GetHashCode());
        Console.WriteLine("new BitArray64(4198).GetHashCode(): {0}", new BitArray64(4198).GetHashCode());
        Console.WriteLine(new string('-', 40) + "\n");
      
        /* -------------- */

        Console.WriteLine("Testing GetEnumerator: ");
        foreach (var bit in number1)
            Console.Write(bit);

        Console.WriteLine();

        for (int i = 63; i >= 0; i--)
            Console.Write(number1[i]);

        Console.WriteLine();
    }
}