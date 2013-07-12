/*
* 10. Write a program that extracts from given XML file all the text without the tags. 
* 
*     _________________________________________          
*     |               Example:                |            
*     |                                       |         
*     | <?xml version="1.0"?>                 |           ____________
*     | <student>                             |           |  Output: |  
*     |     <name>Pesho</name>                |           |          |
*     |     <age>21</age>                     |           | Pesho    |
*     |     <interests count="3">             |  ------>  | 21       |
*     |         <interest>Games</interest>    |           | Games    |
*     |         <interest>C#</interest>       |           | C#       |
*     |         <interest>Java</interest>     |           | Java     |
*     |     </interests>                      |           |__________|
*     | </student>                            |          
*     |_______________________________________|          
* 
*/

using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

class TagRemover
{
    static StringBuilder textWithoutTags = new StringBuilder();

    static void Main()
    {
        string pathXML = "../../text.xml";

        ExtractTextWithoutTags(pathXML);

        Console.WriteLine(textWithoutTags);
    }

    static void ExtractTextWithoutTags(string pathTextFile)
    {
        using (StreamReader reader = new StreamReader(pathTextFile))
        {
            while (!reader.EndOfStream)
            {
                string line = Regex.Replace(reader.ReadLine(), @"<[^>]*>", String.Empty).Trim();
                if (line != "") textWithoutTags.AppendLine(line);
            }
        }
    }
}