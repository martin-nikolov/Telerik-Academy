using System;
using System.Linq;
using System.Collections.Generic;

class Employees
{
    struct Employee
    {
        public string firstName;
        public string secondName;
        public int rate;

        public Employee(string firstName, string secondName, int rate)
        {
            this.firstName = firstName;
            this.secondName = secondName;
            this.rate = rate;
        }
    }

    static void Main()
    {
        int jobsCount = int.Parse(Console.ReadLine());
        Dictionary<string, int> jobs = new Dictionary<string, int>();

        for (int i = 0; i < jobsCount; i++)
        {
            string[] tokens = Console.ReadLine().Split(new string[] { " - " }, StringSplitOptions.RemoveEmptyEntries);
            string job = tokens[0].Trim();

            if (!jobs.ContainsKey(job)) jobs.Add(job, int.Parse(tokens[1]));
        }

        int employeesCount = int.Parse(Console.ReadLine());
        List<Employee> employees = new List<Employee>();

        for (int i = 0; i < employeesCount; i++)
        {
            string[] tokens = Console.ReadLine().Split(new string[] { " - " }, StringSplitOptions.RemoveEmptyEntries);
            string[] names = tokens[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            employees.Add(new Employee(names[0], names[1], jobs[tokens[1].Trim()]));
        }

        employees = employees.OrderByDescending(x => x.rate).ThenBy(x => x.secondName).ThenBy(x => x.firstName).ToList();

        foreach (var item in employees) Console.WriteLine("{0} {1}", item.firstName, item.secondName);
    }
}