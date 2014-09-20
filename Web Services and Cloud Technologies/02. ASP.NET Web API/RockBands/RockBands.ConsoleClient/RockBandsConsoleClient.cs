namespace RockBands.ConsoleClient
{
    using System;
    using System.Linq;
    using System.Net.Http;
    using RockBands.Data;
    using RockBands.Data.Contracts;

    public class RockBandsConsoleClient
    {
        private static readonly IRockBandsData rockBandsData = new RockBandsData();

        internal static void Main()
        {
            ///
            /// RockBands.Services project must be started.
            ///

            Console.WriteLine("Loading...");

            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:3333/api/");
            PrintBands(httpClient);
            PrintAlbums(httpClient);
            PrintSongs(httpClient);

            Console.ReadLine();
        }

        private static async void PrintBands(HttpClient httpClient)
        {
            var response = await httpClient.GetAsync("Bands/GetCovers?count=3");
            Console.WriteLine("\nBands: " + await response.Content.ReadAsStringAsync());
        }

        private static async void PrintAlbums(HttpClient httpClient)
        {
            var response = await httpClient.GetAsync("Albums/GetCovers?count=3");
            Console.WriteLine("\nAlbums: " + await response.Content.ReadAsStringAsync());
        }

        private static async void PrintSongs(HttpClient httpClient)
        {
            var response = await httpClient.GetAsync("Songs/GetCovers?count=3");
            Console.WriteLine("\nSongs: " + await response.Content.ReadAsStringAsync());
        }
    }
}