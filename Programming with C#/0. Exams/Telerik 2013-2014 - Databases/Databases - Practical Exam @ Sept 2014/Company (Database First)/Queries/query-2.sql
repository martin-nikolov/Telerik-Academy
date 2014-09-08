USE [Company]

SELECT d.Name, 
(SELECT COUNT(e.EmployeeId)
FROM Employees e
WHERE e.DepartmentId = d.DepartmentId) AS EmployeesCount
FROM Departments d
ORDER BY EmployeesCount DESC