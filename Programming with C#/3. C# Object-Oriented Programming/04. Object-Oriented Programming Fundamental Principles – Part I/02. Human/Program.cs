/*
* 2. Define abstract class Human with first name and last name.
* Define new class Student which is derived from Human and has
* new field – grade. Define class Worker derived from Human with
* new property WeekSalary and WorkHoursPerDay and method MoneyPerHour()
* that returns money earned by hour by the worker. Define the proper
* constructors and properties for this hierarchy. Initialize a
* list of 10 students and sort them by grade in ascending order
* (use LINQ or OrderBy() extension method). Initialize a list of
* 10 workers and sort them by money per hour in descending order.
* Merge the lists and sort them by first name and last name.
*/

using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        var students = new List<Student>()
        {
            new Student("Ivailo", "Marinov", 4),
            new Student("Kaloyan", "Marinov", 11),
            new Student("Stanislav", "Dimitrov", 10),
            new Student("Cvetelina", "Belcheva", 2),
            new Student("Filip", "Cvetkov", 12),
            new Student("Ivailo", "Marinov", 1),
            new Student("Kaloyan", "Marinov", 3),
            new Student("Stanislav", "Dimitrov", 11),
            new Student("Ivailo", "Marinov", 12),
            new Student("Kaloyan", "Marinov", 11),
        };

        students = students.OrderBy(student => student.Grade).ToList();

        foreach (var student in students)
            Console.WriteLine(student);

        Console.WriteLine();

        /* ----------------- */

        var workers = new List<Worker>()
        {
            new Worker("Lubomir", "Marinov", 2500, 25),
            new Worker("Kristian", "Marinov", 500, 5),
            new Worker("Tonislav", "Dimitrov", 323, 7),
            new Worker("Pavlin", "Belchev", 213, 4),
            new Worker("Cvetan", "Filipov", 1243.23, 21),
            new Worker("Ivailo", "Marinov", 150, 5),
            new Worker("Kaloyan", "Marinov",123.23, 5),
            new Worker("Dimiter", "Stanislavov", 2500, 21),
            new Worker("Marin", "Ivanov"),
            new Worker("Marin", "Kaloyanov", 232.23, 23),
        };

        workers = workers.OrderByDescending(worker => worker.MoneyPerHour()).ToList();

        foreach (var worker in workers)
            Console.WriteLine(worker);

        Console.WriteLine();

        /* ----------------- */

        var humans = new List<Human>();
        humans.AddRange(students);
        humans.AddRange(workers);

        humans = humans.OrderBy(human => human.FirstName).ThenBy(human => human.LastName).ToList();

        foreach (var human in humans)
            Console.WriteLine(human);
    }
}