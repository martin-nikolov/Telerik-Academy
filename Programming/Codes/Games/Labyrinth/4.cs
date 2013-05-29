using System;
 
class Program
{
    static char w = '*';
    static char e = 'e';
    static char[,] lab =  
{
 { w , w , w , w , w , w , w , w , w , w , w , w , w , w , w , w , w , w , w , w , w , w , w , w , w , w , w , w , w },
                { w ,' ', w ,' ', w ,' ', w ,' ', w ,' ', w ,' ', w ,' ', w ,' ', w ,' ',' ',' ', w ,' ',' ',' ',' ',' ',' ',' ', w },
                { w ,' ',' ',' ', w ,' ',' ',' ', w ,' ',' ',' ', w ,' ',' ',' ', w ,' ', w ,' ', w ,' ', w ,' ', w , w ,' ', w , w },
                { w ,' ', w ,' ', w ,' ', w ,' ',' ',' ', w ,' ', w ,' ', w ,' ',' ',' ', w ,' ', w ,' ', w ,' ', w ,' ',' ',' ', w },
                { w , w , w ,' ', w ,' ', w , w , w ,' ', w , w , w , w , w ,' ', w , w , w , w , w ,' ', w , w , w , w , w ,' ', w },
                { w ,' ',' ',' ',' ',' ',' ',' ', w ,' ',' ',' ', w ,' ',' ',' ',' ',' ', w ,' ',' ',' ',' ',' ', w ,' ',' ',' ', w },
                { w , w , w ,' ', w , w ,' ', w , w , w ,' ', w , w ,' ', w , w , w ,' ',' ',' ', w , w ,' ', w , w , w ,' ', w , w },
                { w ,' ',' ',' ', w ,' ',' ',' ', w ,' ',' ',' ', w ,' ',' ',' ', w ,' ', w ,' ', w ,' ',' ',' ', w ,' ',' ',' ', w },
                { w ,' ', w , w , w ,' ', w , w , w , w , w , w , w , w , w , w , w , w , w ,' ', w , w , w , w , w , w , w , w , w },
                { w ,' ', w ,' ', w ,' ',' ',' ',' ',' ',' ',' ', w ,' ', w ,' ', w ,' ', w ,' ', w ,' ',' ',' ', w ,' ',' ',' ', w },
                { w ,' ',' ',' ', w , w , w ,' ', w , w , w ,' ', w ,' ', w ,' ', w ,' ',' ',' ', w , w , w ,' ', w , w ,' ', w , w },
                { w ,' ', w ,' ', w ,' ',' ',' ', w ,' ',' ',' ', w ,' ',' ',' ',' ',' ', w ,' ', w ,' ',' ',' ',' ',' ',' ',' ', w },
                { w ,' ', w , w , w ,' ', w , w , w , w , w ,' ',' ',' ', w , w , w , w , w , w , w , w , w , w , w ,' ', w , w , w },
                { w ,' ', w ,' ', w ,' ',' ',' ', w ,' ',' ',' ', w ,' ',' ',' ', w ,' ',' ',' ',' ',' ',' ',' ', w ,' ',' ',' ', w },
                { w ,' ', w ,' ', w ,' ', w ,' ', w , w , w ,' ', w ,' ', w , w , w , w ,' ', w , w ,' ', w ,' ', w , w ,' ', w , w },
                { w ,' ',' ',' ', w ,' ', w ,' ', w ,' ',' ',' ', w ,' ',' ',' ',' ',' ',' ',' ', w ,' ', w ,' ',' ',' ',' ',' ', w },
                { w , w , w , w , w , w , w , w , w ,' ', w , w , w , w , w , w , w , w , w , w , w ,' ', w , w , w , w , w , w , w },
                { w ,' ',' ',' ', w ,' ',' ',' ',' ',' ',' ',' ', w ,' ',' ',' ',' ',' ', w ,' ', w ,' ',' ',' ',' ',' ',' ',' ', w },
                { w , w ,' ', w , w , w ,' ', w , w , w ,' ', w , w , w ,' ', w , w ,' ',' ',' ', w , w ,' ', w , w ,' ', w , w , w },
                { w ,' ',' ',' ', w ,' ',' ',' ', w ,' ',' ',' ', w ,' ',' ',' ', w ,' ', w ,' ', w ,' ',' ',' ', w ,' ',' ',' ', w },
                { w , w , w ,' ', w , w , w , w , w ,' ', w , w , w , w , w ,' ', w , w , w , w , w , w ,' ', w , w , w , w , w , w },
                { w ,' ',' ',' ', w ,' ',' ',' ',' ',' ', w ,' ', w ,' ',' ',' ', w ,' ',' ',' ',' ',' ',' ',' ', w ,' ',' ',' ', w },
                { w ,' ', w , w , w , w , w ,' ', w ,' ', w ,' ', w , w , w ,' ', w , w ,' ', w , w , w ,' ', w , w ,' ', w , w , w },
                { w ,' ',' ',' ', w ,' ',' ',' ', w ,' ',' ',' ', w ,' ',' ',' ',' ',' ',' ',' ', w ,' ',' ',' ',' ',' ',' ',' ', w },
                { w , w , w , w , w , w , w , w , w ,' ', w , w , w , w , w , w , w , w , w , w , w , w , w ,' ', w , w , w , w , w },
                { w ,' ', w ,' ', w ,' ', w ,' ',' ',' ',' ',' ', w ,' ',' ',' ', w ,' ',' ',' ',' ',' ', w ,' ', w ,' ',' ',' ', w },
                { w ,' ', w ,' ',' ',' ', w ,' ', w , w ,' ', w , w , w ,' ', w , w , w ,' ', w , w ,' ', w ,' ', w , w ,' ', w , w },
                { w ,' ',' ',' ', w ,' ',' ',' ', w ,' ',' ',' ', w ,' ',' ',' ',' ',' ',' ',' ', w ,' ',' ',' ', w ,' ',' ',' ', w },
                { w ,' ', w , w , w , w , w ,' ', w , w , w , w , w , w , w , w , w , w , w ,' ', w ,' ', w , w , w , w , w ,' ', w },
                { w ,' ',' ',' ', w ,' ', w ,' ', w ,' ', w ,' ', w ,' ', w ,' ', w ,' ', w ,' ', w ,' ',' ',' ', w ,' ',' ',' ', w },
                { w ,' ', w , w , w ,' ', w ,' ',' ',' ', w ,' ', w ,' ',' ',' ',' ',' ',' ',' ', w , w , w ,' ', w ,' ', w ,' ', w },
                { w ,' ',' ',' ', w ,' ',' ',' ', w ,' ',' ',' ', w ,' ', w ,' ', w ,' ', w ,' ', w ,' ',' ',' ',' ',' ', w ,' ', w },
                { w , e , w , w , w , w , w , w , w , w , w , w , w , w , w , w , w , w , w , w , w , w , w , w , w , w , w , w , w }
            };
 
    static char[] route = new char[lab.GetLength(0) * lab.GetLength(1)];
    static int index = 0;
    static void FindPath(int row, int col)
    {
        if (row < 0 || col < 0 || row >= lab.GetLength(0) || col >= lab.GetLength(1))
            return;
        index++;
        if (lab[row, col] == 'e')
        {
            Console.Write("Found the exit: ");
            for (int i = 0; i <= index; i++)
            {
                Console.Write(route[i]);
            }
            Console.WriteLine();
            index--;
            return;
        }
 
        if (lab[row, col] == ' ')
        {
            lab[row, col] = '-';
            route[index] = 'L';
            FindPath(row, col - 1);//left
            route[index] = 'T';
            FindPath(row - 1, col);//top
            route[index] = 'R';
            FindPath(row, col + 1);//right
            route[index] = 'D';
            FindPath(row + 1, col);//down
            lab[row, col] = ' ';
        }
        index--;
    }
    static void Main()
    {
        FindPath(17, 15);
    }
}