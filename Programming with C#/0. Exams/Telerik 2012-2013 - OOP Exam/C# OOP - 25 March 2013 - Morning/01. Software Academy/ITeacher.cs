namespace SoftwareAcademy
{
    using System;
    using System.Linq;

    public interface ITeacher
    {
        string Name { get; set; }

        void AddCourse(ICourse course);

        string ToString();
    }
}