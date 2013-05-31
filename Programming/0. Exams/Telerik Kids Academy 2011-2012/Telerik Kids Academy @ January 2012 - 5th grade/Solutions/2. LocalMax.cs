using System;
using System.Collections.Generic;
using System.Linq;

class LocalMax
{
    static void Main()
    {
        List<int> studentsHeight = new List<int>();

        int height = int.Parse(Console.ReadLine());
        int protrudingStudents = 0;

        while (height != 0) 
        {
            studentsHeight.Add(height);

            height = int.Parse(Console.ReadLine());
        }

        if (studentsHeight.Count >= 3)
        {
            for (int index = 1; index < studentsHeight.Count - 1; index++)
            {
                if (studentsHeight[index - 1] < studentsHeight[index] &&
                    studentsHeight[index] > studentsHeight[index + 1])
                {
                    protrudingStudents++;
                }
            }
        }

        Console.WriteLine(protrudingStudents);
    }
}