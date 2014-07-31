namespace ChainOfResponsibility
{
    using System;

    /// <summary>
    /// The 'ConcreteHandler' class
    /// </summary>
    internal class TeamLead : Approver
    {
        public override void ProcessRequest(Purchase purchase)
        {
            if (purchase.Amount < 10000.0)
            {
                Console.WriteLine(
                    "{0} approved request #{1}",
                    this.GetType().Name,
                    purchase.Number);
            }
            else if (this.Successor != null)
            {
                this.Successor.ProcessRequest(purchase);
            }
        }
    }
}
