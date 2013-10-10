/*
* 1. We are given a school. In the school there are classes of students.
* Each class has a set of teachers. Each teacher teaches a set of disciplines.
* Students have name and unique class number. Classes have unique text
* identifier. Teachers have name. Disciplines have name, number of lectures
* and number of exercises. Both teachers and students are people. Students,
* classes, teachers and disciplines could have optional comments (free text block).
*
* Your task is to identify the classes (in terms of  OOP) and their attributes
* and operations, encapsulate their fields, define the class hierarchy and
* create a class diagram with Visual Studio.
*/

using System;
using System.Linq;

class Program
{
    static void Main()
    {
        var school = new School("St. Kliment Ohridski");

        var _class = new Class("IT 3rd Semester");

        var teachers = new Teacher[]
        {
            new Teacher("Peter", "Ivanov", "Georgiev").AddDiscipline(new Discipline("Math", 20, 30), new Discipline("IT", 100, 150)),
            new Teacher("Georgi", "Ivanov", "Ivanov").AddDiscipline(new Discipline("English")),
            new Teacher("Filip", "Borisov", "Hristov").AddDiscipline(new Discipline("Physics", 2, 3), new Discipline("Analisys", 5, 10))
        };

        var students = new Student[]
        {
            new Student("Georgi", "Ivanov", "Petrov", 1),
            new Student("Ivan", "Ivanov", "Georgiev", 2),
            new Student("Hristo", "Borisov", "Filipov", 3),
            new Student("Filip", "Ivanov", "Georgiev", 4),
            new Student("Georgi", "Ivanov", "Petrov", 5),
            new Student("Hristo", "Borisov", "Filipov", 6)
        };

        school.AddClass(_class);

        // Add teachers and students to the class
        _class.AddTeacher(teachers);
        _class.AddStudent(students);

        // Remove / Add new student
        _class.RemoveStudent(new Student("Ivan", "Ivanov", "Georgiev", 2));
        _class.AddStudent(new Student("Added", "New", "Student", 2));

        // Remove / Add new teacher
        _class.RemoveTeacher(new Teacher("Peter", "Ivanov", "Georgiev"));
        _class.AddTeacher(new Teacher("Added", "New", "Teacher").AddDiscipline(new Discipline("IT", 5, 10)));

        Console.WriteLine(school);

        // Remove class
        school.RemoveClass(new Class("IT 3rd Semester"));

        Console.WriteLine(school);
    }
}