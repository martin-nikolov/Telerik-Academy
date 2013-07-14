/*
* 5. You are given a text. Write a program that changes the text in all regions
* surrounded by the tags <upcase> and </upcase> to uppercase. The tags cannot be nested. 
* 
* Example: 
* We are living in a <upcase>yellow submarine</upcase>. We don't have <upcase>anything</upcase> else.
* 
* The expected result:
* We are living in a YELLOW SUBMARINE. We don't have ANYTHING else.
*/

using System;
using System.Linq;
using System.Text.RegularExpressions;

class TagMakesWordsLarge
{
    static void Main()
    {
        string text = @"We are living in a <upcase>yellow submarine</upcase>. We don't have <upcase>anything</upcase> else.";

        Console.WriteLine(Regex.Replace(text, "<upcase>(.*?)</upcase>", word => word.Groups[1].Value.ToUpper()));
    }
}