CREATE PROCEDURE [dbo].[sp_getListOfClaims]
  @searchText NVARCHAR(200),
  @status NVARCHAR(50),
  @barangayId INT,
  @pageNumber INT,
  @pageSize INT
AS
BEGIN
  SELECT
      total_count = COUNT(*) OVER(),
      C.ClaimId,
      C.FilingDate,
      [Crop] = CR.Name,
      C.DamagedArea,
      C.[Status],
      C.[Description],
      C.PhotoUrl,
      C.Remarks,
      C.ValidationDate,
      C.ReferenceNumber,


      [Farm] = F.Name,
      F.Address,
      [Barangay] = B.Name,
      [Area] = BA.Name,
      FA.FirstName,
      FA.LastName,
      FA.MiddleName,
      FA.Avatar,
      FA.MobileNumber
  FROM Claims C
  LEFT JOIN Farms F ON F.FarmId = C.FarmId
  LEFT JOIN FarmCrops FC ON FC.FarmCropId = C.FarmCropId
  LEFT JOIN Crops CR ON CR.CropId = FC.CropId
  LEFT JOIN Farmers FA ON FA.FarmerId = F.FarmerId
  LEFT JOIN Barangays B ON B.BarangayId = F.BarangayId
  LEFT JOIN BarangayAreas BA ON BA.BarangayAreaId = F.BarangayAreaId
  WHERE
  (
      ISNULL(@status, '') = '' OR
      C.[Status] = @status
  ) AND
  (
      ISNULL(@searchText, '') = '' OR
      F.Name LIKE @searchText + '%' OR 
      F.Address LIKE @searchText + '%' OR 
      FA.FirstName LIKE  @searchText + '%' OR 
      FA.LastName LIKE  @searchText + '%'
  ) AND
  (
      ISNULL(@barangayId, 0) = 0 OR
      FA.BarangayId = @barangayId
  )
  ORDER BY C.FilingDate DESC
  OFFSET (@pageNUmber-1)*@pageSize ROWS
  FETCH NEXT @pageSize ROWS ONLY
END
