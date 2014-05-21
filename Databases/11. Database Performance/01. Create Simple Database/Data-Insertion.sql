SET NOCOUNT ON
DECLARE @RowCount int = 10000000 

WHILE @RowCount > 0
BEGIN
    DECLARE @Message nvarchar(100);
    SET @Message = 'Message ' + CONVERT(nvarchar(100), @RowCount) + ': ' + CONVERT(nvarchar(100), newid())
    
    DECLARE @Date datetime;
    SET @Date = DATEADD(month, CONVERT(varbinary, newid()) % (50 * 12), getdate())

    INSERT INTO Logs([Message], PublishDate)
    VALUES(@Message, @Date)
    SET @RowCount = @RowCount - 1
END
SET NOCOUNT OFF