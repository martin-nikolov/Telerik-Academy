namespace State
{
    using System;

    /// <summary>
    /// A 'ConcreteState' class
    /// <remarks>
    /// Red indicates that account is overdrawn 
    /// </remarks>
    /// </summary>
    internal class RedState : State
    {
        public RedState(State state)
        {
            this.Balance = state.Balance;
            this.Account = state.Account;
            this.Initialize();
        }

        public override void Deposit(double amount)
        {
            this.Balance += amount;
            this.StateChangeCheck();
        }

        public override void Withdraw(double amount)
        {
            Console.WriteLine("No funds available for withdrawal!");
        }

        public override void PayInterest()
        {
            // No interest is paid
        }

        private void Initialize()
        {
            this.interest = 0.0;
            this.lowerLimit = -100.0;
            this.upperLimit = 0.0;
        }

        private void StateChangeCheck()
        {
            if (this.Balance > this.upperLimit)
            {
                Account.State = new SilverState(this);
            }
        }
    }
}
