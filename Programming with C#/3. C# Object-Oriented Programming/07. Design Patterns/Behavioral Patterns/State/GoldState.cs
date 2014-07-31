namespace State
{
    /// <summary>
    /// A 'ConcreteState' class
    /// <remarks>
    /// Gold indicates an interest bearing state
    /// </remarks>
    /// </summary>
    internal class GoldState : State
    {
        public GoldState(State state)
            : this(state.Balance, state.Account)
        {
        }

        public GoldState(double balance, Account account)
        {
            this.Balance = balance;
            this.Account = account;
            this.Initialize();
        }

        public override void Deposit(double amount)
        {
            this.Balance += amount;
            this.StateChangeCheck();
        }

        public override void Withdraw(double amount)
        {
            this.Balance -= amount;
            this.StateChangeCheck();
        }

        public override void PayInterest()
        {
            this.Balance += this.interest * this.Balance;
            this.StateChangeCheck();
        }

        private void Initialize()
        {
            this.interest = 0.05;
            this.lowerLimit = 1000.0;
            this.upperLimit = 10000000.0;
        }

        private void StateChangeCheck()
        {
            if (this.Balance < 0.0)
            {
                Account.State = new RedState(this);
            }
            else if (this.Balance < this.lowerLimit)
            {
                Account.State = new SilverState(this);
            }
        }
    }
}
