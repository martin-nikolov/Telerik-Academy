using System;

namespace ProxyPattern
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            IBankAccount account = new BankAccountProxy("az sum", "naistina");

            DisplayBallance(account);

            Deposit(25, account);

            Withdraw(250, account);

            Deposit(700, account);

            DisplayBallance(account);
        }

        private static void DisplayBallance(IBankAccount account)
        {
            Console.WriteLine("{0:C}", account.CurrentBallance());
        }

        private static void Withdraw(decimal amount, IBankAccount account)
        {
            if (account.Withdraw(amount))
            {
                Console.WriteLine("Withdrawal complete: {0:C}", amount);
            }
        }

        private static void Deposit(decimal amount, IBankAccount account)
        {
            if (account.Deposit(amount))
            {
                Console.WriteLine("Deposit complete: {0:C}", amount);
            }
        }
    }
}