CREATE PROCEDURE [dbo].[sp_getCrops]
AS
BEGIN
  SELECT 
      C.CropId, [Crop]=C.Name,C.Duration,CAT.CategoryId,[Category] = CAT.Name
  FROM Crops C
  LEFT JOIN Categories CAT ON CAT.CategoryId = C.CategoryId
  ORDER BY C.Name 
END