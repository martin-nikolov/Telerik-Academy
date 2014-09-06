USE [ToyStore]

SELECT t.Name, t.Price
FROM Toys t
WHERE t.Type = 'puzzle' AND t.Price > 10
ORDER BY t.Price