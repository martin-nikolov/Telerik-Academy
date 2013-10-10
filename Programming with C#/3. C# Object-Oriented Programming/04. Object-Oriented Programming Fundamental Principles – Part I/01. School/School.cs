using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class School
{
    private readonly List<Class> classes = new List<Class>();

    private string name = string.Empty;

    public School(string name)
    {
        this.Name = name;
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
                throw new ArgumentException("The School name cannot be null or empty!");

            this.name = value;
        }
    }

    public School AddClass(params Class[] classes)
    {
        foreach (var _class in classes)
            this.classes.Add(_class);

        return this;
    }

    public School RemoveClass(Class _class)
    {
        this.classes.Remove(_class);

        return this;
    }

    public override string ToString()
    {
        StringBuilder info = new StringBuilder();

        info.Append(string.Format("School: \"{0}\"\n", this.Name));

        if (this.classes.Count > 0)
            info.Append(string.Join(Environment.NewLine, this.classes));
        else
            info.AppendLine("   - There are no classes in this school!");

        return info.ToString();
    }
}