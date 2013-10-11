using System;
using System.Linq;
using System.Text;

abstract class Account : IEquatable<Account>
{
    private decimal balance = 0;
    private decimal interestRate = 0;

    public Account(CustomerType customerType, decimal balance, decimal interestRate)
    {
        this.CustomerType = customerType;
        this.Balance = balance;
        this.InterestRate = interestRate;
    }

    public decimal Balance
    {
        get
        {
            return this.balance;
        }
        protected set
        {
            if (value < 0)
                throw new ArgumentException("Balance cannot be less than zero!");

            this.balance = value;
        }
    }

    public decimal InterestRate
    {
        get
        {
            return this.interestRate;
        }
        protected set
        {
            if (value < 0)
                throw new ArgumentException("Interest rate cannot be less than zero!");

            this.interestRate = value;
        }
    }

    public CustomerType CustomerType { get; protected set; }

    public bool Equals(Account other)
    {
        return this.CustomerType == other.CustomerType &&
               this.Balance == other.Balance &&
               this.InterestRate == other.InterestRate;
    }

    public virtual decimal CalculateInterestAmount(decimal numberOfMonths)
    {
        if (numberOfMonths <= 0)
            return 0;

        return this.Balance * (this.InterestRate / 100) * numberOfMonths;
    }

    public override string ToString()
    {
        StringBuilder info = new StringBuilder();

        info.AppendLine("Customer type: " + this.CustomerType);
        info.AppendLine("Balance: " + this.Balance);
        info.AppendLine("Interest rate: " + this.InterestRate);

        return info.ToString();
    }
}