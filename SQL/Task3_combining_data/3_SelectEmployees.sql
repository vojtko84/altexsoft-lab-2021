SELECT E.FirstName, E.LastName, T.TerritoryDescription, R.RegionDescription
FROM [dbo].[Region] R
JOIN [dbo].[Territories] T
ON R.RegionID=T.RegionID
JOIN [dbo].[EmployeeTerritories] ET
ON ET.TerritoryID=T.TerritoryID
JOIN [dbo].[Employees] E
ON E.EmployeeID=ET.EmployeeID;