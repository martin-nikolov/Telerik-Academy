/*
* 3. Write a program that safely compares floating-point numbers with precision
* of 0.000001. 
* 
* Examples:
* (5.3 ; 6.01) -> false;
* (5.00000001 ; 5.00000003) -> true
*/

using System;

class FloatComparisons
{
    static void Main(string[] args)
    {
        Console.WriteLine("Comparison test: ");

        float firstNumber = 5.3f;
        float secondNumber = 6.01f;

        Console.WriteLine("{0} is equal to {1} -> {2}", firstNumber, secondNumber, firstNumber == secondNumber);

        firstNumber = 5.00000001f;
        secondNumber = 5.00000003f;

        Console.WriteLine("{0} is equal to {1} -> {2}", firstNumber, secondNumber, firstNumber.Equals(secondNumber));

        Console.WriteLine("\nOther tests: ");

        float f = 0.1F;
        Console.WriteLine("{0}f is equal to {1} -> {2}", f, 0.1, f == 0.1); // returns false
        Console.WriteLine("{0}f is equal to {1}f -> {2}", f, 0.1, f == 0.1F); // return true

        double d1 = 1.000001; 
        double d2 = 0.000001;
        Console.WriteLine("({0} - {1}) == 1.0 -> {2}", d1, d2, (d1 - d2) == 1.0); // this is exactly 1.0, but return false

        double n1 = 0.55;
        double n2 = 100;
        double ans = n1 * n2; //ans should be 55.0, but it is 55.000000000000007

        if (ans == 55.0)
        {
            // This will not display the 'ans'
            Console.WriteLine(ans);
        }

        Console.WriteLine();
    }
}