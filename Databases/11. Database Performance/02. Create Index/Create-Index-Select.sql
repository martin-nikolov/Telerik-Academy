CREATE INDEX IDX_Logs_PublishDate ON Logs(PublishDate)

CHECKPOINT; DBCC DROPCLEANBUFFERS; -- Empty the SQL Server cache

SELECT * FROM Logs
WHERE PublishDate > '31-Dec-1998' and PublishDate < '1-Jan-2012'

-- DROP INDEX IDX_Logs_PublishDate ON Logs