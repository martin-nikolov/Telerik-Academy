/*
* 2. A bank holds different types of accounts for its customers:
* deposit accounts, loan accounts and mortgage accounts. 
* Customers could be individuals or companies.
* All accounts have customer, balance and interest rate (monthly based).
* Deposit accounts are allowed to deposit and with draw money. Loan
* and mortgage accounts can only deposit money.
* All accounts can calculate their interest amount for a given period
* (in months). In the common case its is calculated as follows:
* number_of_months * interest_rate.
* 
* Loan accounts have no interest for the first 3 months if are held by
* individuals and for the first 2 months if are held by a company.
* Deposit accounts have no interest if their balance is positive and less than 1000.
* Mortgage accounts have ½ interest for the first 12 months for companies
* and no interest for the first 6 months for individuals.
* Your task is to write a program to model the bank system by classes and
* interfaces. You should identify the classes, interfaces, base classes
* and abstract actions and implement the calculation of the interest
* functionality through overridden methods.
*/

using System;
using System.Linq;

class Program
{
    static void Main()
    {
        var bank = new Bank("International Asset Bank");

        bank.AddAccount(
            new DepositAccount(CustomerType.Individual, 2330, 45).WithDraw(250.23m), // Test WithDraw()
            new LoanAccount(CustomerType.Company, 250, 25).Deposit(250.23m), // Test Deposit()
            new LoanAccount(CustomerType.Individual, 444, 44), // Remove
            new MortgageAccount(CustomerType.Company, 2300, 15));

        bank.RemoveAccount(new LoanAccount(CustomerType.Individual, 444, 44));

        Console.WriteLine(bank);

        /* ------------ */

        Console.WriteLine(new DepositAccount(CustomerType.Individual, 2330, 45).CalculateInterestAmount(20));

        Console.WriteLine(new LoanAccount(CustomerType.Company, 250, 25).Deposit(250.23m).CalculateInterestAmount(15));

        Console.WriteLine(new MortgageAccount(CustomerType.Company, 2300, 15).CalculateInterestAmount(45) + "\n\n");

        /* ------------ */

        Console.WriteLine(new DepositAccount(CustomerType.Individual, 2330, 45));
    }
}