## Transact SQL (T-SQL)

1. Create a database with two tables: `Persons(Id(PK), FirstName, LastName, SSN)` and `Accounts(Id(PK), PersonId(FK), Balance)`. Insert few records for testing. Write a stored procedure that selects the full names of all persons.
* Create a stored procedure that accepts a number as a parameter and returns all persons who have more money in their accounts than the supplied number.
* Create a function that accepts as parameters – sum, yearly interest rate and number of months. It should calculate and return the new sum. Write a `SELECT` to test whether the function works as expected.
* Create a stored procedure that uses the function from the previous example to give an interest to a person's account for one month. It should take the `AccountId` and the interest rate as parameters.
* Add two more stored procedures `WithdrawMoney(AccountId, money)` and `DepositMoney(AccountId, money)` that operate in transactions.
* Create another table – `Logs(LogID, AccountID, OldSum, NewSum)`. Add a trigger to the `Accounts` table that enters a new entry into the `Logs` table every time the sum on an account changes.
* Define a function in the database `TelerikAcademy` that returns all Employee's names (first or middle or last name) and all town's names that are comprised of given set of letters. Example `'oistmiahf'` will return `'Sofia'`, `'Smith'`, … but not `'Rob'` and `'Guy'`.
* Using database cursor write a T-SQL script that scans all employees and their addresses and prints all pairs of employees that live in the same town.
* *Write a T-SQL script that shows for each town a list of all employees that live in it. Sample output:

    ```sql
    Sofia -> Svetlin Nakov, Martin Kulov, George Denchev
    Ottawa -> Jose Saraiva
    ...
    ```
* Define a .NET aggregate function `StrConcat` that takes as input a sequence of strings and return a single string that consists of the input strings separated by ','. For example the following SQL statement should return a single string: 

    ```sql
    SELECT StrConcat(FirstName + ' ' + LastName) 
    FROM Employees
    ```
