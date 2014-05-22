namespace School
{
    using System;
    using System.Linq;

    internal class StudentTest
    {
        static void Main()
        {
            var firstStudent = new Student("John", "Snow", new DateTime(1988, 12, 28));
            Console.WriteLine(firstStudent);

            var secondStudent = new Student("Bay", "Ivan", new DateTime(1970, 1, 1));
            Console.WriteLine(secondStudent);

            bool isSecondOlder = secondStudent.IsOlderThan(firstStudent);
            Console.WriteLine("\n{0} is older than {1}: {2}\n", secondStudent.FullName, firstStudent.FullName, isSecondOlder);

            try
            {
                var invalidStudentFirstName = new Student("", "invalid", DateTime.Now);
                // var invalidStudentLastName = new Student("invalid", "", DateTime.Now);
                // var invalidStudentBirthDate = new Student("invalid", "invalid", DateTime.Now.AddYears(5));
            }
            catch (Exception e)
            {
                Console.WriteLine(" - Error: " + e.Message);
            }
        }
    }
}