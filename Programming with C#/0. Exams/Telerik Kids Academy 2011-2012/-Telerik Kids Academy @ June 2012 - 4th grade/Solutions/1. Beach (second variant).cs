using System;

class Beach
{
    static void Main()
    {
        string lineReader = Console.ReadLine();
        string[] tokens = lineReader.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        int x1 = int.Parse(tokens[0]) * 60 + int.Parse(tokens[1]); // Lony
        int y1 = int.Parse(tokens[2]) * 60 + int.Parse(tokens[3]);

        int x2 = int.Parse(tokens[4]) * 60 + int.Parse(tokens[5]); // Mony
        int y2 = int.Parse(tokens[6]) * 60 + int.Parse(tokens[7]);

        if (x1 <= x2 && y2 <= y1)
        {
            //      ___________
            //------|         |-------
            //--------|_____|---------
            //
            // Return Mony's arrived and gone hours
            Console.WriteLine("{0} {1} {2} {3}", x2 / 60, x2 % 60, y2 / 60, y2 % 60);
        }
        else if (x2 <= x1 && y1 <= y2)
        {
            //      ___________
            //------|         |-------
            //----|_____________|-----
            //
            // Return Lony's arrived and gone hours
            Console.WriteLine("{0} {1} {2} {3}", x1 / 60, x1 % 60, y1 / 60, y1 % 60);
        }
        else if (x2 <= x1 && x1 <= y2 && y2 <= y1)
        {
            //      ___________
            //------|         |-------
            //----|________|----------
            //
            // Return Lony's arrived hours and Mony's gone hours
            Console.WriteLine("{0} {1} {2} {3}", x1 / 60, x1 % 60, y2 / 60, y2 % 60);
        }
        else if (x1 <= x2 && x2 <= y1 && y1 <= y2)
        {
            //      ___________
            //------|         |-------
            //----------|________|----------
            //
            // Return Mony's arrived hours and Lony's gone hours
            Console.WriteLine("{0} {1} {2} {3}", x2 / 60, x2 % 60, y1 / 60, y1 % 60);
        }
        else
        {
            Console.WriteLine("No");
        }
    }
}