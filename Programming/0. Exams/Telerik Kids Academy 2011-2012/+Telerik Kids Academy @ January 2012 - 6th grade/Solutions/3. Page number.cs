using System;
using System.Linq;

class PageNumbers
{
    static string inscription = string.Empty;

    static void Main()
    {
        inscription = Console.ReadLine();

        if (inscription[0] == '0')
        {
            Console.WriteLine(0);
            return;
        }

        DateTime now = DateTime.Now;

        int correctPages = 0;
        int middleIndex = inscription.Length / 2 - 1;

        if (IsOutOfRange(middleIndex)) // OutOfRange
            return;

        if (inscription[middleIndex] != '0' && inscription[middleIndex + 1] == '0')
        {
            if (IsOutOfRange(--middleIndex)) // OutOfRange
                return;
        }

        if (inscription[middleIndex] == '0' && inscription[middleIndex + 1] == '0')
        {
            while (middleIndex >= 0 && inscription[middleIndex] == '0')
                middleIndex--;

            if (IsOutOfRange(--middleIndex)) // OutOfRange
                return;
        }

        string left = inscription.Substring(0, middleIndex + 1);

        int indexLeft = left.Length;
        while (indexLeft > 0)
        {
            if (indexLeft == inscription.Length - left.Length)
            {
                string l = left.Substring(0, indexLeft); // left
                string r = inscription.Substring(indexLeft); // right
                bool isLeftGreater = true;

                for (int i = 0; i < l.Length; i++)
                {
                    if (l[i] > r[i])
                    {
                        isLeftGreater = false;
                        break;
                    }
                    else
                    {
                        isLeftGreater = true;
                        break;
                    }
                }

                if (!isLeftGreater)
                    correctPages--;
            }

            correctPages++;

            while (left[indexLeft - 1] == '0')
                indexLeft--;

            indexLeft--;
        }

        Console.WriteLine(correctPages);
        //Console.WriteLine(DateTime.Now - now);
    }

    static bool IsOutOfRange(int index)
    {
        if (index < 0 || index + 1 >= inscription.Length)
        {
            Console.WriteLine(0);
            return true;
        }

        return false;
    }
}
