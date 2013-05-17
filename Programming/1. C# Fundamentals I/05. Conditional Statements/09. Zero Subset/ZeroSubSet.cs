/*
* 9. We are given 5 integer numbers. Write a program that checks
* if the sum of some subset of them is 0.
* Example: 3, -2, 1, 1, 8 -> 1+1-2=0.
*/

using System;
using System.Collections.Generic;
using System.Linq;

class ZeroSubSet
{
    static void Main()
    {
        int[] number = { 3, -2, 1, 1, 8 };
        long subsets = (long)(Math.Pow(2, number.Length) - 1);

        for (int i = 1; i <= subsets; i++)
        {
            List<int> currentSum = new List<int>();

            for (int j = 0; j < number.Length; j++)
            {
                if ((i >> j & 1) == 1)
                {
                    currentSum.Add(number[j]);
                }
            }

            if (currentSum.Sum() == 0)
            {
                Console.Write("Zero Sum: ");

                for (int j = 0; j < currentSum.Count; j++)
                {
                    Console.Write(
                                  j > 0 ? (currentSum[j] > 0 ? " + " + currentSum[j] + "" : " - " + Math.Abs(currentSum[j]) + "")
                                  : currentSum[j].ToString());
                }

                Console.WriteLine(" = 0\n");
                break;
            }
        }
    }
}