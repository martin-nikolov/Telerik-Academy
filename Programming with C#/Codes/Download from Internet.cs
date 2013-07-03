using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

class DownloadInternet
{
        static void Main()
        {
            //Menu Soon Will Have More Options You Can Call It Menu v1.0 Beta Version :)
            Console.WriteLine("Choose Action.");
            Console.WriteLine("\n 1.Type Positive Number For Download. \n 2.Type Negative Number To Exit.");
            int a = int.Parse(Console.ReadLine());
            if (a < 0)
            {
                Console.WriteLine("Exit Program !");
                Environment.Exit(0);
            }
            Console.WriteLine("Download Is Sucessfull !");
            using (WebClient webClient = new WebClient())
            {
                try
                {
                    // Download Link And Name For The Local Storage 
                    webClient.DownloadFile("http://www.devbg.org/img/Logo-BASD.jpg", "../../BASDlogo.jpg"); 
                }

                catch (WebException)
                {
                    Console.Error.WriteLine("Typed Adress Is Not Valid!");
                }

                catch (NotSupportedException)
                {
                    Console.Error.WriteLine("The Method Have Out Of Range Calls!");
                }
            }
        }
}