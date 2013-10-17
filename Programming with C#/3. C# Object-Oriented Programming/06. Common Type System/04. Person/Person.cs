using System;
using System.Linq;
using System.Text;

class Person
{
    private string name;

    public Person(string name, byte? age)
    {
        this.Name = name;
        this.Age = age;
    }

    public byte? Age { get; set; }

    public string Name
    {
        get { return this.name; }
        set
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException("Name cannot be null or empty!");
            
            this.name = value;
        }
    }

    public override string ToString()
    {
        StringBuilder info = new StringBuilder();

        info.AppendLine("Name: " + this.Name);

        info.AppendLine("Age: " + (this.Age.HasValue ? this.Age.ToString() : "not specified"));

        return info.ToString();
    }
}