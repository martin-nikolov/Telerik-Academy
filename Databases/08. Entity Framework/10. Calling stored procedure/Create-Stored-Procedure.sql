USE Northwind;
GO

IF OBJECT_ID('dbo.usp_TotalIncomesOfSupplier', 'P') IS NOT NULL
    DROP PROC dbo.usp_TotalIncomesOfSupplier;
GO

CREATE PROC dbo.usp_TotalIncomesOfSupplier
    @supplierName nvarchar(MAX),
    @startDate DATETIME,
    @endDate DATETIME
AS
    SET NOCOUNT ON;
    SELECT SUM(od.UnitPrice) AS [Total Incomes]
    FROM Suppliers s 
    JOIN Products p
        ON p.SupplierID = s.SupplierID
    JOIN [Order Details] od
        ON od.ProductID = p.ProductID
    JOIN Orders o
        ON o.OrderID = od.OrderID
    WHERE s.CompanyName = @supplierName 
        AND o.OrderDate BETWEEN @startDate AND @endDate
RETURN
GO

--- TEST
DECLARE @startDate DATETIME = CAST('1/1/1996' AS DATETIME);
DECLARE @endDate DATETIME = CAST('12/31/1997' AS DATETIME);
DECLARE @result money;
EXEC usp_TotalIncomesOfSupplier 'Exotic Liquids', @startDate, @endDate
GO