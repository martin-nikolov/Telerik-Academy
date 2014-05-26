namespace School.Models
{
    using System;
    using System.Linq;

    public class Student
    {
        private string name;
        private int uniqueNumber;

        public Student(string name, int uniqueNumber)
        {
            this.Name = name;
            this.UniqueNumber = uniqueNumber;
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Student name cannot be null or empty.");
                }

                this.name = value;
            }
        }

        public int UniqueNumber
        {
            get { return this.uniqueNumber; }
            set { this.uniqueNumber = value; }
        }
   
        public override int GetHashCode()
        {
            unchecked
            {
                int result = 17;
                result = result * 23 + this.UniqueNumber.GetHashCode();
                return result;
            }
        }

        public override bool Equals(object obj)
        {
            Student other = obj as Student;

            if (other == null)
            {
                return false;
            }

            return Equals(this.UniqueNumber, other.UniqueNumber);
        }
    }
}