using System;

class Program
{
    static string GetBinary(short s)
    {
        string b = String.Empty;
        /* Move bits of number 's' (16 bits) right with 'i' positions
        and check if (i-bits & 1) == 0 (or 1) */
        for (int i = 0; i < 16; i++)
            b = ((s >> i) & 1) + b;
        return b;
    }

    static void Main()
    {
        Console.WriteLine(GetBinary(253));
    }
}