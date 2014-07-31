namespace State
{
    /// <summary>
    /// The 'State' abstract class
    /// </summary>
    internal abstract class State
    {
        protected double interest;

        protected double lowerLimit;

        protected double upperLimit;

        public Account Account { get; set; }

        public double Balance { get; set; }

        public abstract void Deposit(double amount);

        public abstract void Withdraw(double amount);

        public abstract void PayInterest();
    }
}
