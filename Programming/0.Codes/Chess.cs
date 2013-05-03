using System;

class Field
{
    //Properties
    public char x { get; set; }

    public int y { get; set; }

    //Default constructor
    public Field()
    {
    }

    //Horse
    public static void Horse(Field cell, Field figure)
    {
        //RIGHT
        cell.x = (char)(figure.x + 1);
        cell.y = figure.y - 2;
        Field.Print(cell);

        cell.x = (char)(figure.x + 1);
        cell.y = figure.y + 2;
        Field.Print(cell);

        cell.x = (char)(figure.x + 2);
        cell.y = figure.y - 1;
        Field.Print(cell);

        cell.x = (char)(figure.x + 2);
        cell.y = figure.y + 1;
        Field.Print(cell);

        //LEFT
        cell.x = (char)(figure.x - 1);
        cell.y = figure.y - 2;
        Field.Print(cell);

        cell.x = (char)(figure.x - 1);
        cell.y = figure.y + 2;
        Field.Print(cell);

        cell.x = (char)(figure.x - 2);
        cell.y = figure.y - 1;
        Field.Print(cell);

        cell.x = (char)(figure.x - 2);
        cell.y = figure.y + 1;
        Field.Print(cell);
    }

    //King
    public static void King(Field cell, Field figure)
    {
        cell.x = (char)(figure.x + 1);
        cell.y = figure.y + 1;
        Field.Print(cell);

        cell.x = (char)(figure.x + 1);
        cell.y = figure.y;
        Field.Print(cell);

        cell.x = (char)(figure.x + 1);
        cell.y = figure.y - 1;
        Field.Print(cell);

        cell.x = figure.x;
        cell.y = figure.y + 1;
        Field.Print(cell);

        cell.x = figure.x;
        cell.y = figure.y - 1;
        Field.Print(cell);

        cell.x = (char)(figure.x - 1);
        cell.y = figure.y + 1;
        Field.Print(cell);

        cell.x = (char)(figure.x - 1);
        cell.y = figure.y;
        Field.Print(cell);

        cell.x = (char)(figure.x - 1);
        cell.y = figure.y - 1;
        Field.Print(cell);
    }

    //Rook
    public static void Rook(Field cell, Field figure)
    {
        int[] dirX = { 0, -1, 0, 1 };
        int[] dirY = { -1, 0, 1, 0 };

        for (int direction = 0; direction < 4; direction++)
        {
            cell.x = (char)(figure.x + dirX[direction]);
            cell.y = figure.y + dirY[direction];

            do
            {
                Print(cell);
                cell.x = (char)(cell.x + dirX[direction]);
                cell.y = cell.y + dirY[direction];

                if (cell.x < 'a' || cell.x > 'h' || cell.y < 1 || cell.y > 8)
                    break;
            }
            while (true);
        }
    }

    //Officer
    public static void Officer(Field cell, Field figure)
    {
        int[] dirX = { -1, -1, 1, 1 };
        int[] dirY = { -1, 1, 1, -1 };

        for (int direction = 0; direction < 4; direction++)
        {
            cell.x = (char)(figure.x + dirX[direction]);
            cell.y = figure.y + dirY[direction];

            do
            {
                Print(cell);
                cell.x = (char)(cell.x + dirX[direction]);
                cell.y = cell.y + dirY[direction];

                if (cell.x < 'a' || cell.x > 'h' || cell.y < 1 || cell.y > 8)
                    break;
            }
            while (true);
        }
    }

    //Printing
    public static void Print(Field cell)
    {
        if (cell.x >= 'a' && cell.x <= 'h' && cell.y >= 1 && cell.y <= 8)
        {
            Program.table[cell.y - 1, Math.Abs('h' - cell.x - 7)] = 1;
            Console.Write("({0};{1}) ", cell.x, cell.y);
        }
    }
}

class Program
{
    public static int[,] table = new int[8, 8];

    static void Main()
    {
        Field figure = new Field();
        Field cell = new Field();

        do
        {
            Console.Write("Enter symbol between a - h: ");
            figure.x = char.Parse(Console.ReadLine());
        }
        while (figure.x < 'a' || figure.x > 'h');

        do
        {
            Console.Write("Enter number between 1 - 8: ");
            figure.y = Int32.Parse(Console.ReadLine());
        }
        while (figure.y < 1 || figure.y > 8);

        table[figure.y - 1, Math.Abs('h' - figure.x - 7)] = 2;

        Console.WriteLine();
        Console.WriteLine("Choice: ");
        Console.WriteLine("     1 - for Horse");
        Console.WriteLine("     2 - for King");
        Console.WriteLine("     3 - for Rook");
        Console.WriteLine("     4 - for Officer");

        Console.WriteLine();
        Console.Write("Enter your choice: ");
        int choice = int.Parse(Console.ReadLine());

        Console.WriteLine();
        Console.Write("Coordinates: ");
        if (choice == 1)
        {
            Field.Horse(cell, figure);
        }
        else if (choice == 2)
        {
            Field.King(cell, figure);
        }
        else if (choice == 3)
        {
            Field.Rook(cell, figure);
        }
        else if (choice == 4)
        {
            Field.Officer(cell, figure);
        }
        else
        {
            Console.WriteLine("Bad input data!");
        }

        //Printing completed table
        Console.WriteLine();
        Console.WriteLine();
        for (int row = 0; row < table.GetLongLength(0); row++)
        {
            for (int col = 0; col < table.GetLongLength(1); col++)
            {
                if (table[row, col] != 0)
                {
                    Console.Write("{0,5}", table[row, col]);
                }
                else
                {
                    Console.Write("{0,5}", "");
                }
            }
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
