DECLARE @ID VARCHAR(50)

EXEC [dbo].[sp_createID] TestTable, @ID OUTPUT;

INSERT INTO [dbo].[TestTable]
VALUES (@ID, 'TEST1');