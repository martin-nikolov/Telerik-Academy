using System;

namespace ProxyPattern
{
    public class BankAccountProxy : IBankAccount
    {
        private BankAccount realAccount;

        private bool userIsAuthorized;

        public BankAccountProxy(string userName, string secretKey)
        {
            // Validate if the user is logged in, if he is legit, if he has rights to see this information and so on...
            if (true)
            {
                userIsAuthorized = true;
            }
        }

        public bool Deposit(decimal amount)
        {
            if (amount < 25)
            {
                Console.WriteLine("Minimum deposit amount is 25!");
                return false;
            }

            if (amount > 1000)
            {
                Console.WriteLine("Maximum deposit amount is 1000!");
                return false;
            }

            if (!userIsAuthorized)
            {
                Console.WriteLine("You are not authorized!");
                Console.WriteLine("Redirecting you to login screen...");
                return false;
            }

            CheckIfAccountIsActive();

            realAccount.Deposit(amount);

            return true;
        }

        public bool Withdraw(decimal amount)
        {
            // Do validations
            CheckIfAccountIsActive();

            realAccount.Withdraw(amount);
            return true;
        }

        public decimal CurrentBallance()
        {
            // Do validations
            CheckIfAccountIsActive();
            return realAccount.CurrentBallance();
        }

        private void CheckIfAccountIsActive()
        {
            if (realAccount == null)
            {
                realAccount = new BankAccount();
            }
        }
    }
}