using System;
using System.Linq;
using System.Text;

class Student : Person, ICloneable, IComparable<Student>
{
    private string address = string.Empty;

    public Student(string firstName, string middleName, string lastName,
        string ssn, string address, string email = "", string mobilePhone = "",
        University university = University.None, Faculty faculty = Faculty.None, Specialty specialty = Specialty.None)
        : base(firstName, middleName, lastName, ssn)
    {
        this.Address = address;

        this.Email = email;
        this.MobilePhone = mobilePhone;

        this.University = university;
        this.Faculty = faculty;
        this.Specialty = specialty;
    }

    public string Address
    {
        get { return this.address; }
        set
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException("Address cannot be null or empty");

            this.address = value;
        }
    }

    public string Email { get; set; }

    public string MobilePhone { get; set; }

    public University University { get; set; }

    public Faculty Faculty { get; set; }

    public Specialty Specialty { get; set; }

    public int CompareTo(Student other)
    {
        if (this.Equals(other))
            return 0;

        var firstStudent = new Student[] { this, other }.OrderBy(student => student.FirstName)
                                                        .ThenBy(student => student.MiddleName)
                                                        .ThenBy(student => student.LastName)
                                                        .ThenBy(student => student.SocialSecurityNumber)
                                                        .First();

        return this.Equals(firstStudent) ? -1 : 1;
    }

    public object Clone()
    {
        return new Student(this.FirstName, this.MiddleName, this.LastName, this.SocialSecurityNumber,
            this.Address, this.Email, this.MobilePhone, this.University, this.Faculty, this.Specialty);
    }

    public override int GetHashCode()
    {
        return this.SocialSecurityNumber.GetHashCode();
    }

    public override bool Equals(object obj)
    {
        return this.SocialSecurityNumber.Equals((obj as Student).SocialSecurityNumber);
    }

    public static bool operator ==(Student student1, Student student2)
    {
        return student1.Equals(student2);
    }

    public static bool operator !=(Student student1, Student student2)
    {
        return !student1.Equals(student2);
    }

    public override string ToString()
    {
        StringBuilder info = new StringBuilder();

        info.AppendLine("Student: " + base.ToString());
        info.AppendLine("   Address: " + this.Address);

        if (!string.IsNullOrEmpty(this.Email))
            info.AppendLine("   Email: " + this.Email);

        if (!string.IsNullOrEmpty(this.MobilePhone))
            info.AppendLine("   Phone: " + this.MobilePhone);

        if (this.University != University.None)
            info.AppendLine("   University: " + this.University);

        if (this.Faculty != Faculty.None)
            info.AppendLine("   Faculty: " + this.Faculty);

        if (this.Specialty != Specialty.None)
            info.AppendLine("   Specialty: " + this.Specialty);

        return info.ToString();
    }
}