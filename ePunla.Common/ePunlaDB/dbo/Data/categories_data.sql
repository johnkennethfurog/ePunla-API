-- This file contains SQL statements that will be executed after the build script.

-- Write your own SQL object definition here, and it'll be included in your package.
DECLARE @categories TABLE (
    [CategoryId] INT ,
    [Name]       NVARCHAR (MAX) NULL
);


INSERT INTO @categories
SELECT 1,'Gulay'
UNION SELECT 2, 'Prutas'

SET IDENTITY_INSERT [dbo].Categories ON

MERGE Categories as [TARGET]
USING @categories as [SOURCE]
ON ([SOURCE].CategoryId = [TARGET].CategoryId)
WHEN NOT MATCHED 
THEN INSERT (CategoryId,Name) VALUES ([SOURCE].CategoryId, [SOURCE].Name);

SET IDENTITY_INSERT [dbo].Categories OFF
