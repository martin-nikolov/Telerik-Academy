/*
* 7. Declare two string variables and assign them with “Hello” and “World”.
* Declare an object variable and assign it with the concatenation of
* the first two variables (mind adding an interval). 
* Declare a third string variable and initialize it with the
* value of the object variable (you should perform type casting).
*/

using System;

class TypeCastingTest
{
    static void Main(string[] args)
    {
        string first = "Hello";
        string second = "World!";

        object concat = first + " " + second; // or string.Concat(first, " ", second)
        string result = concat.ToString(); // or (string)concat

        Console.WriteLine(result);
    }
}