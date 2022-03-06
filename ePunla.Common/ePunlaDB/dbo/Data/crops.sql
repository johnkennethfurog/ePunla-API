-- Write your own SQL object definition here, and it'll be included in your package.
DECLARE @crops TABLE
(
    [CropId]     INT,
    [CategoryId] INT,
    [Duration]   INT,
    [Name]       NVARCHAR (200),
    [Color]      NVARCHAR (20)
);

INSERT INTO @crops
SELECT 1, 1, 60, 'Kalabasa', '#ff7518'
UNION SELECT 2, 1, 60, 'Mais', '#fbec5d'
UNION SELECT 3, 1, 30, 'Sitaw', '#709048'
UNION SELECT 4, 1, 30, 'Okra', '#007002'
UNION SELECT 5, 1, 40, 'Ampalaya', '#cfd1b2'
UNION SELECT 6, 1, 60, 'Sili', '#E32227'
UNION SELECT 7, 1, 30, 'Kamatis', '#ff6347'
UNION SELECT 8, 1, 30, 'Kamote', '#e4622d'
UNION SELECT 9, 1, 30, 'Kangkong', '#7faa47'
UNION SELECT 10, 1, 40, 'Labanos', '#ecdee7'
UNION SELECT 11, 1, 60, 'Bataw', '#d3d79f'
UNION SELECT 12, 1, 60, 'Patani', '#c9cca5'
UNION SELECT 13, 1, 60, 'Patola', '#44b264'
UNION SELECT 14, 1, 60, 'Upo', '#b9cf5a'
UNION SELECT 15, 1, 40, 'Mustasa', '#9be690'
UNION SELECT 16, 1, 60, 'Sibuyas', '#5b8930'
UNION SELECT 17, 1, 60, 'Bawang ', '#f2e9d2'
UNION SELECT 18, 1, 30, 'Pechay', '#4d7c28'
UNION SELECT 19, 1, 30, 'Talong', '#483248'
UNION SELECT 20, 1, 40, 'Singkamas', '#FDAB6C'

UNION SELECT 21, 2, 120, 'Manga', '#F4BB44'
UNION SELECT 22, 2, 90, 'Pinya', '#e6ae25'
UNION SELECT 23, 2, 90, 'Saging', '#ffe135'
UNION SELECT 24, 2, 60, 'Kalamansi', '#dce250'
UNION SELECT 25, 2, 120, 'Santol', '#cb8827'
UNION SELECT 26, 2, 90, 'Papaya', '#E66A35'
UNION SELECT 27, 2, 90, 'Atis', '#ced27c'
UNION SELECT 28, 2, 120, 'Guayabano', '#cde469'

SET IDENTITY_INSERT [dbo].Crops ON

MERGE Crops as [TARGET]
USING @crops as [SOURCE]
ON ([SOURCE].CropId = [TARGET].CropId)
WHEN NOT MATCHED 
    THEN INSERT (CropId,CategoryId,Duration,Name,Color) 
    VALUES ([SOURCE].CropId,[SOURCE].CategoryId,[SOURCE].Duration,[SOURCE].Name,[SOURCE].Color )
WHEN MATCHED
    THEN UPDATE SET [TARGET].Name = [SOURCE].Name, [TARGET].Duration = [SOURCE].Duration, [TARGET].Color = [SOURCE].Color;

SET IDENTITY_INSERT [dbo].Crops OFF