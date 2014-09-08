USE master
GO

CREATE PROC usp_CreateCacheDatabase
AS
    CREATE DATABASE CacheDatabase
    GO

    USE CacheDatabase
    GO

    CREATE TABLE EmployeesProjectsCache
    (
        Employee NVARCHAR(100),
        Department NVARCHAR(100),
        ProjectName NVARCHAR(100),
        StartingDate DATE,
        EndingDate DATE,
        ReportsCount INT
    )
    GO
GO

USE master
GO

EXEC usp_CreateCacheDatabase;