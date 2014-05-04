## Structured Query Language (SQL)

1. What is SQL? What is DML? What is DDL? Recite the most important SQL commands.
* What is Transact-SQL (T-SQL)?
* Start SQL Management Studio and connect to the database TelerikAcademy. Examine the major tables in the "TelerikAcademy" database.
* Write a SQL query to find all information about all departments (use "TelerikAcademy" database).
* Write a SQL query to find all department names.
* Write a SQL query to find the salary of each employee.
* Write a SQL to find the full name of each employee.
* Write a SQL query to find the email addresses of each employee (by his first and last name). Consider that the mail domain is telerik.com. Emails should look like “John.Doe@telerik.com". The produced column should be named "Full Email Addresses".
* Write a SQL query to find all different employee salaries.
* Write a SQL query to find all information about the employees whose job title is “Sales Representative“.
* Write a SQL query to find the names of all employees whose first name starts with "SA".
* Write a SQL query to find the names of all employees whose last name contains "ei".
* Write a SQL query to find the salary of all employees whose salary is in the range [20000…30000].
* Write a SQL query to find the names of all employees whose salary is 25000, 14000, 12500 or 23600.
* Write a SQL query to find all employees that do not have manager.
* Write a SQL query to find all employees that have salary more than 50000. Order them in decreasing order by salary.
* Write a SQL query to find the top 5 best paid employees.
* Write a SQL query to find all employees along with their address. Use inner join with `ON` clause.
* Write a SQL query to find all employees and their address. Use equijoins (conditions in the `WHERE` clause).
* Write a SQL query to find all employees along with their manager.
* Write a SQL query to find all employees, along with their manager and their address. Join the 3 tables: `Employees` e, `Employees` m and `Addresses` a.
* Write a SQL query to find all departments and all town names as a single list. Use `UNION`.
* Write a SQL query to find all the employees and the manager for each of them along with the employees that do not have manager. Use right outer join. Rewrite the query to use left outer join.
* Write a SQL query to find the names of all employees from the departments "Sales" and "Finance" whose hire year is between 1995 and 2005.