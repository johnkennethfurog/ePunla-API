-- Write your own SQL object definition here, and it'll be included in your package.
DECLARE @barangayAreas TABLE
(
    [BarangayAreaId] INT,
    [BarangayId]     INT,
    [Name]           NVARCHAR (MAX),
    [IsActive]       BIT
);

INSERT INTO @barangayAreas
SELECT 1, 1,'Purok 1',1
UNION SELECT 2, 2,'Purok 1',1
UNION SELECT 3, 3,'Purok 1',1
UNION SELECT 4, 4,'Purok 1',1
UNION SELECT 5, 5,'Purok 1',1
UNION SELECT 6, 6,'Purok 1',1
UNION SELECT 7, 7,'Purok 1',1
UNION SELECT 8, 8,'Purok 1',1
UNION SELECT 9, 9,'Purok 1',1
UNION SELECT 10, 10,'Purok 1',1
UNION SELECT 11, 11,'Purok 1',1
UNION SELECT 12, 12,'Purok 1',1
UNION SELECT 13, 13,'Purok 1',1
UNION SELECT 14, 14,'Purok 1',1
UNION SELECT 15, 15,'Purok 1',1
UNION SELECT 16, 16,'Purok 1',1
UNION SELECT 17, 17,'Purok 1',1
UNION SELECT 18, 18,'Purok 1',1
UNION SELECT 19, 19,'Purok 1',1
UNION SELECT 20, 20,'Purok 1',1
UNION SELECT 21, 21,'Purok 1',1
UNION SELECT 22, 22,'Purok 1',1
UNION SELECT 23, 23,'Purok 1',1
UNION SELECT 24, 24,'Purok 1',1
UNION SELECT 25, 25,'Purok 1',1
UNION SELECT 26, 26,'Purok 1',1
UNION SELECT 27, 27,'Purok 1',1
UNION SELECT 28, 28,'Purok 1',1
UNION SELECT 29, 29,'Purok 1',1
UNION SELECT 30, 30,'Purok 1',1
UNION SELECT 31, 31,'Purok 1',1
UNION SELECT 32, 32,'Purok 1',1
UNION SELECT 33, 33,'Purok 1',1
UNION SELECT 34, 34,'Purok 1',1
UNION SELECT 35, 35,'Purok 1',1
UNION SELECT 36, 36,'Purok 1',1
UNION SELECT 37, 37,'Purok 1',1
UNION SELECT 38, 38,'Purok 1',1
UNION SELECT 39, 39,'Purok 1',1
UNION SELECT 40, 40,'Purok 1',1
UNION SELECT 41, 41,'Purok 1',1
UNION SELECT 42, 42,'Purok 1',1
UNION SELECT 43, 43,'Purok 1',1
UNION SELECT 44, 44,'Purok 1',1
UNION SELECT 45, 45,'Purok 1',1
UNION SELECT 46, 46,'Purok 1',1
UNION SELECT 47, 47,'Purok 1',1
UNION SELECT 48, 48,'Purok 1',1

SET IDENTITY_INSERT [dbo].BarangayAreas ON

MERGE BarangayAreas as [TARGET]
USING @barangayAreas as [SOURCE]
ON ([SOURCE].BarangayAreaId = [TARGET].BarangayAreaId)
WHEN NOT MATCHED 
    THEN INSERT (BarangayAreaId,BarangayId,Name,IsActive) 
    VALUES ([SOURCE].BarangayAreaId,[SOURCE].BarangayId,[SOURCE].Name,[SOURCE].IsActive)
WHEN MATCHED
    THEN UPDATE SET [TARGET].Name = [SOURCE].Name, [TARGET].IsActive = [SOURCE].IsActive,[TARGET].BarangayId = [SOURCE].BarangayId;


SET IDENTITY_INSERT [dbo].BarangayAreas OFF