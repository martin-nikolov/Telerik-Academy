USE [Company]

SELECT CONCAT(e.FirstName, ' ', e.LastName), e.YearSalary
FROM Employees e
WHERE e.YearSalary BETWEEN 100000 AND 150000
ORDER BY e.YearSalary ASC