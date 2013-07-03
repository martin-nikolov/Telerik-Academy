using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        string[] names = { "À", "Á", "Â", "Ã", "Ä", "Å", "Æ", "Ç", "È", "É", "Ê", "Ë", "Ì", "Í", "Î" };
        Random rnd = new Random();
        names = names.OrderBy(x => rnd.Next()).ToArray();

        int[,] work = new int[15, 15];
        int br = 0;

        for (int i = 0; i < 15; i++)
        {
            for (int j = i + 1; j < 15; j++)
            {
                for (int k = j + 1; k < 15; k++)
                {
                    if (work[i, j] == 0 && work[i, k] == 0 && work[j, k] == 0)
                    {
                        br++;
                        switch (br)
                        {
                            case 1:
                                Console.WriteLine("Monday:");
                                break;
                            case 6:
                                Console.WriteLine("Tuesday:");
                                break;
                            case 11:
                                Console.WriteLine("Wednesday:");
                                break;
                            case 16:
                                Console.WriteLine("Thursday: (St. Valentine)");
                                break;
                            case 21:
                                Console.WriteLine("Friday:");
                                break;
                            case 26:
                                Console.WriteLine("Saturday:");
                                break;
                            case 31:
                                Console.WriteLine("Sunday:");
                                break;
                        }
                        
                        Console.WriteLine(names[i] + " " + names[j] + " " + names[k]);
                        work[i, j] = 1;
                        work[i, k] = 1;
                        work[j, k] = 1;
                    }
                }
            }
        }

        Console.WriteLine();

        for (int i = 0; i < 15; i++)
        {
            for (int j = 0; j < 15; j++)
            {
                Console.Write("{0,2}", work[i, j]);
            }
            Console.WriteLine();
        }
    }
}