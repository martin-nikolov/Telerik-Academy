/*
* 18. Write a program for extracting all email addresses from given text.
* All substrings that match the format <identifier>@<host>…<domain> 
* should be recognized as emails.
* 
* Example:
* Please contact us by phone (+001 222 222 222) or by email at
* example@gmail.com or at test.user@yahoo.co.uk. This is not
* email: test@test. This also: @gmail.com. Neither this: a@a.b.
* 
* Extracted e-mail addresses from the sample text:
* example@gmail.com
* test.user@yahoo.co.uk
*/

using System;
using System.Linq;
using System.Text.RegularExpressions;

class ExtractAllValidEmails
{
    static void Main()
    {
        string text = @"Please contact us by phone (+001 222 222 222) or by email at example@gmail.com or at test.user@yahoo.co.uk. This is not email: test@test. This also: @gmail.com. Neither this: a@a.b. End!";

        string[] emails = text.Split(new string[] { " ", ";", ",", ". " }, StringSplitOptions.RemoveEmptyEntries);
        string[] validEmails = Array.FindAll<string>(emails, IsValidEmail);

        PrintEmails(validEmails);
    }

    static bool IsValidEmail(string email)
    {
        string pattern =
                        @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                        @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                        @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";

        return new Regex(pattern).IsMatch(email);
    }

    static void PrintEmails(string[] validEmails)
    {
        Console.WriteLine("Extracted e-mail addresses from the sample text: ");

        foreach (string email in validEmails)
            Console.WriteLine("- " + email);

        Console.WriteLine();
    }
}