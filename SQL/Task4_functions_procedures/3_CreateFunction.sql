﻿CREATE FUNCTION fn_createID(@tableName VARCHAR(50), @ID VARCHAR(50))
RETURNS VARCHAR(50)
AS
BEGIN
RETURN @tableName + @ID
END