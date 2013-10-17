using System;
using System.Linq;
using System.Text;

abstract class Person
{
    private string firstName = string.Empty;
    private string middleName = string.Empty;
    private string lastName = string.Empty;

    private string socialSecurityNumber = string.Empty;

    public Person(string firstName, string middleName, string lastName, string ssn)
    {
        this.FirstName = firstName;
        this.MiddleName = middleName;
        this.LastName = lastName;

        this.SocialSecurityNumber = ssn;
    }

    public string FirstName
    {
        get { return this.firstName; }
        set
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException("First name cannot be null or empty");

            this.firstName = value;
        }
    }

    public string MiddleName
    {
        get { return this.middleName; }
        set
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException("Middle name cannot be null or empty");

            this.middleName = value;
        }
    }

    public string LastName
    {
        get { return this.lastName; }
        set
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException("Last name cannot be null or empty");

            this.lastName = value;
        }
    }

    public string SocialSecurityNumber
    {
        get { return this.socialSecurityNumber; }
        set
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException("Social Security Number cannot be null or empty!");

            this.socialSecurityNumber = value;
        }
    }

    public override string ToString()
    {
        StringBuilder info = new StringBuilder();

        info.AppendLine(string.Format("{0} {1} {2}", this.FirstName, this.MiddleName, this.LastName));
        info.Append("   Social security number: " + this.SocialSecurityNumber);

        return info.ToString();
    }
}