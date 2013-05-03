using System;
using System.Text.RegularExpressions;

namespace ValidEmails
{
    class Program
    {
        public static void Main()
        {
            string addressList = @"Please contact us by phone (+359 222 222 222) or by email at example@abv.bg or 
            at baj.ivan@yahoo.co.uk. This is not email: test@test. This also: @telerik.com. Neither this: a@a.b. End!";

            // Extract emails, skipping blank entries
            string[] emails = addressList.Split(new string[] { " ", ";", ",", ". " }, StringSplitOptions.RemoveEmptyEntries);

            // Print the valid emails.
            string[] validEmails = Array.FindAll<string>(emails, IsValidEmail);
            foreach (string validEmail in validEmails)
            {
                Console.WriteLine("Valid Email = " + validEmail);
            }
        }

        public static bool IsValidEmail(string email)
        {
            string pattern =
                @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex re = new Regex(pattern);

            return re.IsMatch(email);
        }
    }
}