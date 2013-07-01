using System;

class Program
{
    static char[,] lab =
    {
        { ' ', ' ', ' ', '*', ' ', ' ', ' ', },
        { '*', '*', ' ', '*', ' ', '*', ' ', },
        { ' ', ' ', ' ', ' ', ' ', ' ', ' ', },
        { ' ', '*', '*', '*', '*', '*', ' ', },
        { ' ', ' ', ' ', ' ', ' ', ' ', 'e', }
    };

    static char[] path = new char[lab.GetLength(0) * lab.GetLength(1)];
    static int position = 0;

    static bool InRange(int row, int col)
    {
        bool rowInRange = row >= 0 && row < lab.GetLength(0);
        bool colInRange = col >= 0 && col < lab.GetLength(1);
        return rowInRange && colInRange;
    }

    static void FindExit(int row, int col, char direction)
    {
        if (!InRange(row, col))
        {
            //We are out of the labyrinth -> can't find a path
            return;
        }

        //Append the current direction to the path
        path[position] = direction;
        position++;

        //Check if we have found the exit
        if (lab[row, col] == 'e')
        {
            PrintPath(path, 1, position - 1);
        }

        if (lab[row, col] == ' ')
        {
            //Temporary mark the current cell as visited
            lab[row, col] = 's';

            //Invoke recursion to explore all possible directions
            FindExit(row, col - 1, 'L'); //left
            FindExit(row - 1, col, 'U'); //up
            FindExit(row, col + 1, 'R'); //right
            FindExit(row + 1, col, 'D'); //down            

            //Mark back the current cell as free
            lab[row, col] = ' ';
        }

        //Remove the last direction from the path
        position--;
    }

    static void PrintPath(char[] path, int start, int end)
    {
        Console.Write("Found path to the exit: ");

        for (int i = start; i <= end; i++)
        {
            Console.Write(path[i]);
        }
        Console.WriteLine();
    }

    public static void Main(string[] args)
    {
        int row = 0;
        int col = 0;

        FindExit(row, col, 'S');
    }
}