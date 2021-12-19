-- Write your own SQL object definition here, and it'll be included in your package.
DECLARE @crops TABLE
(
    [CropId]     INT,
    [CategoryId] INT,
    [Duration]   INT,
    [Name]       NVARCHAR (200)
);

INSERT INTO @crops
SELECT 1, 1, 60, 'Kalabasa'
UNION SELECT 2, 1, 60, 'Mais'
UNION SELECT 3, 1, 30, 'Sitaw'
UNION SELECT 4, 1, 30, 'Okra'
UNION SELECT 5, 1, 40, 'Ampalaya'
UNION SELECT 6, 1, 60, 'Sili'
UNION SELECT 7, 1, 30, 'Kamatis'
UNION SELECT 8, 1, 30, 'Kamote'
UNION SELECT 9, 1, 30, 'Kangkong'
UNION SELECT 10, 1, 40, 'Labanos'
UNION SELECT 11, 1, 60, 'Bataw'
UNION SELECT 12, 1, 60, 'Patani'
UNION SELECT 13, 1, 60, 'Patola'
UNION SELECT 14, 1, 60, 'Upo'
UNION SELECT 15, 1, 40, 'Mustasa'
UNION SELECT 16, 1, 60, 'Sibuyas'
UNION SELECT 17, 1, 60, 'Bawang '
UNION SELECT 18, 1, 30, 'Pechay'
UNION SELECT 19, 1, 30, 'Talong'
UNION SELECT 20, 1, 40, 'Singkamas'

UNION SELECT 21, 2, 120, 'Manga'
UNION SELECT 22, 2, 90, 'Pinya'
UNION SELECT 23, 2, 90, 'Saging'
UNION SELECT 24, 2, 60, 'Kalamansi'
UNION SELECT 25, 2, 120, 'Santol'
UNION SELECT 26, 2, 90, 'Papaya'
UNION SELECT 27, 2, 90, 'Atis'
UNION SELECT 28, 2, 120, 'Guayabano'

SET IDENTITY_INSERT [dbo].Crops ON

MERGE Crops as [TARGET]
USING @crops as [SOURCE]
ON ([SOURCE].CropId = [TARGET].CropId)
WHEN NOT MATCHED 
    THEN INSERT (CropId,CategoryId,Duration,Name) 
    VALUES ([SOURCE].CropId,[SOURCE].CategoryId,[SOURCE].Duration,[SOURCE].Name);
-- WHEN MATCHED
--     THEN UPDATE SET [TARGET].Name = [SOURCE].Name, [TARGET].Duration = [SOURCE].Duration;

SET IDENTITY_INSERT [dbo].Crops OFF