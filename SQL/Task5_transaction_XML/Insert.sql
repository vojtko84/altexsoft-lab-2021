DECLARE @xmlDoc INT
DECLARE @request NVARCHAR(1000)
SET @request = '<Buyers><Buyer><BuyerID>5</BuyerID><FirstName>Igor</FirstName><LastName>Zolov</LastName><PhoneNumber>+380970000003</PhoneNumber></Buyer></Buyers>'

BEGIN TRANSACTION

BEGIN TRY
EXEC sp_XML_preparedocument @xmlDoc OUTPUT, @request
EXEC sp_mergeBuyerXML @request, @xmlDoc
EXEC sp_XML_removedocument @xmlDoc
COMMIT
END TRY

BEGIN CATCH
EXEC sp_XML_removedocument @xmlDoc
ROLLBACK
END CATCH

SELECT * FROM Buyers