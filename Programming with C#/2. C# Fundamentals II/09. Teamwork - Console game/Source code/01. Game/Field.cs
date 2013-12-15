using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Linq;
using ConsoleExtender;

namespace _01.Game
{
    public class Field
    {
        public static List<RankList> Ranklist = new List<RankList>();
        public static int Score = 0, LivesCount = 3;
        public static int Speed = 300;
        public static bool IsChangedStatus = true, IsChangedScore = false;

        static string lines;

        static Field()
        {
            string[] content = new string[10];
            string ranks = string.Empty;

            if (System.IO.File.Exists("Ranking/ranklist.txt"))
                using (System.IO.StreamReader reader = new System.IO.StreamReader("Ranking/ranklist.txt", Encoding.UTF8))
                    ranks = reader.ReadToEnd();

            if (ranks != string.Empty)
                content = ranks.Split(new string[] { "\r\n" }, StringSplitOptions.None);

            int end = 10;

            for (int i = 0; i < content.Length && i < end; i++)
            {
                try
                {
                    string[] info = content[i].Split(new string[] { " - " }, StringSplitOptions.None);
                    Ranklist.Add(new RankList(info[0], int.Parse(info[1])));
                }
                catch (Exception)
                {
                    end++;
                    continue;
                }
            }

            Ranklist = Ranklist.OrderByDescending(x => x.Result).ToList();
        }

        public static void GetFieldOptions()
        {
            Console.Title = "Free Space Invaders!";

            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            ConsoleHelper.SetConsoleFont(9);
            ConsoleHelper.SetConsoleIcon(SystemIcons.Exclamation);

            Console.SetWindowSize(95, 35);
            Console.SetBufferSize(95, 35);

            lines = "   <" + new string('-', Console.WindowWidth - 8) + ">";

            Console.CursorVisible = false;
            Console.TreatControlCAsInput = true;
        }

        public static void ShowStatus()
        {
            IsChangedStatus = false;

            Console.SetCursorPosition(0, Console.WindowHeight - 5);
            Console.WriteLine("{0}\n     SCORE: {1:0000} {2} | FREE SPACE INVADERS |  {2} LIVES: {3}\n{0}",
                lines, Score, new string(' ', Console.BufferWidth / 2 - 29), new string('♥', LivesCount).PadRight(3, ' '));
        }

        public static void CheckForAvailableKey()
        {
            while (Console.KeyAvailable)
            {
                ConsoleKeyInfo userKey = Console.ReadKey(true);

                if (userKey.Key == ConsoleKey.LeftArrow)
                {
                    PlayerShip.MoveLeft();
                }
                else if (userKey.Key == ConsoleKey.RightArrow)
                {
                    PlayerShip.MoveRight();
                }
                else if (userKey.Key == ConsoleKey.Escape)
                {
                    Console.Clear();
                    Environment.Exit(Environment.ExitCode);
                }
                else if (Program.IsPlayerShootNow == false && (userKey.Key == ConsoleKey.Spacebar || userKey.Key == ConsoleKey.Enter))
                {
                    Thread shoot = new Thread(PlayerShip.Shoot);

                    if (Program.ShootSound != null) Program.ShootSound.controls.play();

                    shoot.Start();
                }
            }
        }

        public static int Introduction()
        {
            Console.Clear();
            Field.GetFieldOptions();

            string freeSpace = @"
@@@@@@  @@@@@@  @@@@@@  @@@@@@       @@@@@@  @@@@@@     @@@      @@@@@@  @@@@@@  
@@      @@  @@  @@      @@           @@      @@  @@    @@ @@     @@      @@
@@@@    @@@@@@  @@@@    @@@@         @@@@@@  @@@@@@   @@   @@    @@      @@@@  
@@      @@ @    @@      @@               @@  @@      @@ @@@ @@   @@      @@
@@      @@  @   @@@@@@  @@@@@@       @@@@@@  @@     @@       @@  @@@@@@  @@@@@@";

            string invaders = @"
 @@@@  @@     @@  @@       @@   @@@      @@@@@@    @@@@@@  @@@@@@  @@@@@@
  @@   @@ @   @@   @@     @@   @@ @@     @@   @@   @@      @@  @@  @@
  @@   @@  @  @@    @@   @@   @@   @@    @@    @@  @@@@    @@@@@@  @@@@@@
  @@   @@   @ @@     @@ @@   @@ @@@ @@   @@   @@   @@      @@ @        @@
 @@@@  @@     @@      @@@   @@       @@  @@@@@@    @@@@@@  @@  @   @@@@@@";


            char[] arrow = { '-', '-', '-', '>' };
            int space = 12, choice = 1;

            for (int i = 0; i < arrow.Length; i++)
            {
                Console.SetCursorPosition(Console.WindowWidth / 2 - space + 1 + i, Console.WindowHeight / 2 - choice - 2);
                Console.Write(arrow[i]);
            }

            int count = 15;
            Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2 - count);

