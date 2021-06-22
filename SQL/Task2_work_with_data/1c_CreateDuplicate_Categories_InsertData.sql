CREATE TABLE [dbo].[Duplicate_Categories](
	[CategoryID] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,) 

INSERT INTO [dbo].[Duplicate_Categories]
SELECT *
FROM [dbo].[Categories];