## Naming Identifiers

1. Refactor the following examples to produce code with well-named C# identifiers:

    ```c#
    class class_123 {
        const int max_count=6;
        class InClass_class_123 {
        void Метод_нА_class_InClass_class_123(bool promenliva)
        {
            string promenlivaKatoString=promenliva.ToString();
            Console.WriteLine(promenlivaKatoString);    }
        }
        public static void Метод_За_Вход() {
            class_123.InClass_class_123 инстанция = new class_123.InClass_class_123();
            инстанция.Метод_нА_class_InClass_class_123(true);
        }
    }
    ```
* Refactor the following examples to produce code with well-named identifiers in C#:

    ```c#
    class Hauptklasse
    {
        enum Пол { ултра_Батка, Яка_Мацка };

        class чуек
        {
            public Пол пол { get; set; }
            public string име_на_Чуека { get; set; }
            public int Възраст { get; set; }
        }

        public void Make_Чуек(int магическия_НомерНаЕДИНЧОВЕК)
        {
            чуек new_Чуек = new чуек();
            new_Чуек.Възраст = магическия_НомерНаЕДИНЧОВЕК;
            if (магическия_НомерНаЕДИНЧОВЕК%2 == 0)
            {
                new_Чуек.име_на_Чуека = "Батката";
                new_Чуек.пол = Пол.ултра_Батка;
            }
            else
            {
                new_Чуек.име_на_Чуека = "Мацето";
                new_Чуек.пол = Пол.Яка_Мацка;
            }
        }
    }
    ```
* Refactor the following examples to produce code with well-named identifiers in JavaScript

    ```js
    function _ClickON_TheButton( THE_event, argumenti) {
        var moqProzorec = window;
        var brauzyra = moqProzorec.navigator.appCodeName;
        var ism = brauzyra === "Mozilla";

        if (ism) {
            alert("Yes");
        } else {
            alert("No");
        }
    }
    ```