            for (int i = 0; i < freeSpace.Length; i++)
            {
                if (freeSpace[i] == '@')
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.Write(" ");
                }

                if (freeSpace[i] == '#')
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.Write(" ");
                }

                if (freeSpace[i] == ' ')
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write(" ");
                }

                if (freeSpace[i] == '\n')
                {
                    Console.WriteLine();
                    Console.SetCursorPosition(Console.WindowWidth / 2 - 39, Console.WindowHeight / 2 - --count);
                }
            }

            count = 0;
            Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2 - count);

            for (int i = 0; i < invaders.Length; i++)
            {
                if (invaders[i] == '@')
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.Write(" ");
                }

                if (invaders[i] == '#')
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.Write(" ");
                }

                if (invaders[i] == ' ')
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write(" ");
                }

                if (invaders[i] == '\n')
                {
                    Console.WriteLine();
                    Console.SetCursorPosition(Console.WindowWidth / 2 - 37, Console.WindowHeight / 2 + 6 - --count);
                }
            }

            string[] menus = 
            { 
                "NEW GAME",
                "INSTRUCTIONS",
                "RANK LIST",
                "ABOUT US",
                "EXIT"
            };

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.SetCursorPosition(12, Console.WindowHeight - 2);
            Console.Write("Recommended settings for best performance -> Font: Consolas, Size: 18");

            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < menus.Length; i++)
            {
                Console.SetCursorPosition(Console.WindowWidth / 2 - 5, Console.WindowHeight / 2 - 3 + i);
                Console.WriteLine(menus[i]);
            }

            Console.SetCursorPosition(Console.WindowWidth / 2 - 11, Console.WindowHeight / 2 - 2 + menus.Length);

            while (true)
            {
                while (Console.KeyAvailable)
                {
                    ConsoleKeyInfo userKey = Console.ReadKey(true);

                    if (choice <= 4 && userKey.Key == ConsoleKey.DownArrow)
                    {
                        Console.SetCursorPosition(Console.WindowWidth / 2 - space + 1, Console.WindowHeight / 2 + choice - 4);
                        Console.Write(new string(' ', arrow.Length));

                        choice++;
                        for (int i = 0; i < arrow.Length; i++)
                        {
                            Console.SetCursorPosition(Console.WindowWidth / 2 - space + 1 + i, Console.WindowHeight / 2 + choice - 4);
                            Console.Write(arrow[i]);
                        }
                    }
                    else if (choice > 1 && userKey.Key == ConsoleKey.UpArrow)
                    {
                        Console.SetCursorPosition(Console.WindowWidth / 2 - space + 1, Console.WindowHeight / 2 + choice - 4);
                        Console.Write(new string(' ', arrow.Length));

                        choice--;
                        for (int i = 0; i < arrow.Length; i++)
                        {
                            Console.SetCursorPosition(Console.WindowWidth / 2 - space + 1 + i, Console.WindowHeight / 2 + choice - 4);
                            Console.Write(arrow[i]);
                        }
                    }
                    else if (userKey.Key == ConsoleKey.Enter)
                    {
                        Console.SetCursorPosition(0, Console.WindowHeight - 1);
                        return choice;
                    }
                }
            }
        }

        public static void MenuInstructions()
        {
            string[] alien = @"  /--\
<======>  
  \--/".Split('\n');

            Console.Clear();

            int left = -12, top = 3;

            Console.BackgroundColor = ConsoleColor.Gray;

            for (int i = 0; i < 30; i++)
            {
                Console.SetCursorPosition(left + 15 + i, top - 1);
                Console.Write(" ");
                Console.SetCursorPosition(left + 15 + i, top + 25);
                Console.Write(" ");
            }

            for (int i = 0; i < 25; i++)
            {
                Console.SetCursorPosition(left + 15, top + i);
                Console.Write(" ");
                Console.SetCursorPosition(left + 44, top + i);
                Console.Write(" ");
            }

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkCyan;

            for (int i = 0; i < 3; i++)
            {
                Console.SetCursorPosition(left + 24, top + 3 - i);
                Console.WriteLine(string.Join("", Invaders.Ship3[2 - i]));
            }

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.SetCursorPosition(left + 30, top + 2);
            Console.Write("= 10 PTS");
            Console.ForegroundColor = ConsoleColor.White;

            Console.ForegroundColor = ConsoleColor.Yellow;
            for (int i = 0; i < 3; i++)
            {
                Console.SetCursorPosition(left + 23, top + 8 - i);
                Console.WriteLine(string.Join("", Invaders.Ship2[2 - i]));
            }

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.SetCursorPosition(left + 30, top + 7);
            Console.Write("= 25 PTS");
            Console.ForegroundColor = ConsoleColor.White;

            Console.ForegroundColor = ConsoleColor.Cyan;
            for (int i = 0; i < 3; i++)
            {
                Console.SetCursorPosition(left + 24, top + 13 - i);
                Console.WriteLine(string.Join("", Invaders.Ship1[2 - i]));
            }

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.SetCursorPosition(left + 30, top + 12);
            Console.Write("= 50 PTS");
            Console.ForegroundColor = ConsoleColor.White;

            Console.ForegroundColor = ConsoleColor.Red;
            for (int i = 0; i < 3; i++)
            {
                Console.SetCursorPosition(left + 21, top + 18 - i);
                Console.WriteLine(string.Join("", alien[2 - i]));
            }

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.SetCursorPosition(left + 30, top + 17);
            Console.Write("= ??? PTS");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(left + 24, top + 21);
            Console.Write("EASTER EGG!");

            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(Console.WindowWidth / 2 - 10, Console.WindowHeight - 4);
            Console.Write("---> BACK TO MENU");

            Console.ForegroundColor = ConsoleColor.DarkGreen;

            string[] messages =
            {     
                "                       Message:",
                "Brother, you have only one mission - To Save The World!",
                "You will encounter lots of difficulties on your way...",
                "Please, defend us from the Alien invaders and flying",
                "            saucers! We believe in you!",
                "                       Options:",
                "                        -------",
                "  Use keyboard's arrows |  <  | to move Left",
                "                        -------",
                "             -------",
                "         and |  >  | to move Right",
                "             -------",
                "      Use [SPACE] or [ENTER] to shoot",
                "      Use [ESCAPE] to leave the game"
            };

            for (int i = 0; i < messages.Length; i++)
            {
                if (i == 0 || i == 5) Console.ForegroundColor = ConsoleColor.Cyan;
                else if (i > 0) Console.ForegroundColor = ConsoleColor.DarkGreen;

                Console.SetCursorPosition(36, 3 + i + i);

                if (i == 5)
                {
                    Console.SetCursorPosition(36, 3 + i + 7);
                }

                if (i >= 6)
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.SetCursorPosition(41, 3 + i + 8);
                }
                if (i >= 12)
                {
                    Console.SetCursorPosition(41, 3 + i + i - 3);
                }

                for (int j = 0; j < messages[i].Length; j++)
                {
                    if (i >= 6 && (messages[i][j] == '-' || messages[i][j] == '|')) Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    else if (i >= 6 && (messages[i][j] == '<' || messages[i][j] == '>')) Console.ForegroundColor = ConsoleColor.White;
                    else if (i >= 6) Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write(messages[i][j]);
                }
            }

            Console.ForegroundColor = ConsoleColor.White;

            while (Console.ReadKey(true).Key != ConsoleKey.Enter)
            {
                // Some code here
            }

            Program.FromOtherMenu = true;
            Program.Main();
        }

        public static void MenuAbout()
        {
            string team = @"
@@@@@@  @@@@@@      @@@      @@@   @@@
  @@    @@         @@ @@     @@ @ @ @@
  @@    @@@@      @@   @@    @@  @  @@
  @@    @@       @@ @@@ @@   @@     @@
  @@    @@@@@@  @@       @@  @@     @@";

            string goofy = @"
@@@@@@  @@@@@@  @@@@@@  @@@@@@  @@   @@
@@      @@  @@  @@  @@  @@       @@ @@ 
@@ @@@  @@  @@  @@  @@  @@@@       @@
@@  @@  @@  @@  @@  @@  @@        @@ 
@@@@@@  @@@@@@  @@@@@@  @@       @@";


            Console.Clear();

            int count = 16;
            Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2 - count);

            for (int i = 0; i < goofy.Length; i++)
            {
                if (goofy[i] == '@')
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.Write(" ");
                }

                if (goofy[i] == ' ')
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write(" ");
                }

                if (goofy[i] == '\n')
                {
                    Console.WriteLine();
                    Console.SetCursorPosition(Console.WindowWidth / 2 - 20, Console.WindowHeight / 2 - --count);
                }
            }

            count = 2;
            Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2 - count);

            for (int i = 0; i < team.Length; i++)
            {
                if (team[i] == '@')
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.Write(" ");
                }

                if (team[i] == ' ')
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write(" ");
                }

                if (team[i] == '\n')
                {
                    Console.WriteLine();
                    Console.SetCursorPosition(Console.WindowWidth / 2 - 20, Console.WindowHeight / 2 + 8 - --count);
                }
            }

            int left = 3, top = 10;

            Console.BackgroundColor = ConsoleColor.Gray;

            for (int i = 0; i < 60; i++)
            {
                Console.SetCursorPosition(left + 15 + i, top - 1);
                Console.Write(" ");
                Console.SetCursorPosition(left + 15 + i, top + 11);
                Console.Write(" ");
            }

            for (int i = 0; i < 12; i++)
            {
                Console.SetCursorPosition(left + 15, top + i);
                Console.Write(" ");
                Console.SetCursorPosition(left + 74, top + i);
                Console.Write(" ");
            }

            Console.BackgroundColor = ConsoleColor.Black;
            string[] messages =
            {     
                "FREE SPACE INVADERS was developed as a team project",
                "   for the C# Part 2 Course in Telerik Academy.    ",
                "",
                "         Team Goofy. All Rights Reserved.          ",
                "",
                "            FREE SPACE INVADERS ® 2013             ",
                "",
                "       Visit us at www.flextry.wordpress.com       "
            };

            for (int i = 0; i < messages.Length; i++)
            {
                Console.SetCursorPosition(22, 11 + i);

                if (i == messages.Length - 1) Console.ForegroundColor = ConsoleColor.Yellow;
                for (int j = 0; j < messages[i].Length; j++)
                {
                    Console.Write(messages[i][j]);
                }
            }

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;

            Console.SetCursorPosition(Console.WindowWidth / 2 - 10, Console.WindowHeight - 4);
            Console.Write("---> BACK TO MENU");

            while (Console.ReadKey(true).Key != ConsoleKey.Enter)
            {
                // Some code here
            }

            Program.FromOtherMenu = true;
            Program.Main();
        }

        public static void MenuRankList()
        {
            string ranking = @"
@@@@@@     @@@      @@     @@  @@   @@  @@@@  @@     @@  @@@@@@
@@  @@    @@ @@     @@ @   @@  @@  @@    @@   @@ @   @@  @@
@@@@@@   @@   @@    @@  @  @@  @@ @@     @@   @@  @  @@  @@ @@@ 
@@ @    @@ @@@ @@   @@   @ @@  @@  @@    @@   @@   @ @@  @@  @@
@@  @  @@       @@  @@     @@  @@   @@  @@@@  @@     @@  @@@@@@";

            Console.Clear();

            int count = 16;
            Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2 - count);

            for (int i = 0; i < ranking.Length; i++)
            {
                if (ranking[i] == '@')
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.Write(" ");
                }

                if (ranking[i] == ' ')
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write(" ");
                }

                if (ranking[i] == '\n')
                {
                    Console.WriteLine();
                    Console.SetCursorPosition(Console.WindowWidth / 2 - 31, Console.WindowHeight / 2 - --count);
                }
            }

            Console.BackgroundColor = ConsoleColor.Gray;
            for (int i = 0; i < 45; i++)
            {
                Console.SetCursorPosition(25 + i, 26);
                Console.Write(" ");
                Console.SetCursorPosition(25 + i, 10);
                Console.Write(" ");
            }

            for (int i = 0; i < 16; i++)
            {
                Console.SetCursorPosition(25, 11 + i);
                Console.Write(" ");
                Console.SetCursorPosition(69, 11 + i);
                Console.Write(" ");
            }

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;

            Console.SetCursorPosition(40, 12);
            Console.Write("Top 10 players:");

            if (Ranklist.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(29, 17);
                Console.Write("-> There are no players in ranking...");

                Console.SetCursorPosition(35, 19);
                Console.Write("Be first with own record!");
            }
            else
            {
                for (int i = 0; i < Ranklist.Count; i++)
                {
                    Console.SetCursorPosition(27, 14 + i);
                    if (Ranklist[i].Name.Length >= 20)
                        Ranklist[i] = new RankList(Ranklist[i].Name.Remove(19).Insert(19, "."), Ranklist[i].Result);


                    Console.Write("{0,2}. {1} - {2} PTS", i + 1, Ranklist[i].Name, Ranklist[i].Result);
                }

                Console.SetCursorPosition(27, 14 + Ranklist.Count);
                Console.Write(".....");
            }


            Console.ForegroundColor = ConsoleColor.White;

            Console.SetCursorPosition(Console.WindowWidth / 2 - 10, Console.WindowHeight - 4);
            Console.Write("---> BACK TO MENU");

            while (Console.ReadKey(true).Key != ConsoleKey.Enter)
            {
                // Some code here
            }

            Program.FromOtherMenu = true;
            Program.Main();
        }

        public static void ThreeSeconds()
        {
            Console.Clear();

            string[] seconds = new string[3];

            seconds[0] = @"
 @@@@@
    @@
    @@
    @@
    @@
    @@
    @@ ";

            seconds[1] = @"
@@@@@@
@@  @@
    @@
   @
  @
 @   @
@@@@@@ ";

            seconds[2] = @"
@@@@@@
    @@
    @@
@@@@@@
    @@
    @@
@@@@@@ ";

            for (int i = 2; i >= 0; i--)
            {
                int newLines = 7;

                Console.Clear();

                Console.SetCursorPosition(15, 20 - newLines);

                for (int j = 0; j < seconds[i].Length; j++)
                {
                    if (seconds[i][j] == '@')
                    {
                        switch (i)
                        {
                            case 2: Console.BackgroundColor = ConsoleColor.White; break;
                            case 1: Console.BackgroundColor = ConsoleColor.Green; break;
                            case 0: Console.BackgroundColor = ConsoleColor.Red; break;
                        }

                        Console.Write(" ");
                    }
                    else if (seconds[i][j] == '\n')
                    {
                        Console.WriteLine();
                        newLines--;
                        Console.SetCursorPosition(43, 20 - newLines);
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write(" ");
                    }
                }

                Console.WriteLine();
                Thread.Sleep(1000);
            }
        }

        public static void EndGame()
        {
            WMPLib.WindowsMediaPlayer endSound = new WMPLib.WindowsMediaPlayer();
            if (Program.BossSound != null) Program.BossSound.controls.stop();

            string message = string.Empty;
            bool isWinner = false;

            string gameOver = @"
#                                                                #
  #                                                            #
    #                                                        #
      #                                                    #
        ##################################################
        #                                                #
        #    @@@@@@@      @@@      @@@   @@@  @@@@@@@    #
        #    @@          @@ @@     @@ @ @ @@  @@         #
        #    @@  @@@    @@   @@    @@  @  @@  @@@@@      #
        #    @@   @@   @@ @@@ @@   @@     @@  @@         #
        #    @@@@@@@  @@       @@  @@     @@  @@@@@@@    #
        #                                                #
        #                                                #
        #    @@@@@@@  @@       @@  @@@@@@@@  @@@@@@@@    #
        #    @@   @@   @@     @@   @@        @@    @@    #
        #    @@   @@    @@   @@    @@@@@@    @@@@@@@@    #
        #    @@   @@     @@ @@     @@        @@ @@       #
        #    @@@@@@@      @@@      @@@@@@@@  @@   @@     #
        #                                                #
        ##################################################
";

            string winner = @"
#                                                                #
  #                                                            #
    #                                                        #
      #                                                    #
        ##################################################
        #                                                #
        #           @@   @@  @@@@@@@  @@   @@            #
        #            @@ @@   @@   @@  @@   @@            #
        #             @@@    @@   @@  @@   @@            #
        #             @@@    @@   @@  @@   @@            #
        #             @@@    @@@@@@@  @@@@@@@            #
        #                                                #
        #                                                #
        #   @@       @@@       @@  @@@@@@@  @@     @@    #
        #    @@     @@ @@     @@   @@   @@  @@ @   @@    #
        #     @@   @@   @@   @@    @@   @@  @@  @  @@    #
        #      @@ @@     @@ @@     @@   @@  @@   @ @@    #
        #       @@@       @@@      @@@@@@@  @@     @@    #
        #                                                #
        ##################################################";

            try
            {
                if (Boss.BossTime && Boss.Hitted <= 0)
                {
                    if (System.IO.File.Exists("Sounds/winner.mp3"))
                    {
                        endSound = new WMPLib.WindowsMediaPlayer();
                        endSound.URL = "Sounds/winner.mp3";
                        endSound.settings.autoStart = false;
                        endSound.settings.playCount = 10;
                        endSound.controls.play();
                    }

                    message = winner;
                    isWinner = true;
                }
                else
                {
                    if (System.IO.File.Exists("Sounds/game_over.mp3"))
                    {
                        endSound = new WMPLib.WindowsMediaPlayer();
                        endSound.URL = "Sounds/game_over.mp3";
                        endSound.settings.autoStart = false;
                        endSound.settings.playCount = 10;
                        endSound.controls.play();
                    }

                    message = gameOver;
                }
            }
            catch (Exception)
            {
                return;
            }
            finally
            {
                Console.Clear();
                Console.Clear();
                int count = 17;
                Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2 - count);

                for (int i = 0; i < message.Length; i++)
                {
                    if (message[i] == '@')
                    {
                        if (isWinner) Console.BackgroundColor = ConsoleColor.Green;
                        else Console.BackgroundColor = ConsoleColor.Red;
                        Console.Write(" ");
                    }

                    if (message[i] == '#')
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.Write(" ");
                    }

                    if (message[i] == ' ')
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write(" ");
                    }

                    if (message[i] == '\n')
                    {
                        Console.WriteLine();
                        Console.SetCursorPosition(Console.WindowWidth / 2 - 33, Console.WindowHeight / 2 - --count);
                    }
                }

                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.SetCursorPosition(Console.WindowWidth / 2 - 8, Console.WindowHeight / 2 + 5);
                Console.WriteLine("Your score: {0}", Field.Score.ToString().PadLeft(4, '0'));

                Console.ForegroundColor = ConsoleColor.White;
                Console.CursorVisible = true;
                Console.SetCursorPosition(Console.WindowWidth / 2 - 10, Console.WindowHeight / 2 + 8);
                Console.Write("Enter your name: ");

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.InputEncoding = Encoding.Default;
                Console.OutputEncoding = Encoding.Default;

                string name = Console.ReadLine();
                name = name.TrimStart().TrimEnd();
                if (name == null || name == string.Empty || name.Length == 0) name = "unknown";
                if (name.Length >= 20) name = name.Remove(19).Insert(19, ".");

                Console.CursorVisible = false;

                Ranklist.Add(new RankList(name, Field.Score));
                Ranklist = Ranklist.OrderByDescending(x => x.Result).ToList();

                try
                {
                    // Write names and scores to the ranklist file
                    using (System.IO.StreamWriter writer = new System.IO.StreamWriter("Ranking/ranklist.txt", false, Encoding.Unicode))
                        for (int i = 0; i < Ranklist.Count; i++)
                            if (Ranklist[i].Result > 0) writer.WriteLine("{0} - {1}", Ranklist[i].Name, Ranklist[i].Result);
                }
                catch (Exception)
                {
                    Environment.Exit(Environment.ExitCode);
                }

                Console.ForegroundColor = ConsoleColor.Gray;
                Console.BackgroundColor = ConsoleColor.Black;

                Console.SetCursorPosition(33, 28);
                Environment.Exit(1);
            }
        }

        public struct RankList
        {
            public string Name;
            public int Result;

            public RankList(string name, int result)
            {
                Name = name;
                Result = result;
            }
        }
    }
}