using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Class : ICommentable, IEquatable<Class>
{
    private readonly SortedSet<Teacher> teachers = new SortedSet<Teacher>();
    private readonly SortedSet<Student> students = new SortedSet<Student>();

    public Class(string name)
    {
        this.Name = name;
    }

    public string Name { get; set; }

    public string Comment { get; set; }

    public bool Equals(Class other)
    {
        return this.Name.Equals(other.Name);
    }

    public Class AddTeacher(params Teacher[] teachers)
    {
        foreach (var item in teachers)
            this.teachers.Add(item);

        return this;
    }

    public Class RemoveTeacher(Teacher teacher)
    {
        this.teachers.Remove(teacher);

        return this;
    }

    public Class AddStudent(params Student[] students)
    {
        foreach (var item in students)
            this.students.Add(item);

        return this;
    }

    public Class RemoveStudent(Student student)
    {
        this.students.Remove(student);

        return this;
    }

    public override string ToString()
    {
        StringBuilder info = new StringBuilder();

        info.AppendLine(string.Format("\n  Class \"{0}\":", this.Name));

        if (this.teachers.Count > 0)
        {
            info.AppendLine("    Teachers: ");

            foreach (var teacher in this.teachers)
                info.AppendLine("      " + teacher);
        }

        if (this.students.Count > 0)
        {
            info.AppendLine("    Students: ");

            foreach (var student in this.students)
                info.AppendLine("       - " + student);
        }

        return info.ToString();
    }
}