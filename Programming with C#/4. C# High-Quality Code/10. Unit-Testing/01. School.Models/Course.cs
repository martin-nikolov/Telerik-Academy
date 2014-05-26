namespace School.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Course
    {
        public readonly int StudentsCapacity = 30;

        private readonly ISet<Student> students;
        private string name;

        public Course(string name)
        {
            this.Name = name;
            this.students = new HashSet<Student>();
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Course name cannot be null or empty.");                   
                }
                
                this.name = value;
            }
        }

        public ICollection<Student> Students
        {
            get { return this.students; }
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var other = obj as Course;

            if (other == null)
            {
                return false;
            }

            return Equals(this.Name, other.Name);
        }
    }
}