using System;
using System.Collections.Generic;

class Slides
{
    static void Main()
    {
        string[] tokens = Console.ReadLine().Split(' ');

        int width = int.Parse(tokens[0]);
        int height = int.Parse(tokens[1]);
        int depth = int.Parse(tokens[2]);

        string[, ,] cuboid = new string[width, height, depth];
        InitializationCuboid(cuboid, width, height, depth);

        tokens = Console.ReadLine().Split(' ');

        int ballW = int.Parse(tokens[0]);
        int ballD = int.Parse(tokens[1]);

        ExecuteCommands(cuboid, ballW, ballD, width, height, depth);
    }

    static void ExecuteCommands(string[, ,] cuboid, int ballW, int ballD, int w, int h, int d)
    {
        int ballH = 0;

        do
        {
            if (cuboid[ballW, ballH, ballD].StartsWith("E"))
            {
                if (ballH == h - 1)
                {
                    Console.WriteLine("Yes\n{0} {1} {2}", ballW, ballH, ballD); return;
                }

                ballH++;
            }
            else if (cuboid[ballW, ballH, ballD].StartsWith("B"))
            {
                Console.WriteLine("No\n{0} {1} {2}", ballW, ballH, ballD); return;
            }
            else if (cuboid[ballW, ballH, ballD].StartsWith("T"))
            {
                string[] tokens = cuboid[ballW, ballH, ballD].Split(' ');

                ballW = int.Parse(tokens[1]);
                ballD = int.Parse(tokens[2]);
            }
            else if (cuboid[ballW, ballH, ballD].StartsWith("S"))
            {
                int _w = ballW, _d = ballD;

                for (int i = 1; i < cuboid[ballW, ballH, ballD].Length; i++)
                {
                    switch (cuboid[ballW, ballH, ballD][i])
                    {
                        case 'L': _w--; break;
                        case 'R': _w++; break;
                        case 'F': _d--; break;
                        case 'B': _d++; break;
                    }
                }

                // If next coordinates are out of the cuboid -> Return the previous coordinates
                if (_w >= w || _w < 0 || _d >= d || _d < 0 || ballH + 1 >= h)
                {
                    Console.WriteLine("{0}\n{1} {2} {3}", ballH == h - 1 ? "Yes" : "No", ballW, ballH, ballD);
                    return;
                }

                ballW = _w; ballD = _d; ballH++;
            }

        } while (true);
    }

    static void InitializationCuboid(string[, ,] cuboid, int w, int h, int d)
    {
        for (int i = 0; i < h; i++)
        {
            List<string> commands = SeparateCommands(Console.ReadLine());

            for (int j = 0, count = 0; j < d; j++)
                for (int k = 0; k < w; k++) cuboid[k, i, j] = commands[count++];
        }
    }

    static List<string> SeparateCommands(string elements)
    {
        List<string> commands = new List<string>();

        for (int i = 0; i < elements.Length; i++)
        {
            if (elements[i] == '(')
            {
                i++;
                string currentCommand = string.Empty;

                while (elements[i] != ')')
                {
                    if (elements[i] == ' ')
                    {
                        if (char.IsDigit(elements[i - 1])) currentCommand += " ";
                        i++;
                    }

                    currentCommand += elements[i];
                    i++;
                }

                if (currentCommand.StartsWith("T")) currentCommand = currentCommand.Insert(1, " ");

                commands.Add(currentCommand);
            }
        }

        return commands;
    }
}
