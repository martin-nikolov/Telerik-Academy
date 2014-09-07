USE [ToyStore]

SELECT m.Name, 
(SELECT COUNT(*)
FROM Toys t
JOIN AgeRanges ar
    ON ar.AgeRangeId = t.AgeRangeId
WHERE ar.MinAge >= 5 AND ar.MaxAge <= 10 AND t.ManufacturerId = m.ManufacturerId) as ToysCount
FROM Manufacturers m
ORDER BY m.Name
