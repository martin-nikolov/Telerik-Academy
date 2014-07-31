namespace Visitor
{
    /// <summary>
    /// The 'ConcreteElement' class
    /// </summary>
    internal class Employee : Element
    {
        public Employee(string name, double income, int vacationDays)
        {
            this.Name = name;
            this.Income = income;
            this.VacationDays = vacationDays;
        }

        public string Name { get; set; }

        public double Income { get; set; }

        public int VacationDays { get; set; }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
