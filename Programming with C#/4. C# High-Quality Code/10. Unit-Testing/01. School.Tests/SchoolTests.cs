namespace School.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using School.Models;

    [TestClass]
    public class SchoolTests
    {
        [TestMethod]
        public void CreateStudentTest()
        {
            var school = new School();
            var studentIvan = school.RegisterStudent("Ivan");

            Assert.AreEqual(10000, studentIvan.UniqueNumber);
        }

        [TestMethod]
        public void StudentNameTest()
        {
            var school = new School();
            var studentIvan = school.RegisterStudent("Ivan");

            Assert.AreEqual("Ivan", studentIvan.Name);
        }

        [TestMethod]
        public void StudentsCountAfterCreateStudentTest()
        {
            var school = new School();
            var studentIvan = school.RegisterStudent("Ivan");

            Assert.AreEqual(1, school.Students.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RegisterStudentWithNullNameTest()
        {
            var school = new School();
            var studentIvan = school.RegisterStudent(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RegisterStudentWithEmptyNameTest()
        {
            var school = new School();
            var studentIvan = school.RegisterStudent("");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddNullStudentToCourseTest()
        {
            var school = new School();
            var csharpCourse = school.RegisterCourse("C# Part 2");

            school.AddStudentToCourse(null, csharpCourse);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddStudentToInvalidCourseTest()
        {
            var school = new School();
            var studentIvan = school.RegisterStudent("Ivan");

            var school2 = new School();
            var csharpCourse = school2.RegisterCourse("C# Part 2");

            school.AddStudentToCourse(studentIvan, csharpCourse);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddStudentMultipleTimeToCourseTest()
        {
            var school = new School();
            var studentIvan = school.RegisterStudent("Ivan");
            var csharpCourse = school.RegisterCourse("C# Part 2");

            school.AddStudentToCourse(studentIvan, csharpCourse);
            school.AddStudentToCourse(studentIvan, csharpCourse);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddMissingStudentToCourseTest()
        {
            var school = new School();
            var studentIvan = school.RegisterStudent("Ivan");

            var school2 = new School();
            var csharpCourse = school2.RegisterCourse("C# Part 2");

            school2.AddStudentToCourse(studentIvan, csharpCourse);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Add_100_000_StudentsToCourseTest()
        {
            var school = new School();
            var csharpCourse = school.RegisterCourse("C# Part 2");

            for (int i = 0; i < 100001; i++)
            {
                var studentIvan = school.RegisterStudent("Ivan");
                school.AddStudentToCourse(studentIvan, csharpCourse);

                if (csharpCourse.Students.Count == csharpCourse.StudentsCapacity - 1)
                {
                    csharpCourse = school.RegisterCourse(i.ToString()); // Random name
                }
            }
        }

        [TestMethod]
        public void RemoveStudentFromCourseTest()
        {
            var school = new School();
            var studentIvan = school.RegisterStudent("Ivan");
            var csharpCourse = school.RegisterCourse("C# Part 2");

            school.AddStudentToCourse(studentIvan, csharpCourse);
            school.RemoveStudentFromCourse(studentIvan, csharpCourse);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RemoveNullStudentFromCourseTest()
        {
            var school = new School();
            var csharpCourse = school.RegisterCourse("C# Part 2");

            school.RemoveStudentFromCourse(null, csharpCourse);
        }

        [TestMethod]
        public void CreateCourseTest()
        {
            var school = new School();
            var csharpCourse = school.RegisterCourse("C# Fundamentals");

            Assert.AreEqual(0, csharpCourse.Students.Count);
        }

        [TestMethod]
        public void CourseCountAfterCreateCourseTest()
        {
            var school = new School();
            var csharpCourse = school.RegisterCourse("C# Fundamentals");

            Assert.AreEqual(1, school.Courses.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RegisterCourseWithNullNameTest()
        {
            var school = new School();
            var nullNameCourse = school.RegisterCourse(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RegisterCourseWithEmptyNameTest()
        {
            var school = new School();
            var emptyNameCourse = school.RegisterCourse("");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RegisterDuplicateCourseTest()
        {
            var school = new School();
            var csharpCourse = school.RegisterCourse("C# Fundamentals");
            var csharpCourseDuplicate = school.RegisterCourse("C# Fundamentals");
        }

        [TestMethod]
        public void AddStudentToCourseTest()
        {
            var school = new School();
            var csharpCourse = school.RegisterCourse("C# Fundamentals");
            var studentIvan = school.RegisterStudent("Ivan");

            school.AddStudentToCourse(studentIvan, csharpCourse);

            Assert.AreEqual(1, csharpCourse.Students.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]        
        public void AddStudentToCourseUnderMaxCapacityTest()
        {
            var school = new School();
            var csharpCourse = school.RegisterCourse("C# Fundamentals");

            for (int i = 0; i < 31; i++)
            {
                var studentIvan = school.RegisterStudent(i.ToString());
                school.AddStudentToCourse(studentIvan, csharpCourse);
            }
        }
    }
}