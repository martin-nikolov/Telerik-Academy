namespace State
{
    using System;

    internal class Program
    {
        internal static void Main()
        {
            var account = new Account("Jim Johnson");

            account.Deposit(500.0);
            account.Deposit(300.0);
            account.Deposit(550.0);
            account.PayInterest();
            account.Withdraw(2000.00);
            account.Withdraw(1100.00);
        }
    }
}
