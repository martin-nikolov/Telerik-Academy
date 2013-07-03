/*
* 14. A bank account has a holder name (first name, middle name and last name), 
* available amount of money (balance), bank name, IBAN, BIC code and 3 credit 
* card numbers associated with the account. Declare the variables needed to keep
* the information for a single bank account using the appropriate data types and 
* descriptive names.
*/

using System;

internal class BankAccounts
{
    internal string holderFirstName;
    internal string holderMiddleName;
    internal string holderLastName;
    internal decimal holderBalance;
    internal string bankName;
    internal string iban;
    internal string bicCode;
    internal ulong[] creditCardNumbers = new ulong[3];
}

class BankAccountTest
{
    static void Main(string[] args)
    {
        uint numberOfHolders = 1;
        BankAccounts[] accounts = new BankAccounts[numberOfHolders];

        // Example
        accounts[0] = new BankAccounts();
        accounts[0].holderFirstName = "Georgi";
        accounts[0].holderMiddleName = "Vencislavov";
        accounts[0].holderLastName = "Yordanov";
        accounts[0].holderBalance = 15000.99M;
        accounts[0].bankName = "BNB";
        accounts[0].iban = "";
        accounts[0].bicCode = "";
        accounts[0].creditCardNumbers[0] = 123;
        accounts[0].creditCardNumbers[1] = 456;
        accounts[0].creditCardNumbers[2] = 789;

        PrintEmployees(accounts);
    }

    static void PrintEmployees(BankAccounts[] accounts)
    {
        Console.WriteLine("List of bank holders:\n ");

        for (int i = 0; i < accounts.Length; i++)
        {
            Console.WriteLine("Holder's name: {0} {1} {2}",
                accounts[i].holderFirstName, accounts[i].holderLastName, accounts[i].holderLastName);
            Console.WriteLine("Bank name: {0}", accounts[i].bankName);
            Console.WriteLine("Balance: {0:C}", accounts[i].holderBalance);
            Console.WriteLine("IBAN: {0}", (accounts[i].iban == "" ? "none" : accounts[i].iban));
            Console.WriteLine("BIC Code: {0}", (accounts[i].bicCode == "" ? "none" : accounts[i].bicCode));

            for (int j = 0; j < accounts[i].creditCardNumbers.Length; j++)
            {
                Console.WriteLine("- Credit card's number: {1}", j + 1, accounts[i].creditCardNumbers[j]);
            }

            Console.WriteLine();
        }
    }
}