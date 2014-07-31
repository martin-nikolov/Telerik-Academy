namespace ChainOfResponsibility
{
    using System;

    internal class Program
    {
        internal static void Main()
        {
            Approver teamLead = new TeamLead();
            Approver vp = new VicePresident();
            Approver ceo = new President();

            teamLead.SetSuccessor(vp);
            vp.SetSuccessor(ceo);

            var purchase = new Purchase(2034, 350.00);
            teamLead.ProcessRequest(purchase);

            purchase = new Purchase(2035, 32590.10);
            teamLead.ProcessRequest(purchase);

            purchase = new Purchase(2036, 122100.00);
            teamLead.ProcessRequest(purchase);
        }
    }
}
