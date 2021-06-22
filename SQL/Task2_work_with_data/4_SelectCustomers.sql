SELECT *
FROM [dbo].[Customers]
WHERE Region='SP'
UNION SELECT *
FROM [dbo].[Customers]
WHERE City='Campinas';