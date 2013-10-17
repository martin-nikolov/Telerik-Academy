/*
* 1. Define a class Student, which contains data about a student
* – first, middle and last name, SSN, permanent address, mobile
* phone e-mail, course, specialty, university, faculty. 
* 
* Use an enumeration for the specialties, universities and faculties.
* 
* Override the standard methods, inherited by  System.Object:
* Equals(), ToString(), GetHashCode() and operators == and !=.
* 
* 2. Add implementations of the ICloneable interface. The Clone() 
* method should deeply copy all object's fields into a new object
* of type Student.
*
* 3. Implement the  IComparable<Student> interface to compare students 
* by names (as first criteria, in lexicographic order) and by social
* security number (as second criteria, in increasing order).
*/

using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        var student1 = new Student("Antoan", "Borisov", "Cvetanov", "111", "Sofia");

        Console.WriteLine(student1);

        var student2 = new Student("Antoan", "Borisov", "Cvetanov", "222", "Varna");

        Console.WriteLine(student2);

        /* -------------- */

        Console.WriteLine(new string('-', 40));
        Console.WriteLine("Student1.Equals(Student2): {0}", student1.Equals(student2));
        Console.WriteLine("Student1 == Student2: {0}", student1 == student2);
        Console.WriteLine("Student1 != Student2: {0}\n\n", student1 != student2);

        /* -------------- */

        Console.WriteLine("student1.GetHashCode(): {0}", student1.GetHashCode());
        Console.WriteLine("student2.GetHashCode(): {0}\n\n", student2.GetHashCode());

        /* -------------- */

        var cloneStudent = student1.Clone();
        Console.Write("Clone student1 as result: \n{0}", cloneStudent);
        Console.WriteLine(new string('-', 40) + "\n");

        /* -------------- */

        var sortedStudents = new SortedSet<Student>()
        {
            new Student("A", "A", "A", "3", "Sofia"),
            new Student("B", "B", "B", "5", "Sofia"),
            new Student("B", "B", "B", "4", "Sofia"),
            new Student("B", "A", "B", "2", "Sofia"),
            new Student("C", "C", "C", "1", "Sofia"),
        };

        Console.WriteLine(string.Join("\n", sortedStudents));
    }
}