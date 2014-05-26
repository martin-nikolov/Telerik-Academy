/*
 * 1. Write three classes: Student, Course and School. Students should have
 * name and unique number (inside the entire School). Name can not be empty 
 * and the unique number is between 10000 and 99999. Each course contains a 
 * set of students. Students in a course should be less than 30 and can join 
 * and leave courses.
 * 
 * 2. Write VSTT tests for these two classes
 *  -> Use 2 class library projects in Visual Studio: School.csproj and TestSchool.csproj
 *  
 * 3. Execute the tests using Visual Studio and check the code coverage.
 * Ensure it is at least 90%.
 */

namespace School.Client
{
    using System;
    using System.Linq;
    using School.Models;

    internal class SchoolClient
    {
        static void Main()
        {
            var school = new School();

            var studentIvan = school.RegisterStudent("Ivan");
            Console.WriteLine(studentIvan);

            var studentPeter = school.RegisterStudent("Peter");
            Console.WriteLine(studentPeter);

            var csharpCourse = school.RegisterCourse("C# Fundamentals");
            school.AddStudentToCourse(studentIvan, csharpCourse);
            school.AddStudentToCourse(studentPeter, csharpCourse);

            Console.WriteLine(csharpCourse);
        }
    }
}