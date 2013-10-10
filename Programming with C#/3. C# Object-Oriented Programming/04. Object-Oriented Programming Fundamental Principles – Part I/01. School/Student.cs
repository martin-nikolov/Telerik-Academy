using System;
using System.Linq;

public class Student : People, ICommentable, IEquatable<Student>, IComparable<Student>
{
    public Student(string firstName, string middleName, string lastName, uint classNumber) : base(firstName, middleName, lastName)
    {
        this.ClassNumber = classNumber;
    }

    public uint ClassNumber { get; set; }

    public string Comment { get; set; }

    public int CompareTo(Student other)
    {
        return this.ClassNumber.CompareTo(other.ClassNumber);
    }

    public bool Equals(Student other)
    {
        return this.FirstName.Equals(other.FirstName) &&
               this.MiddleName.Equals(other.MiddleName) &&
               this.LastName.Equals(other.LastName);
    }

    public override string ToString()
    {
        return string.Format("{0} {1} {2} N.{3}", this.FirstName, this.MiddleName, this.LastName, this.ClassNumber);
    }
}