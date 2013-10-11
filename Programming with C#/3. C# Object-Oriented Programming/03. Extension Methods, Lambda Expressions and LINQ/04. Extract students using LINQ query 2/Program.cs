/*
* 4. Write a LINQ query that finds the first name
* and last name of all students with age between 18 and 24.
*/

using System;
using System.Linq;

class Program
{
    static void Main()
    {
        var students = new[]
        {
            new { FirstName = "Filip", LastName = "Georgiev", Age = 23 },
            new { FirstName = "Dimityr", LastName = "Cvetkov", Age = 17 },
            new { FirstName = "Cvetelina", LastName = "Dimitrova", Age = 45 },
            new { FirstName = "Boris", LastName = "Angelov", Age = 18 },
            new { FirstName = "Angel", LastName = "Borisov", Age = 20 },
        };

        // Linq query
        var query =
                   from student in students
                   where student.Age >= 18 && student.Age <= 24
                   select new { student.FirstName, student.LastName };

        Console.WriteLine("#1: Using LINQ query: ");
        Console.WriteLine(string.Join(Environment.NewLine, query));
    }
}