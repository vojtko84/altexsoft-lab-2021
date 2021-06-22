SELECT FirstName, LastName, Region,City FROM [dbo].[Employees]
WHERE Region='WA'
EXCEPT
SELECT FirstName, LastName, Region,City FROM [dbo].[Employees]
WHERE City='Seattle';