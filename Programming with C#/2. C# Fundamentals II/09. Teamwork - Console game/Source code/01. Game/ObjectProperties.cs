using System;
using System.Collections.Generic;

namespace _01.Game
{
    public class ObjectProperties
    {
        public static void PrintObject(char[,] matrix, List<Coordinates> coords, int spaces = 0, string type = "tower")
        {
            int count = 0;

            for (int row = 0; row < matrix.GetLongLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLongLength(1); col++)
                {
                    if (matrix[row, col] == ' ') continue;

                    if (coords[count].Col < 0 || coords[count].Col >= Console.WindowWidth ||
                        coords[count].Row < 0 || coords[count].Row >= Console.WindowHeight)
                    {
                        count++;
                        continue;
                    }

                    if (type == "tower") Console.ForegroundColor = ConsoleColor.Green;
                    else if (type == "alien") Console.ForegroundColor = ConsoleColor.Red;
                    else if (type == "boss") Console.ForegroundColor = ConsoleColor.Yellow;

                    Console.SetCursorPosition(coords[count].Col + spaces, coords[count].Row);
                    Console.Write(matrix[row, col]);

                    Console.ForegroundColor = ConsoleColor.Gray;
                    count++;
                }
            }
        }

        public static void SetObjectCoords(char[,] matrix, List<Coordinates> coords, int left, int top)
        {
            for (int row = 0; row < matrix.GetLongLength(0); row++, top++)
                for (int col = 0, _left = left; col < matrix.GetLongLength(1); col++, _left++)
                    if (matrix[row, col] != ' ') coords.Add(new Coordinates(top, _left));
        }

        public struct Coordinates
        {
            public int Row, Col;

            public Coordinates(int row, int col)
            {
                this.Row = row;
                this.Col = col;
            }
        }
    }
}