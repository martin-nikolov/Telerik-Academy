/*
* 4. Write a program that downloads a file from Internet (e.g. http://www.devbg.org/img/Logo-BASD.jpg)
* and stores it the current directory. Find in Google how to download files in C#.
* Be sure to catch all exceptions and to free any used resources in the finally block.
*/

using System;
using System.Linq;
using System.Net;

class DownloadFromInternet
{
    static void Main()
    {
        Console.WriteLine("Do you allow access to the program to download a picture from the Web?\n");

        string userChoice = string.Empty;

        do
        {
            Console.Write("Enter your choice - [Y] or [N]: ");
            userChoice = Console.ReadLine();
        }
        while (userChoice.ToLower() != "n" && userChoice.ToLower() != "y");

        if (userChoice.ToLower() == "n") Environment.Exit(0);

        using (WebClient webClient = new WebClient())
        {
            try
            {
                Console.WriteLine("\nStart downloading...");

                webClient.DownloadFile("http://www.devbg.org/img/Logo-BASD.jpg", "../../Logo-BASD.jpg");

                Console.WriteLine("\n-> The download was sucessful!");
            }
            catch (ArgumentException)
            {
                Console.Error.WriteLine("\n-> Error: You have entered an empty Web Address!");
            }
            catch (WebException)
            {
                Console.Error.WriteLine("\n-> Error: You have entered an invalid Web Address!");
            }
            catch (NotSupportedException)
            {
                Console.Error.WriteLine("\n-> Error: This method does not support simultaneous downloads!");
            }
            finally
            {
                Console.WriteLine("\nGoodbye!\n");
            }
        }
    }
}