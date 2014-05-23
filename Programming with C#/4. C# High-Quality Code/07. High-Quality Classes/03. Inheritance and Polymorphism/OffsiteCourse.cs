namespace InheritanceAndPolymorphism
{
    using System;
    using System.Text;
    using InheritanceAndPolymorphism.Interfaces;

    public class OffsiteCourse : Course, IOffsiteCourse
    {
        private string town;

        public OffsiteCourse(string courseName, string teacherName, string townName)
            : base(courseName, teacherName)
        {
            this.Town = townName;
        }

        public string Town
        {
            get { return this.town; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Town name cannot be null or empty");
                }

                this.town = value;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append(base.ToString());
            result.Length -= 2;

            if (this.Town != null)
            {
                result.AppendFormat("; Town = {0}", this.Town);
            }

            result.Append(" }");

            return result.ToString();
        }
    }
}