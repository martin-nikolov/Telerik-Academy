USE master
GO

CREATE PROC usp_DeleteCacheDatabase
AS
    DROP DATABASE CacheDatabase
    GO
GO

USE master
GO

EXEC usp_DeleteCacheDatabase;