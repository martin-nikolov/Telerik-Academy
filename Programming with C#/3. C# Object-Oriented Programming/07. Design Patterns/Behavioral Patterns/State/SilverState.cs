namespace State
{
    /// <summary>
    /// A 'ConcreteState' class
    /// <remarks>
    /// Silver indicates a non-interest bearing state
    /// </remarks>
    /// </summary>
    internal class SilverState : State
    {
        public SilverState(State state) :
            this(state.Balance, state.Account)
        {
        }

        public SilverState(double balance, Account account)
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
            this.interest = 0.0;
            this.lowerLimit = 0.0;
            this.upperLimit = 1000.0;
        }

        private void StateChangeCheck()
        {
            if (this.Balance < this.lowerLimit)
            {
                this.Account.State = new RedState(this);
            }
            else if (this.Balance > this.upperLimit)
            {
                this.Account.State = new GoldState(this);
            }
        }
    }
}
