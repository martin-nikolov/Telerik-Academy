/*
* 4. Write a program that finds how many times a substring is contained in a 
* given text (perform case insensitive search).
* 
* Example: The target substring is "in". The text is as follows:
*  _______________________________________________________________________
*  | We are living in an yellow submarine. We don't have anything else.  |
*  | Inside the submarine is very tight. So we are drinking all the day. |
*  | We will move out of it in 5 days.                                   |
*  |_____________________________________________________________________|
* 
* The result is: 9.

*/

using System;
using System.Linq;
using System.Text.RegularExpressions;

class OccursOfWord
{
    static void Main()
    {
        string text = @"We are living in an yellow submarine. We don't have anything else.
        Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";
        string pattern = "in";

        Console.WriteLine("Result: {0} time(s)\n", Regex.Matches(text, pattern, RegexOptions.IgnoreCase).Count);

        //int index = text.IndexOf("in", StringComparison.OrdinalIgnoreCase);
        //int occurs = 0;
        //
        //while (index != -1)
        //{
        //    occurs++;
        //    index = text.IndexOf("in", index + 1, StringComparison.OrdinalIgnoreCase);
        //}
    }
}