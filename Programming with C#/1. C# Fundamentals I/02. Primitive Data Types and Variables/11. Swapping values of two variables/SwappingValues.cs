/*
* 11. Declare  two integer variables and assign them with
* 5 and 10 and after that exchange their values.
*/

using System;

class SwappingValues
{
    static void Main(string[] args)
    {
        int x = 5;
        int y = 15;

        // first way with helping variable 
        Console.WriteLine("Before swap x = {0} | y = {1}", x, y);
        int swap = x;
        x = y;
        y = swap;
        Console.WriteLine("After swap x = {0} | y = {1}\n", x, y);

        // second way with bitwise representation 
        Console.WriteLine("Before swap x = {0} | y = {1}", x, y);
        x = x ^ y;
        y = y ^ x;
        x = x ^ y;
        Console.WriteLine("After swap x = {0} | y = {1}\n", x, y);

        // third way using sum and difference of the variables 
        // ***does not work if the sum (first line) of the variables exceeds the maximum allowable amount for their respective type
        Console.WriteLine("Before swap x = {0} | y = {1}", x, y);
        x = x + y;
        y = x - y;
        x = x - y;
        Console.WriteLine("After swap x = {0} | y = {1}\n", x, y);
    }
}