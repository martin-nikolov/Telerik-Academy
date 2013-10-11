using System;
using System.Linq;

abstract class Animal : ISound
{
    private string name = string.Empty;
    private uint age = 0;
    private Sex sex;

    public Animal(string name, uint age, Sex sex)
    {
        this.Name = name;
        this.Age = age;
        this.Sex = sex;
    }

    public string Name
    {
        get
        {
            return this.name;
        }
        set
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException("Name cannot be null or empty!");

            this.name = value;
        }
    }

    public uint Age
    {
        get
        {
            return this.age;
        }
        set
        {
            if (this.age > 100)
                throw new ArgumentException("Age must be less than 100!");

            this.age = value;
        }
    }

    public Sex Sex
    {
        get
        {
            return this.sex;
        }
        set
        {
            this.sex = value;
        }
    }

    public abstract string Sound();

    public override string ToString()
    {
        return string.Format("{0}: {1}, Age: {2}, Sex: {3}", this.GetType().Name, this.Name, this.Age, this.Sex);
    }
}