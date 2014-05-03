namespace Games.IOEngines
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Games;
    using Games.Interfaces;

    public class ConsoleWriter : IWriter
    {
        public void ShowCommands()
        {
            Console.WriteLine("Commands: ");
            Console.WriteLine("'top' - shows ranklist");
            Console.WriteLine("'restart' - starts a new game");
            Console.WriteLine("'exit' - lefts the game");
        }

        public void ShowPlayground(char[,] playground)
        {
            int rows = playground.GetLength(0);
            int cols = playground.GetLength(1);

            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");

            for (int i = 0; i < rows; i++)
            {
                Console.Write("{0} | ", i);

                for (int j = 0; j < cols; j++)
                {
                    Console.Write(string.Format("{0} ", playground[i, j]));
                }

                Console.WriteLine("|");
            }

            Console.WriteLine("   ---------------------\n");
        }

        public void ShowRankList(IList<Winner> winners)
        {
            Console.WriteLine("\nRanklist: ");

            if (winners.Count > 0)
            {
                for (int i = 0; i < winners.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} points", i + 1, winners[i].Name, winners[i].Points);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Ranklist is empty!\n");
            }
        }

        public void ShowMessage(string message)
        {
            Console.Write(message);
        }
    }
}