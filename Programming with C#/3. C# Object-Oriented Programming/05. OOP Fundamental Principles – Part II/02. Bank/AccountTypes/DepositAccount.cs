using System;
using System.Linq;

class DepositAccount : Account, IDeposit<DepositAccount>, IDraw<DepositAccount>
{
    public DepositAccount(CustomerType customerType, decimal balance, decimal interestRate) 
        : base(customerType, balance, interestRate)
    {
    }

    public DepositAccount Deposit(decimal money)
    {
        this.Balance += money;

        return this;
    }

    public DepositAccount WithDraw(decimal money)
    {
        if (this.Balance < money)
            throw new ArgumentException("Insufficient amount in the account!");

        this.Balance -= money;

        return this;
    }

    public override decimal CalculateInterestAmount(decimal numberOfMonths)
    {
        if (this.Balance <= 1000)
            return 0;

        return base.CalculateInterestAmount(numberOfMonths);
    }
}
