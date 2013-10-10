using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Teacher : People, ICommentable, IEquatable<Teacher>, IComparable<Teacher>
{
    private readonly List<Discipline> disciplines = new List<Discipline>();

    public Teacher(string firstName, string middleName, string lastName) : base(firstName, middleName, lastName)
    {
    }

    public string Comment { get; set; }

    public int CompareTo(Teacher other)
    {
        return this.FirstName.CompareTo(other.FirstName);
    }

    public bool Equals(Teacher other)
    {
        return this.FirstName.Equals(other.FirstName) &&
               this.MiddleName.Equals(other.MiddleName) &&
               this.LastName.Equals(other.LastName);
    }

    public Teacher AddDiscipline(params Discipline[] discipline)
    {
        foreach (var item in discipline)
            this.disciplines.Add(item);

        return this;
    }

    public Teacher RemoveDiscipline(Discipline discipline)
    {
        this.disciplines.Remove(discipline);

        return this;
    }

    public override string ToString()
    {
        StringBuilder info = new StringBuilder();
         
        info.AppendLine(base.ToString());

        if (this.disciplines.Count > 0)
        {
            info.AppendLine("        Disciplines: ");

            foreach (var discipline in this.disciplines)
                info.AppendLine("         " + discipline);
        }

        return info.ToString();
    }
}