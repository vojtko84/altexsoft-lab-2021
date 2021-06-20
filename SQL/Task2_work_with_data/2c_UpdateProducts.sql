UPDATE [dbo].[Products]
SET Price = Price*1.2 
FROM [dbo].[Products] pr LEFT JOIN
[dbo].[Sellers] slr ON pr.SellerID=slr.SellerID
WHERE slr.Name = 'VSM';