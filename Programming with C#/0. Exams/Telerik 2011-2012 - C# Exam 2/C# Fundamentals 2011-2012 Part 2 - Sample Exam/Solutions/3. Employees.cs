using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

class Employees
{
    static Employee[] employees;
    static Dictionary<string, int> positions;

    public struct Employee
    {
        public string FirstName;
        public string SecondName;
        public string JobName;
        public int Priority;
    };

    static void Main()
    {
        PositionsInitialization();

        EmployeesInitialization();

        SortEmployees();

        PrintEmployees();
    }

    static void PositionsInitialization()
    {
        int n = int.Parse(Console.ReadLine());
        positions = new Dictionary<string, int>();

        for (int i = 0; i < n; i++)
        {
            string[] jobsInfo = Console.ReadLine().Split(new string[] { " - " }, StringSplitOptions.RemoveEmptyEntries);

            jobsInfo[0] = Regex.Replace(jobsInfo[0], @"\s+", " ");

            while (jobsInfo[0].StartsWith(" ")) jobsInfo[0] = jobsInfo[0].Remove(0, 1);
            while (jobsInfo[0].EndsWith(" ")) jobsInfo[0] = jobsInfo[0].Remove(jobsInfo[0].Length - 1);

            if (!positions.ContainsKey(jobsInfo[0]))
                positions.Add(jobsInfo[0], int.Parse(jobsInfo[1]));
        }
    }

    static void EmployeesInitialization()
    {
        int m = int.Parse(Console.ReadLine());
        employees = new Employee[m];

        for (int i = 0; i < m; i++)
        {
            string[] lineReader = Console.ReadLine().Split(new char[] { ' ', '-' }, StringSplitOptions.RemoveEmptyEntries);

            employees[i].FirstName = lineReader[0];
            employees[i].SecondName = lineReader[1];
            employees[i].JobName = lineReader[2];

            for (int j = 3; j < lineReader.Length; j++)
                employees[i].JobName += " " + lineReader[j];

            employees[i].Priority = positions[employees[i].JobName];
        }
    }

    static void SortEmployees()
    {
        for (int i = 0; i < employees.GetLength(0) - 1; i++)
        {
            for (int j = i + 1; j < employees.GetLength(0); j++)
            {
                if (employees[i].Priority < employees[j].Priority)
                {
                    Swap(i, j);
                }
                else if (employees[i].Priority == employees[j].Priority)
                {
                    if (employees[i].SecondName.CompareTo(employees[j].SecondName) == 1 ||
                        (employees[i].SecondName.CompareTo(employees[j].SecondName) == 0 &&
                        employees[i].FirstName.CompareTo(employees[j].FirstName) == 1))
                    {
                        Swap(i, j);
                    }
                }
            }
        }
    }

    static void Swap(int i, int j)
    {
        var swap = employees[i];
        employees[i] = employees[j];
        employees[j] = swap;
    }

    static void PrintEmployees()
    {
        for (int i = 0; i < employees.GetLength(0); i++)
            Console.WriteLine("{0} {1}", employees[i].FirstName, employees[i].SecondName);
    }
}