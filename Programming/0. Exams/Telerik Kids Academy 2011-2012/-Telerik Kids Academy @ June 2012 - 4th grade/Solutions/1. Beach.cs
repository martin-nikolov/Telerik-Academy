using System;

class Beach
{
    static void Main()
    {
        string lineReader = Console.ReadLine();
        string[] tokens = lineReader.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        int arrivedLony = int.Parse(tokens[0] + new string('0', 2 - tokens[1].Length) + tokens[1]);
        int goneLony = int.Parse(tokens[2] + new string('0', 2 - tokens[3].Length) + tokens[3]);

        int arrivedMony = int.Parse(tokens[4] + new string('0', 2 - tokens[5].Length) + tokens[5]);
        int goneMony = int.Parse(tokens[6] + new string('0', 2 - tokens[7].Length) + tokens[7]);

        if (arrivedLony <= arrivedMony && goneMony <= goneLony)
        {
            //      ___________
            //------|         |-------
            //--------|_____|---------
            //
            // Return Mony's arrived and gone hours
            Console.WriteLine("{0} {1} {2} {3}", tokens[4], tokens[5], tokens[6], tokens[7]);
        }
        else if (arrivedMony <= arrivedLony && goneLony <= goneMony)
        {
            //      ___________
            //------|         |-------
            //----|_____________|-----
            //
            // Return Lony's arrived and gone hours
            Console.WriteLine("{0} {1} {2} {3}", tokens[0], tokens[1], tokens[2], tokens[3]);
        }
        else if (arrivedMony <= arrivedLony && arrivedLony <= goneMony && goneMony <= goneLony)
        {
            //      ___________
            //------|         |-------
            //----|________|----------
            //
            // Return Lony's arrived hours and Mony's gone hours
            Console.WriteLine("{0} {1} {2} {3}", tokens[0], tokens[1], tokens[6], tokens[7]);
        }
        else if (arrivedLony <= arrivedMony && arrivedMony <= goneLony && goneLony <= goneMony)
        {
            //      ___________
            //------|         |-------
            //----------|________|----------
            //
            // Return Mony's arrived hours and Lony's gone hours
            Console.WriteLine("{0} {1} {2} {3}", tokens[4], tokens[5], tokens[2], tokens[3]);
        }
        else
        {
            Console.WriteLine("No");
        }
    }
}