namespace StudentSystem.ConsoleClient
{
    using System;
    using System.Linq;
    using StudentSystem.Data;

    public class ConsoleClient
    {
        public static void Main()
        {
            // IMPORTANT: Change connection string in "StudentSystem.Data/ConnectionStrings.settings"

            Console.Write("Loading...");

            var forumSystemContext = new StudentSystemContext();
            forumSystemContext.Database.Initialize(true);

            PrintStudents(forumSystemContext);
            PrintCourses(forumSystemContext);
            PrintHomeworks(forumSystemContext);
        }
 
        private static void PrintStudents(StudentSystemContext forumSystemContext)
        {
            Console.WriteLine("\rStudents: ");
            foreach (var student in forumSystemContext.Students.Include("Courses"))
            {
                Console.WriteLine(" - {0} -> present in {1} course(s).", student.Name, student.Courses.Count());
            }
        }
 
        private static void PrintCourses(StudentSystemContext forumSystemContext)
        {
            Console.WriteLine("\nCourses: ");
            foreach (var course in forumSystemContext.Courses.Include("Homeworks"))
            {
                Console.WriteLine(" - {0} -> has {1} homework(s).", course.Description, course.Homeworks.Count());
            }
        }
 
        private static void PrintHomeworks(StudentSystemContext forumSystemContext)
        {
            Console.WriteLine("\nHomeworks: ");
            foreach (var homework in forumSystemContext.Homeworks.Include("Materials").Where(h => !h.StudentId.HasValue))
            {
                Console.WriteLine(" - {0} ({1}) -> has {2} material(s).",
                    homework.Content, homework.Course.Description, homework.Materials.Count());

                foreach (var material in homework.Materials)
                {
                    Console.WriteLine("    - {0} ({2}) - {1}", material.Type, material.DownloadUrl, material.Homework.Content);
                }

                Console.WriteLine();
            }
        }
    }
}