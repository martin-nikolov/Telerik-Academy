namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using InheritanceAndPolymorphism.Interfaces;

    public abstract class Course : ICourse
    {
        private string name;
        private string teacherName;
        private IList<string> students;

        public Course(string name, string teacherName)
        {
            this.Name = name;
            this.TeacherName = teacherName;
            this.students = new List<string>();
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Course name cannot be null or empty");
                }

                this.name = value;
            }
        }

        public string TeacherName
        {
            get { return this.teacherName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Teacher name cannot be null or empty");
                }

                this.teacherName = value;
            }
        }

        public IReadOnlyCollection<string> Students
        {
            get { return new ReadOnlyCollection<string>(this.students); }
        }

        public virtual void AddStudents(params string[] studentNames)
        {
            foreach (var studentName in studentNames)
            {
                if (string.IsNullOrEmpty(studentName))
                {
                    throw new ArgumentException("Student name cannot be null or empty");
                }

                this.students.Add(studentName);
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendFormat("{0} {{ Name = {1}", this.GetType().Name, this.Name);

            if (this.TeacherName != null)
            {
                result.AppendFormat("; Teacher = {0}", this.TeacherName);
            }

            result.AppendFormat("; Students = {0}", this.GetStudentsAsString());
            result.Append(" }");

            return result.ToString();
        }

        private string GetStudentsAsString()
        {
            if (this.Students == null || this.Students.Count == 0)
            {
                return "{ }";
            }
            else
            {
                return "{ " + string.Join(", ", this.Students) + " }";
            }
        }
    }
}