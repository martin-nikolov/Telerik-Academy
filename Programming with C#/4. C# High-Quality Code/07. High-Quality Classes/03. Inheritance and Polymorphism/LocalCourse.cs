namespace InheritanceAndPolymorphism
{
    using System;
    using System.Text;
    using InheritanceAndPolymorphism.Interfaces;

    public class LocalCourse : Course, ILocalCourse
    {
        private string lab;

        public LocalCourse(string courseName, string teacherName, string labName)
            : base(courseName, teacherName)
        {
            this.Lab = labName;
        }

        public string Lab
        {
            get { return this.lab; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Lab name cannot be null or empty");
                }

                this.lab = value;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append(base.ToString());
            result.Length -= 2;

            if (this.Lab != null)
            {
                result.AppendFormat("; Lab = {0}", this.Lab);
            }

            result.Append(" }");

            return result.ToString();
        }
    }
}