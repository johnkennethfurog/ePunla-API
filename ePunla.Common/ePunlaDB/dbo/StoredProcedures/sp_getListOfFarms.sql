CREATE PROCEDURE [dbo].[sp_getListOfFarms]
  @searchText NVARCHAR(200),
  @status NVARCHAR(50),
  @barangayId INT,
  @pageNumber INT,
  @pageSize INT
AS
BEGIN
  ;WITH farmers_cte as (
      SELECT
          F.FarmerId,
          [Farmer] = F.LastName + ', ' + F.FirstName + ' ' + ISNULL(F.MiddleName,''),
          F.MobileNumber,
          F.Avatar,
          F.IdentityDocumentUrl,
          F.IdentityDocumentId,
          [FarmerStatus] = F.[Status],
          [FarmerBarangay] = B.Name,
          [FarmerArea] = BA.Name,
          [FarmerAddress] = F.StreetAddress
      FROM Farmers F
      LEFT JOIN Barangays B ON B.BarangayId = F.BarangayId
      LEFT JOIN BarangayAreas BA ON BA.BarangayAreaId = F.BarangayAreaId
  )

  SELECT
        total_count = COUNT(*) OVER(),
      FA.FarmId,
      [Farm] = FA.Name,
      [Barangay] = B.Name,
      [Area] = BA.Name,
      FA.Address,
      FA.[Status],
      FA.AreaSize,
      [ImageUrl] = FA.[ImageUrl],
      [ImageUrlId] = FA.[ImageUrlId],
      F.*
  FROM Farms FA
  LEFT JOIN farmers_cte F ON F.FarmerId = FA.FarmerId
  LEFT JOIN Barangays B ON B.BarangayId = FA.BarangayId
  LEFT JOIN BarangayAreas BA ON BA.BarangayAreaId = FA.BarangayAreaId
  WHERE
  (
      ISNULL(@status, '') = '' OR
      FA.[Status] = @status
  ) AND
  (
      ISNULL(@searchText, '') = '' OR
      FA.Name LIKE @searchText + '%' OR 
      FA.Address LIKE @searchText + '%' OR 
      F.Farmer LIKE '%' + @searchText + '%'
  ) AND
  (
      ISNULL(@barangayId, 0) = 0 OR
      FA.BarangayId = @barangayId
  )
  ORDER BY FA.Name
  OFFSET (@pageNUmber-1)*@pageSize ROWS
  FETCH NEXT @pageSize ROWS ONLY
END