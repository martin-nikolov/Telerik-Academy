/*
* 13. * Write a program that calculates for given N how many trailing
* zeros present at the end of the number N!. 
* 
* Examples:
* N = 10 -> N! = 3628800 -> 2
* N = 20 -> N! = 2432902008176640000 -> 4
* 
* Does your program work for N = 50 000?
* 
* Hint: The trailing zeros in N! are equal to the
* number of its prime divisors of value 5. Think why!
*/

using System;
using System.Linq;

class ZerosOfFactorialN
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        uint n = uint.Parse(Console.ReadLine());
        byte zerosN = 0;

        Console.Write("\nN = {0} -> {0}! -> ", n);

        for (int i = 5; i <= n; i *= 5)
        {
            zerosN += (byte)(n / i);
        }

        Console.WriteLine("{0} zeros\n", zerosN);
    }
}