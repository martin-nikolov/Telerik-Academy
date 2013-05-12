/*
* 8. Declare two string variables and assign them with following value:
* "The "use" of quotations causes difficulties."
* Do the above in two different ways: with and without using quoted strings.
*/

using System;

class EscapingTest
{
    static void Main(string[] args)
    {
        string unquotedString = "The \"use\" of quotations causes difficulties.";
        string quotedString = @"The ""use"" of quotations causes difficulties.";

        Console.WriteLine(unquotedString);
        Console.WriteLine(quotedString);
    }
}