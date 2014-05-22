namespace School
{
    using System;
    using System.Linq;

    public class Student
    {
        private string firstName;
        private string lastName;
        private DateTime birthDate;

        /// <summary>
        /// Create a student by given names and birthdate
        /// </summary>
        /// <param name="firstName">The first name of the student</param>
        /// <param name="lastName">The last name of the student</param>
        /// <param name="birthDate">The birthdate of the student</param>
        public Student(string firstName, string lastName, DateTime birthDate)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.BirthDate = birthDate;
        }

        /// <summary>
        /// First name of the student
        /// </summary>
        public string FirstName
        {
            get { return this.firstName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("First name cannot be empty.");
                }

                this.firstName = value;
            }
        }

        /// <summary>
        /// Last name of the student
        /// </summary>
        public string LastName
        {
            get { return this.lastName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Last name cannot be empty.");
                }

                this.lastName = value;
            }
        }

        /// <summary>
        /// Combination of the first and last name of the student
        /// </summary>
        public string FullName
        {
            get { return this.FirstName + " " + this.LastName; }
        }

        /// <summary>
        /// Full birthdate of the student
        /// </summary>
        public DateTime BirthDate
        {
            get { return this.birthDate; }
            set
            {
                DateTime beginningDateTime = new DateTime(1900, 1, 1);
                DateTime endDateTime = DateTime.Now;

                if (!(value >= beginningDateTime && value <= endDateTime))
                {
                    throw new ArgumentException(string.Format("Birthdate must be in the range [{0}; {1}]",
                        beginningDateTime.ToShortDateString(), endDateTime.ToShortDateString()));
                }
                
                this.birthDate = value;
            }
        }

        /// <summary>
        /// Return true if this student is older than given other student, otherwise return false
        /// </summary>
        /// <param name="other">The other student takes part of comparison</param>
        /// <returns>Boolean value as result of the comparison</returns>
        public bool IsOlderThan(Student other)
        {
            bool isThisStudentOlder = this.BirthDate.CompareTo(other.BirthDate) < 0;

            return isThisStudentOlder;
        }

        /// <summary>
        /// A text in appropriate form represents the information of the student
        /// </summary>
        /// <returns>A string represents the information about the student</returns>
        public override string ToString()
        {
            string output = string.Format("{0}: {1}, birthdate: {2}",
                this.GetType().Name, this.FullName, this.BirthDate.ToShortDateString());

            return output;
        }
    }
}