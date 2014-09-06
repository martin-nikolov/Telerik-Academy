USE [ToyStore]

SELECT t.Name, t.Price, t.Color
FROM Toys t
JOIN ToysCategories tc
    ON t.ToyId = tc.ToyId
JOIN Categories c
    ON c.CategoryId = tc.CategoryId
WHERE c.Name = 'boys'