namespace EasyPTC.Console
{
    using System;
    using System.Linq;
    using EasyPTC.Data;

    public class EasyPtcConsoleClient
    {
        private static EasyPtcData easyPtcData = new EasyPtcData(new EasyPtcDbContext());

        internal static void Main()
        {
            Console.WriteLine(easyPtcData.Advertisements.All().Count());
        }
    }
}