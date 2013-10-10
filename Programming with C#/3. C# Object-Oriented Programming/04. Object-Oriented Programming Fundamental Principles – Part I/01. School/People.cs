using System;
using System.Linq;

public class People : IEquatable<People>
{
    private string firstName = string.Empty;
    private string middleName = string.Empty;
    private string lastName = string.Empty;

    public People(string firstName, string middleName, string lastName)
    {
        this.FirstName = firstName;
        this.MiddleName = middleName;
        this.LastName = lastName;
    }

    public string FirstName
    {
        get
        {
            return this.firstName;
        }
        set
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException("The First Name cannot be null or empty!");

            this.firstName = value;
        }
    }

    public string MiddleName
    {
        get
        {
            return this.middleName;
        }
        set
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException("The Middle Name cannot be null or empty!");

            this.middleName = value;
        }
    }

    public string LastName
    {
        get
        {
            return this.lastName;
        }
        set
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException("The Last Name cannot be null or empty!");

            this.lastName = value;
        }
    }

    public bool Equals(People other)
    {
        return this.FirstName.Equals(other.FirstName) &&
               this.MiddleName.Equals(other.MiddleName) &&
               this.LastName.Equals(other.LastName);
    }

    public override string ToString()
    {
        return string.Format("{0} {1} {2}", this.FirstName, this.MiddleName, this.LastName);
    }
}