## Transactions in ADO.NET and Entity Framework

1. Suppose you are creating a simple engine for an ATM machine. Create a new database "ATM" in SQL Server to hold the accounts of the card holders and the balance (money) for each account. Add a new table `CardAccounts` with the following fields: 
    `Id (int)
    CardNumber (char(10))
    CardPIN (char(4))
    CardCash (money)`
    * Add a few sample records in the table.
2. Using transactions write a method which retrieves some money (for example $200) from certain account. The retrieval is successful when the following sequence of sub-operations is completed successfully:
    * A query checks if the given `CardPIN` and `CardNumber` are valid.
    * The amount on the account `(CardCash)` is evaluated to see whether it is bigger than the requested sum (more than $200).
    * The ATM machine pays the required sum (e.g. $200) and stores in the table `CardAccounts` the new amount `(CardCash = CardCash - 200)`.
        * Why does the isolation level need to be set to “repeatable read”?
3. Extend the project from the previous exercise and add a new table TransactionsHistory with fields (Id, CardNumber, TransactionDate, Ammount) containing information about all money retrievals on all accounts.
    * Modify the program logic so that it saves historical information (logs) in the new table after each successful money withdrawal.
        * What should the isolation level be for the transaction?
4. * Write unite tests for all your transactional logic. Ensure you test all border cases.