* Refactor and improve the naming in the C# source code. You are allowed to make other improvements in the code as well (not only naming) as well as to fix bugs.

    ```c#
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    namespace mini4ki
    {
        public class minite
        {
            public class tochki
            {
                string име;
                int то4ки;

                public string Име
                {
                    get { return име; }
                    set { име = value; }
                }

                public int То4ки
                {
                    get { return то4ки; }
                    set { то4ки = value; }
                }

                public tochki() { }

                public tochki(string име, int то4ки)
                {
                    this.име = име;
                    this.то4ки = то4ки;
                }
            }

            static void Main(string[] аргументи)
            {
                string komanda = string.Empty;
                char[,] poleto = create_igralno_pole();
                char[,] bombite = slojibombite();
                int broya4 = 0;
                bool grum = false;
                List<tochki> shampion4eta = new List<tochki>(6);
                int red = 0;
                int kolona = 0;
                bool flag = true;
                const int maks = 35;
                bool flag2 = false;

                do
                {
                    if (flag)
                    {
                        Console.WriteLine("Hajde da igraem na “Mini4KI”. Probvaj si kasmeta da otkriesh poleteta bez mini4ki." +
                        " Komanda 'top' pokazva klasiraneto, 'restart' po4va nova igra, 'exit' izliza i hajde 4ao!");
                        dumpp(poleto);
                        flag = false;
                    }
                    Console.Write("Daj red i kolona : ");
                    komanda = Console.ReadLine().Trim();
                    if (komanda.Length >= 3)
                    {
                        if (int.TryParse(komanda[0].ToString(), out red) &&
                        int.TryParse(komanda[2].ToString(), out kolona) &&
                            red <= poleto.GetLength(0) && kolona <= poleto.GetLength(1))
                        {
                            komanda = "turn";
                        }
                    }
                    switch (komanda)
                    {
                        case "top":
                            klasacia(shampion4eta);
                            break;
                        case "restart":
                            poleto = create_igralno_pole();
                            bombite = slojibombite();
                            dumpp(poleto);
                            grum = false;
                            flag = false;
                            break;
                        case "exit":
                            Console.WriteLine("4a0, 4a0, 4a0!");
                            break;
                        case "turn":
                            if (bombite[red, kolona] != '*')
                            {
                                if (bombite[red, kolona] == '-')
                                {
                                    tisinahod(poleto, bombite, red, kolona);
                                    broya4++;
                                }
                                if (maks == broya4)
                                {
                                    flag2 = true;
                                }
                                else
                                {
                                    dumpp(poleto);
                                }
                            }
                            else
                            {
                                grum = true;
                            }
                            break;
                        default:
                            Console.WriteLine("\nGreshka! nevalidna Komanda\n");
                            break;
                    }
                    if (grum)
                    {
                        dumpp(bombite);
                        Console.Write("\nHrrrrrr! Umria gerojski s {0} to4ki. " +
                            "Daj si niknejm: ", broya4);
                        string niknejm = Console.ReadLine();
                        tochki t = new tochki(niknejm, broya4);
                        if (shampion4eta.Count < 5)
                        {
                            shampion4eta.Add(t);
                        }
                        else
                        {
                            for (int i = 0; i < shampion4eta.Count; i++)
                            {
                                if (shampion4eta[i].То4ки < t.То4ки)
                                {
                                    shampion4eta.Insert(i, t);
                                    shampion4eta.RemoveAt(shampion4eta.Count - 1);
                                    break;
                                }
                            }
                        }
                        shampion4eta.Sort((tochki r1, tochki r2) => r2.Име.CompareTo(r1.Име));
                        shampion4eta.Sort((tochki r1, tochki r2) => r2.То4ки.CompareTo(r1.То4ки));
                        klasacia(shampion4eta);

                        poleto = create_igralno_pole();
                        bombite = slojibombite();
                        broya4 = 0;
                        grum = false;
                        flag = true;
                    }
                    if (flag2)
                    {
                        Console.WriteLine("\nBRAVOOOS! Otvri 35 kletki bez kapka kryv.");
                        dumpp(bombite);
                        Console.WriteLine("Daj si imeto, batka: ");
                        string imeee = Console.ReadLine();
                        tochki to4kii = new tochki(imeee, broya4);
                        shampion4eta.Add(to4kii);
                        klasacia(shampion4eta);
                        poleto = create_igralno_pole();
                        bombite = slojibombite();
                        broya4 = 0;
                        flag2 = false;
                        flag = true;
                    }
                }
                while (komanda != "exit");
                Console.WriteLine("Made in Bulgaria - Uauahahahahaha!");
                Console.WriteLine("AREEEEEEeeeeeee.");
                Console.Read();
            }

            private static void klasacia(List<tochki> to4kii)
            {
                Console.WriteLine("\nTo4KI:");
                if (to4kii.Count > 0)
                {
                    for (int i = 0; i < to4kii.Count; i++)
                    {
                        Console.WriteLine("{0}. {1} --> {2} kutii",
                            i + 1, to4kii[i].Име, to4kii[i].То4ки);
                    }
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("prazna klasaciq!\n");
                }
            }

            private static void tisinahod(char[,] POLE,
                char[,] BOMBI, int RED, int KOLONA)
            {
                char kolkoBombi = kolko(BOMBI, RED, KOLONA);
                BOMBI[RED, KOLONA] = kolkoBombi;
                POLE[RED, KOLONA] = kolkoBombi;
            }

            private static void dumpp(char[,] board)
            {
                int RRR = board.GetLength(0);
                int KKK = board.GetLength(1);
                Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
                Console.WriteLine("   ---------------------");
                for (int i = 0; i < RRR; i++)
                {
                    Console.Write("{0} | ", i);
                    for (int j = 0; j < KKK; j++)
                    {
                        Console.Write(string.Format("{0} ", board[i, j]));
                    }
                    Console.Write("|");
                    Console.WriteLine();
                }
                Console.WriteLine("   ---------------------\n");
            }

            private static char[,] create_igralno_pole()
            {
                int boardRows = 5;
                int boardColumns = 10;
                char[,] board = new char[boardRows, boardColumns];
                for (int i = 0; i < boardRows; i++)
                {
                    for (int j = 0; j < boardColumns; j++)
                    {
                        board[i, j] = '?';
                    }
                }

                return board;
            }

            private static char[,] slojibombite()
            {
                int Редове = 5;
                int Колони = 10;
                char[,] игрално_поле = new char[Редове, Колони];

                for (int i = 0; i < Редове; i++)
                {
                    for (int j = 0; j < Колони; j++)
                    {
                        игрално_поле[i, j] = '-';
                    }
                }

                List<int> r3 = new List<int>();
                while (r3.Count < 15)
                {
                    Random random = new Random();
                    int asfd = random.Next(50);
                    if (!r3.Contains(asfd))
                    {
                        r3.Add(asfd);
                    }
                }

                foreach (int i2 in r3)
                {
                    int kol = (i2 / Колони);
                    int red = (i2 % Колони);
                    if (red == 0 && i2 != 0)
                    {
                        kol--;
                        red = Колони;
                    }
                    else
                    {
                        red++;
                    }
                    игрално_поле[kol, red - 1] = '*';
                }

                return игрално_поле;
            }

            private static void smetki(char[,] pole)
            {
                int kol = pole.GetLength(0);
                int red = pole.GetLength(1);

                for (int i = 0; i < kol; i++)
                {
                    for (int j = 0; j < red; j++)
                    {
                        if (pole[i, j] != '*')
                        {
                            char kolkoo = kolko(pole, i, j);
                            pole[i, j] = kolkoo;
                        }
                    }
                }
            }

            private static char kolko(char[,] r, int rr, int rrr)
            {
                int brojkata = 0;
                int reds = r.GetLength(0);
                int kols = r.GetLength(1);

                if (rr - 1 >= 0)
                {
                    if (r[rr - 1, rrr] == '*')
                    {
                        brojkata++;
                    }
                }
                if (rr + 1 < reds)
                {
                    if (r[rr + 1, rrr] == '*')
                    {
                        brojkata++;
                    }
                }
                if (rrr - 1 >= 0)
                {
                    if (r[rr, rrr - 1] == '*')
                    {
                        brojkata++;
                    }
                }
                if (rrr + 1 < kols)
                {
                    if (r[rr, rrr + 1] == '*')
                    {
                        brojkata++;
                    }
                }
                if ((rr - 1 >= 0) && (rrr - 1 >= 0))
                {
                    if (r[rr - 1, rrr - 1] == '*')
                    {
                        brojkata++;
                    }
                }
                if ((rr - 1 >= 0) && (rrr + 1 < kols))
                {
                    if (r[rr - 1, rrr + 1] == '*')
                    {
                        brojkata++;
                    }
                }
                if ((rr + 1 < reds) && (rrr - 1 >= 0))
                {
                    if (r[rr + 1, rrr - 1] == '*')
                    {
                        brojkata++;
                    }
                }
                if ((rr + 1 < reds) && (rrr + 1 < kols))
                {
                    if (r[rr + 1, rrr + 1] == '*')
                    {
                        brojkata++;
                    }
                }
                return char.Parse(brojkata.ToString());
            }
        }
    }
    ```