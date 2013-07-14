/*
* 12. Write a program that parses an URL address given in the format:
* [protocol]://[server]/[resource]
* and extracts from it the [protocol], [server] and [resource] elements.
* 
* For example from the URL http://www.devbg.org/forum/index.php the following information
* should be extracted:
* 
* [protocol] = "http"
* [server] = "www.devbg.org"
* [resource] = "/forum/index.php"
*/

using System;
using System.Linq;
using System.Text.RegularExpressions;

class ExtractUrlAddress
{
    static void Main()
    {
        string urlAddress = @"https://www.devbg.org/forum/index.php";
        
        //var fragments = Regex.Match(urlAddress, @"(?<protocol>(http(s)?|ftp(s)?)://)?(?<site>[\w\-_\.]+)?((?<resource>[\w\-\.,@^%:/~\+#]*[\w\-\@^%/~\+#]))?").Groups;
        var fragments = Regex.Match(urlAddress, "(.*)://(.*?)(/.*)").Groups;

        Console.WriteLine("URL Address: {0}", urlAddress);
        Console.WriteLine("\n[protocol] = {0}", fragments[1]);
        Console.WriteLine("[server] = {0}", fragments[2]);
        Console.WriteLine("[resource] = {0}\n", fragments[3]);
    }
}