namespace it_ebooks_downloader
{
    using System;
    using System.IO;
    using System.Net;
    using System.Text;
    using System.Threading;
 
    public static class Program
    {
        private const string BookUrlPattern = "http://it-ebooks.info/book/{0}/";
 
        public static void Main()
        {
            string filesPath = Environment.CurrentDirectory + "\\Books";
            Directory.CreateDirectory(filesPath);
 
            for (int i = 1; i < 2000; i++)
            {
                var webClient = new WebClient();
                var html = webClient.DownloadString(string.Format(BookUrlPattern, i));
 
                if (!html.Contains("<h1 itemprop="))
                {
                    // Book not found!
                    Console.WriteLine("Book #{0} => Not found!", i);
                    continue;
                }
 
                var bookName = html.GetStringBetween("<h1 itemprop=\"name\">", "</h1>");
                var downloadLink = "http://it-ebooks.info" + html.GetStringBetween("<a id=\"dl\" href=\"", "\"");
                var year = html.GetStringBetween("<b itemprop=\"datePublished\">", "</b>").ToInteger();
 
                Directory.CreateDirectory(string.Format("{0}\\{1}", filesPath, year));
 
                var filePath = string.Format("{0}\\{1}\\{2}", filesPath, year, bookName.ToValidFileName());
                webClient.DownloadFile(downloadLink, filePath);
 
                var fileExtension = webClient.ResponseHeaders["Content-Disposition"].GetFileExtension();
 
                if (File.Exists(string.Format("{0}.{1}", filePath, fileExtension)))
                {
                    File.Delete(filePath);
                }
                else
                {
                    File.Move(filePath, string.Format("{0}.{1}", filePath, fileExtension));
                }
 
                Console.WriteLine("Book #{0} => {1}", i, bookName);
 
                // Wait 2 seconds so they won't threat the bot as flooder
                Thread.Sleep(1000);
            }
        }
    }
 
    public static class StringExtensions
    {
        public static string GetStringBetween(this string text, string startString, string endString, int startFrom = 0)
        {
            text = text.Substring(startFrom);
            startFrom = 0;
            if (!text.Contains(startString) || !text.Contains(endString))
            {
                return string.Empty;
            }
 
            var startPosition = text.IndexOf(startString, startFrom, StringComparison.Ordinal) + startString.Length;
            if (startPosition == -1)
            {
                return string.Empty;
            }
 
            var endPosition = text.IndexOf(endString, startPosition, StringComparison.Ordinal);
            if (endPosition == -1)
            {
                return string.Empty;
            }
 
            return text.Substring(startPosition, endPosition - startPosition);
        }
 
        public static int ToInteger(this string text)
        {
            int integerValue;
            int.TryParse(text, out integerValue);
            return integerValue;
        }
 
        public static string ToValidFileName(this string fileName)
        {
            var invalidCharacters = Path.GetInvalidFileNameChars();
            var fixedString = new StringBuilder(fileName);
            foreach (var ch in invalidCharacters)
            {
                fixedString.Replace(ch, '_');
            }
 
            return fixedString.ToString();
        }
 
        public static string GetFileExtension(this string text)
        {
            var parts = text.Split('.');
            return parts[parts.Length - 1];
        }
    }
}