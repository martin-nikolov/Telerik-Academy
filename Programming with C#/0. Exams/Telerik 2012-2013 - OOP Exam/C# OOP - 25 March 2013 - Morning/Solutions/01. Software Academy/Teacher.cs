namespace SoftwareAcademy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    class Teacher : ITeacher
    {
        private string name;

        public Teacher(string name)
        {
            this.Name = name;
            this.Courses = new List<ICourse>();
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Name");

                this.name = value;
            }
        }

        public IList<ICourse> Courses { get; private set; }

        public void AddCourse(ICourse course)
        {
            this.Courses.Add(course);
        }

        public override string ToString()
        {
            var output = new StringBuilder();
            output.AppendFormat("{0}: Name={1}", this.GetType().Name, this.Name);

            if (this.Courses.Count > 0)
            {
                output.AppendFormat("; Courses=[{0}]", string.Join(", ", this.Courses.Select(i => i.Name)));
            }

            return output.ToString();
        }
    }
}