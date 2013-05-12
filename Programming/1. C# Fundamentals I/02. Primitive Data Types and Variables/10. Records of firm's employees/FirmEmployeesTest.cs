/*
A marketing firm wants to keep record of its employees.
* Each record would have the following characteristics –
* first name, family name, age, gender (m or f), ID number, unique employee number (27560000 to 27569999).
* Declare the variables needed to keep the information for a single
* employee using appropriate data types and descriptive names.
*/

using System;

internal struct Employees
{
    internal string firstName;
    internal string secondName;
    internal byte age; // 0 to 255
    internal char gender; // 'm' or 'f'
    internal long IDNumber;
    internal uint UniqueEN; // 27560000 to 27569999
}

class FirmEmployeesTest
{
    static void Main(string[] args)
    {
        uint numberOfEmployees = 3;
        Employees[] employees = new Employees[numberOfEmployees];

        // Examples
        employees[0].firstName = "Petyr";
        employees[0].secondName = "Yordanov";
        employees[0].age = 33;
        employees[0].gender = 'm';
        employees[0].IDNumber = 1111111;
        employees[0].UniqueEN = 27560001;

        employees[1].firstName = "Pesho";
        employees[1].secondName = "Todorov";
        employees[1].age = 23;
        employees[1].gender = 'm';
        employees[1].IDNumber = 2222222;
        employees[1].UniqueEN = 27560002;

        employees[2].firstName = "Aleksandra";
        employees[2].secondName = "Ivanova";
        employees[2].age = 22;
        employees[2].gender = 'f';
        employees[2].IDNumber = 3333333;
        employees[2].UniqueEN = 27560003;

        PrintEmployees(employees);
    }

    static void PrintEmployees(Employees[] employees)
    {
        Console.WriteLine("List of employees:\n ");

        for (int i = 0; i < employees.Length; i++)
        {
            Console.WriteLine("Name: {0} {1}", employees[i].firstName, employees[i].secondName);
            Console.WriteLine("Age: {0}", employees[i].age);
            Console.WriteLine("Gender: {0}",
                (employees[i].gender == 'm' ? "Male" : (employees[i].gender == 'f' ? "Female" : "unknown")));
            Console.WriteLine("ID Number: {0}", employees[i].IDNumber);
            Console.WriteLine("Unique employee number: {0}", employees[i].UniqueEN);

            Console.WriteLine();
        }
    }
}