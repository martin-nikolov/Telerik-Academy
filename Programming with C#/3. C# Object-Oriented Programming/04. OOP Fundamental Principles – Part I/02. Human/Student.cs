using System;
using System.Linq;

class Student : Human
{
    private uint grade = 0;

    public Student(string firstName, string lastName, uint grade) : base(firstName, lastName)
    {
        this.Grade = grade;
    }

    public uint Grade
    {
        get
        {
            return this.grade;
        }
        set
        {
            if (value <= 0 || value > 12)
                throw new ArgumentException("Grade is not in range!");

            this.grade = value;
        }
    }

    public override string ToString()
    {
        return string.Format("Student: {0} {1}, Grade: {2}", this.FirstName, this.LastName, this.Grade);
    }
}