CHECKPOINT; DBCC DROPCLEANBUFFERS; -- Empty the SQL Server cache

SELECT * FROM Logs
WHERE PublishDate > '31-Dec-1998' and PublishDate < '1-Jan-2012'