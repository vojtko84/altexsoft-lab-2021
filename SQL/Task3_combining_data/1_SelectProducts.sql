SELECT *
FROM [dbo].[Products]
WHERE UnitPrice > (SELECT AVG(UnitPrice) FROM [dbo].[Products]);