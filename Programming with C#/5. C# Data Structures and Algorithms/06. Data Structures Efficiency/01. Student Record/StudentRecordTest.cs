/*
 * 1. A text file students.txt holds information about 
 * students and their courses in the following format:
 * 
 *    Kiril  | Ivanov   | C#
 *    Stefka | Nikolova | SQL
 *    Stela  | Mineva   | Java
 *    Milena | Petrova  | C#
 *    Ivan   | Grigorov | C#
 *    Ivan   | Kolev    | SQL
 * 
 * Using SortedDictionary<K,T> print the courses in 
 * alphabetical order and for each of them prints the 
 * students ordered by family and then by name:
 *
 *    C#: Ivan Grigorov, Kiril Ivanov, Milena Petrova
 *    Java: Stela Mineva
 *    SQL: Ivan Kolev, Stefka Nikolova
 */

namespace DataStructuresEfficiency
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Wintellect.PowerCollections;

    public static class StudentRecordTest
    {
        static readonly SortedDictionary<Course, OrderedBag<Student>> studentCourses =
            new SortedDictionary<Course, OrderedBag<Student>>();

        public static void Main()
        {
            ParseInput();
            PrintStudentCourses();
        }
  
        private static void ParseInput()
        {
            using (var reader = new StreamReader("../../students.txt"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var studentInfo = line.Split(new char[] { ' ', '|' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                    studentCourses.AddOrCreate(studentInfo[2], studentInfo[0], studentInfo[1]);
                }
            }
        }

        private static void AddOrCreate(this SortedDictionary<Course, OrderedBag<Student>> dictionary, string courseName, params string[] studentNames)
        {
            var course = new Course(courseName);
            var student = new Student(studentNames[0], studentNames[1]);

            if (!dictionary.ContainsKey(course))
            {
                dictionary[course] = new OrderedBag<Student>();
            }

            dictionary[course].Add(student);
        }

        private static void PrintStudentCourses()
        {
            foreach (var course in studentCourses)
            {
                Console.WriteLine(course.Key);

                foreach (var student in course.Value)
                {
                    Console.WriteLine("   - {0}", student);
                }

                Console.WriteLine();
            }
        }
    }
}