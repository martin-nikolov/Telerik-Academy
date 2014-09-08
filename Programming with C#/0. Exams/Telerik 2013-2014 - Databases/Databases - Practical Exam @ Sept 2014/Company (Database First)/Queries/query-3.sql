USE [Company]

SELECT CONCAT(e.FirstName, ' ', e.LastName) as Employee, d.Name as Department, p.Name as ProjectName, ep.StartingDate, ep.EndingDate,
(SELECT COUNT(*)
FROM Reports p
WHERE p.Time BETWEEN ep.StartingDate AND ep.EndingDate AND p.EmployeeId = e.EmployeeId) as ReportsCount
FROM Employees e
JOIN Departments d 
    ON e.DepartmentId = d.DepartmentId
JOIN EmployeeProjects ep
    ON e.EmployeeId = ep.EmployeeId
JOIN Projects p
    ON ep.ProjectId = p.ProjectId
ORDER BY e.EmployeeId, p.ProjectId

-- Additionally get the number of all reports, which time of reporting is between the start and end date. 
-- Тъй като не е уточнено, вземам Reports по текущото Employee, ако се изисква да се взема всички Reports като цяло, вижте заявката по-долу:

USE [Company]

SELECT TOP 100 CONCAT(e.FirstName, ' ', e.LastName) as Employee, d.Name as Department, p.Name as ProjectName, ep.StartingDate, ep.EndingDate,
(SELECT COUNT(*)
FROM Reports p
WHERE p.Time BETWEEN ep.StartingDate AND ep.EndingDate) as ReportsCount
FROM Employees e
JOIN Departments d 
    ON e.DepartmentId = d.DepartmentId
JOIN EmployeeProjects ep
    ON e.EmployeeId = ep.EmployeeId
JOIN Projects p
    ON ep.ProjectId = p.ProjectId
ORDER BY e.EmployeeId, p.ProjectId