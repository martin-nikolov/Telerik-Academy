namespace ProxyPattern
{
    public class BankAccount : IBankAccount
    {
        public decimal Ballance { get; set; }

        public BankAccount()
        {
            this.Ballance = 2500;
        }

        public bool Deposit(decimal amount)
        {
            // Try to deposit
            // Do some validations
            Ballance += amount;

            // Deposit successful
            return true;
        }

        public bool Withdraw(decimal amount)
        {
            // Try to deposit
            // Do some validations
            // Do some more validations :)
            Ballance -= amount;

            // Deposit successful
            return true;
        }

        public decimal CurrentBallance()
        {
            // Do many validations

            return Ballance;
        }
    }
}