using System;
class Sheets
{
    /// <summary>
    /// The solution is based on Greedy programming technique
    /// http://en.wikipedia.org/wiki/Greedy_algorithm
    /// </summary>
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        for (int i = 10; i >= 0; i--)
        {
            if ((N & 1) == 0) // Check if last bit is zero
            {
                Console.WriteLine("A{0}", i);
            }
            N >>= 1;
        }

        // Another solution without using bitwise operators
        // The answer will be sorted from the biggest paper size to the smallest
        //for (int i = 10; i >= 0; i--)
        //{
        //    int sheets = (int)Math.Pow(2, i);
        //    if (N >= sheets) // Use the sheet with that size
        //    {
        //        N -= sheets;
        //    }
        //    else
        //    {
        //        Console.WriteLine("A{0}", 10 - i);
        //    }
        //}
    }
}
