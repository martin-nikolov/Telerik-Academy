using System;
using System.Linq;

class Worker : Human
{
    private double workSalary = 0;

    public Worker(string firstName, string lastName, double workSalary = 0, uint workHoursPerDay = 0) : base(firstName, lastName)
    {
        this.WorkSalary = workSalary;
        this.WorkHoursPerDay = workHoursPerDay;
    }

    public string Name { get; set; }

    public double WorkSalary
    {
        get
        {
            return this.workSalary;
        }
        set
        {
            if (value < 0)
                throw new ArgumentException("Work salary cannot be less than zero!");

            this.workSalary = value;
        }
    }

    public uint WorkHoursPerDay { get; set; }

    public double MoneyPerHour()
    {
        return this.WorkHoursPerDay != 0 ? Math.Round(this.WorkSalary / this.WorkHoursPerDay, 2) : 0;
    }

    public override string ToString()
    {
        return string.Format("Worker: {0} {1}, Salary: {2}, Hours per day: {3}, Money per hour: {4}",
            this.FirstName, this.LastName, this.WorkSalary, this.WorkHoursPerDay, this.MoneyPerHour());
    }
}