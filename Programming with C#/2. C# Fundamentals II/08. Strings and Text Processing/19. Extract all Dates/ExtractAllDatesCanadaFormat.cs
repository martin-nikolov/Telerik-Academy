/*
* 19. Write a program that extracts from a given text all dates that
* match the format DD.MM.YYYY. Display them in the standard date format for Canada.
* 
* Sample text:
* I was born at 14.06.1980. My sister was born at 3.7.1984. In
* 5/1999 I graduated my high school. The law says (see section
* 7.3.12) that we are allowed to do this (section 7.4.2.9).
* 
* Extracted dates from the sample text:
* 14.06.1980
* 3.7.1984
* 
*/

using System;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

class ExtractAllDatesCanadaFormat
{
    static void Main()
    {
        string text = @"I was born at 14.06.1980. My sister was born at 3.7.1984. In 5/1999 I graduated my high school. The law says (see section 7.3.12) that we are allowed to do this (section 7.4.2.9).";

        DateTime date;

        Console.WriteLine("Extracted dates from the sample text: ");

        foreach (Match item in Regex.Matches(text, @"\b[0-9]{1,2}.[0-9]{1,2}.[0-9]{2,4}"))
            if (DateTime.TryParseExact(item.Value, "d.M.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                Console.WriteLine("- " + date.ToString(CultureInfo.GetCultureInfo("en-CA").DateTimeFormat.ShortDatePattern));

        Console.WriteLine();
    }
}