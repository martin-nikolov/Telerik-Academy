/*
* 25. Write a program that extracts from given HTML file its title
* (if available), and its body text without the HTML tags. 
*
*  ________________________Example:___________________________
*  | <html>                                                  |
*  |  <head><title>News</title></head>                       |
*  |  <body><p><a href="http://academy.telerik.com">Telerik  |
*  |    Academy</a>aims to provide free real-world practical |
*  |    training for young people who want to turn into      |
*  |    skillful .NET software engineers.</p></body>         |
*  | </html>                                                 |
*  |_________________________________________________________|
*/

using System;
using System.Linq;
using System.Text.RegularExpressions;

class ExtractTitleAndBodyFromHtmlDoc
{
    static void Main()
    {
        string htmlDoc = @"<html><head><title>News</title></head><body><p><a href=""http://academy.telerik.com"">Telerik Academy</a>aims to provide free real-world practical training for young people who want to turn into skillful .NET software engineers.</p></body></html>";

        foreach (Match item in Regex.Matches(htmlDoc, "(?<=^|>)[^><]+?(?=<|$)")) Console.WriteLine(item);

        Console.WriteLine();
    }
}