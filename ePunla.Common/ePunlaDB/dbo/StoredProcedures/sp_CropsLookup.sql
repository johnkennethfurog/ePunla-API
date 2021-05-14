CREATE PROCEDURE [dbo].[sp_CropsLookup]
 @cropName NVARCHAR(20),
 @pageNUmber INT,
 @pageSize INT
AS
BEGIN
  SELECT 
    [id]=CropId,
    [value]=Name 
  FROM Crops C
  WHERE C.Name LIKE @cropName + '%' OR ISNULL(@cropName, '') = ''
  ORDER BY C.Name
  OFFSET (@pageNUmber-1)*@pageSize ROWS
  FETCH NEXT @pageSize ROWS ONLY
END
