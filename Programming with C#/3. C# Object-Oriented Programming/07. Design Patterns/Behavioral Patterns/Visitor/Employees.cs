namespace Visitor
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The 'ObjectStructure' class
    /// </summary>
    internal class Employees
    {
        private readonly List<Employee> employees = new List<Employee>();

        public void Attach(Employee employee)
        {
            this.employees.Add(employee);
        }

        public void Detach(Employee employee)
        {
            this.employees.Remove(employee);
        }

        public void Accept(IVisitor visitor)
        {
            foreach (var employee in this.employees)
            {
                employee.Accept(visitor);
            }

            Console.WriteLine();
        }
    }
}
