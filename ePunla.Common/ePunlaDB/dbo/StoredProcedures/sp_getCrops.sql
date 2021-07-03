CREATE PROCEDURE [dbo].[sp_getCrops]
@searchText NVARCHAR(50),
@categoryId INT,
@showInactive BIT,
@pageNumber INT,
@pageSize INT
AS
BEGIN
  SELECT 
      total_count = COUNT(*) OVER(),
      C.CropId,
      [Crop]=C.Name,
      C.Duration,
      CAT.CategoryId,
      [Category] = CAT.Name,
      C.IsActive
  FROM Crops C
  LEFT JOIN Categories CAT ON CAT.CategoryId = C.CategoryId
  WHERE 
    (C.Name LIKE @searchText + '%' OR ISNULL(@searchText, '') = '')
    AND (ISNULL(@categoryID, 0) = 0 OR C.CategoryId = @categoryID)
    AND (@showInactive = 1 OR C.IsActive = 1)
  ORDER BY C.Name
  OFFSET (@pageNUmber-1) * @pageSize ROWS
  FETCH NEXT @pageSize ROWS ONLY
END