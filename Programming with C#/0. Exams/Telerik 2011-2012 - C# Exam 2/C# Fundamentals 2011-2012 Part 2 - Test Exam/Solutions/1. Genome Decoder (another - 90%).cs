using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

class GenomeDecoder
{
    public struct Elements
    {
        public int repeats;
        public char letter;
    }

    static void Main()
    {
        int[] tokens = Console.ReadLine().Split(' ').Select(ch => int.Parse(ch)).ToArray();

        int n = tokens[0], m = tokens[1];
        string genome = Console.ReadLine();

        List<Elements> elements = new List<Elements>();
        elements = AddLetterRepeatsToList(ref elements, genome);

        int indexLetter = 0, indexLine = 1;

        List<StringBuilder> lines = new List<StringBuilder>();

        int letterOnLine = n;

        while (indexLetter < elements.Count)
        {
            StringBuilder line = new StringBuilder();
            line.Append(string.Format("{0} ", indexLine++));

            for (int i = 1; i <= n; i++)
            {
                line.Append(elements[indexLetter].letter);

                elements[indexLetter] =
                    new Elements() { repeats = elements[indexLetter].repeats - 1, letter = elements[indexLetter].letter };

                if (elements[indexLetter].repeats == 0) indexLetter++;

                if (indexLetter >= elements.Count) break;

                if (i % m == 0) line.Append(" ");
            }

            lines.Add(line);
        }

        int numberOfSpaces = (--indexLine).ToString().Length - 1;

        for (int i = 0; i < lines.Count; i++)
        {
            if (i == 9 || i == 99 || i == 999 || i == 9999 || i == 99999) numberOfSpaces--;

            lines[i].Insert(0, new string(' ', numberOfSpaces));

            if (lines[i][lines[i].Length - 1] == ' ') lines[i].Remove(lines[i].Length - 1, 1);
        }

        foreach (var line in lines) Console.WriteLine(line);
    }

    static List<Elements> AddLetterRepeatsToList(ref List<Elements> elements, string genomeEncoded)
    {
        int number = 0;
        for (int i = 0; i < genomeEncoded.Length; i++)
        {
            if (char.IsDigit(genomeEncoded[i]))
            {
                number = number * 10 + (genomeEncoded[i] - '0');
            }
            else
            {
                if (number == 0) number = 1;
                elements.Add(new Elements() { letter = genomeEncoded[i], repeats = number });
                number = 0;
            }
        }

        return elements;
    }
}
