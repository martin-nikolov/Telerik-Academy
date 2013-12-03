using System;
using System.Linq;

class LoanAccount : Account, IDeposit<LoanAccount>
{
    public LoanAccount(CustomerType customerType, decimal balance, decimal interestRate) 
        : base(customerType, balance, interestRate)
    {
    }

    public LoanAccount Deposit(decimal money)
    {
        this.Balance += money;

        return this;
    }

    public override decimal CalculateInterestAmount(decimal numberOfMonths)
    {
        if (this.CustomerType == CustomerType.Company)
            return base.CalculateInterestAmount(numberOfMonths - 2);

        if (this.CustomerType == CustomerType.Individual)
            return base.CalculateInterestAmount(numberOfMonths - 3);

        return base.CalculateInterestAmount(numberOfMonths);
    }
}
