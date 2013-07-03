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

    static void FindExit(int row, int col)
    {
        if ((col < 0) || (row < 0) || (col >= lab.GetLength(1) || (row >= lab.GetLength(0))))
        {
            //We are out of the labyrinth -> can't find a path
            return;
        }

        //Check if we have found the exit
        if (lab[row, col] == 'e')
        {
            Console.WriteLine("Found the exit!");
        }

        if (lab[row, col] == ' ')
        {
            //Temporary mark the current cell as visited
            lab[row, col] = 's';

            //Invoke recursion to explore all possible directions
            FindExit(row, col - 1); //left
            FindExit(row - 1, col); //up
            FindExit(row, col + 1); //right
            FindExit(row + 1, col); //down

            //Mark back the current cell as free
            lab[row, col] = ' '; // <--
        }
    }

    public static void Main(string[] args)
    {
        FindExit(0, 0);
    }
}