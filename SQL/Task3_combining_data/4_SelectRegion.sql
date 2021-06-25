--INSERT INTO [dbo].[Region]
--VALUES (5, 'Northwestern');

SELECT R.*
FROM [dbo].[Region] R
LEFT OUTER JOIN [dbo].[Territories] T
ON R.RegionID=T.RegionID
LEFT OUTER JOIN [dbo].[EmployeeTerritories] ET
ON T.TerritoryID=ET.TerritoryID
GROUP BY R.RegionID, R.RegionDescription
HAVING COUNT(ET.EmployeeID)=0
