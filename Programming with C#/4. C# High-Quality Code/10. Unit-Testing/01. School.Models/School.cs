namespace School.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class School
    {
        protected readonly ISet<Student> students;
        protected readonly ISet<Course> courses;

        private const int MinUniqueNumber = 10000;
        private const int MaxUniqueNumber = 99999;
        private int currentUniqueNumber = MinUniqueNumber;

        public School()
        {
            this.students = new HashSet<Student>();
            this.courses = new HashSet<Course>();
        }

        public ICollection<Student> Students
        {
            get { return this.students; }
        }

        public ICollection<Course> Courses
        {
            get { return this.courses; }
        }

        public Student RegisterStudent(string name)
        {
            var uniqueNumber = this.GetNextUniqueNumber();
            var student = new Student(name, uniqueNumber);
            this.students.Add(student);
            return student;
        }

        public Course RegisterCourse(string name)
        {
            var course = new Course(name);

            if (this.courses.Contains(course))
            {
                throw new ArgumentException("Course is already added in the school.");
            }

            this.courses.Add(course);
            return course;
        }

        public void AddStudentToCourse(Student student, Course course)
        {
            if (student == null)
            {
                throw new ArgumentNullException("Student cannot be null.");
            }

            if (!this.courses.Contains(course))
            {
                throw new ArgumentException("Course does not exists in this school.");
            }

            if (!this.students.Contains(student))
            {
                throw new ArgumentException("Student does not exists in this school.");
            }

            if (course.Students.Count >= course.StudentsCapacity)
            {
                throw new ArgumentException("Course capacity is filled.");
            }

            if (course.Students.Contains(student))
            {
                throw new ArgumentException(
                    string.Format("Student with number {0} already added in this course.", student.UniqueNumber));
            }

            course.Students.Add(student);
        }

        public void RemoveStudentFromCourse(Student student, Course course)
        {
            if (student == null)
            {
                throw new ArgumentNullException("Student cannot be null.");
            }

            course.Students.Remove(student);
        }

        private int GetNextUniqueNumber()
        {
            var uniqueNumber = this.currentUniqueNumber;

            if (uniqueNumber > MaxUniqueNumber)
            {
                throw new ArgumentOutOfRangeException("Unique number is out of range.");
            }

            this.currentUniqueNumber++;
            return uniqueNumber;
        }
    }
}