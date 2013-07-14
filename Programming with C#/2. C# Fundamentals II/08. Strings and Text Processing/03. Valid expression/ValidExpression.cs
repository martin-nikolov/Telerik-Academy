/*
* 3. Write a program to check if in a given expression the brackets are put correctly.
* Example of correct expression: ((a+b)/5-d).
* Example of incorrect expression: )(a+b)).
*/

using System;
using System.Linq;

class ValidExpression
{
    static void Main()
    {
        Console.Write("Enter an expression: ");
        string exp = Console.ReadLine();

        Console.WriteLine("\nThe expression is {0}!\n", IsValidExpression(exp) ? "correct" : "incorrect");
    }
  
    static bool IsValidExpression(string exp)
    {
        if (exp.Contains("()")) return false;

        int brackets = 0;

        for (int i = 0; i < exp.Length; i++)
        {
            if (exp[i] == '(') brackets++;
            else if (exp[i] == ')') brackets--;

            if (brackets < 0) return false;
        }

        if (brackets != 0) return false;

        return true;
    }
}