SELECT Country, Region, COUNT(*) AS SuppliersCount
FROM [dbo].[Suppliers]
WHERE Region IS NOT NULL
GROUP BY Country, Region
HAVING COUNT(*)>1;