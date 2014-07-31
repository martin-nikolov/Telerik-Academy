namespace Visitor
{
    using System;

    /// <summary>
    /// A 'ConcreteVisitor' class
    /// </summary>
    internal class IncomeVisitor : IVisitor
    {
        public void Visit(Element element)
        {
            var employee = element as Employee;

            if (employee != null)
            {
                // Provide 10% pay raise
                employee.Income *= 1.10;
                Console.WriteLine(
                    "{0} {1}'s new income: {2:C}", employee.GetType().Name, employee.Name, employee.Income);
            }
        }
    }
}
