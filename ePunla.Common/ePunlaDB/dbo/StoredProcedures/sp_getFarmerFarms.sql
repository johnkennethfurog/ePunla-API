CREATE PROCEDURE [dbo].[sp_getFarmerFarms]
  @FarmerId int
AS
BEGIN
  SELECT  [FarmId] = F.FarmId,
          [Name] = F.Name,
          [AreaSize] = F.AreaSize,
          [Status] = F.[Status],
          [StreetAddress] = F.Address,
          [Barangay] = B.Name,
          [BarangayId] = B.BarangayId,
          [BarangayArea] = BA.Name,
          [BarangayAreaId] = BA.BarangayAreaId,
          [Lng] = F.Lng,
          [Lat] = F.Lat
  FROM Farms F
  LEFT JOIN Barangays B ON B.BarangayId = F.BarangayId
  LEFT JOIN BarangayAreas BA ON BA.BarangayAreaId = F.BarangayAreaId
  WHERE FarmerId = @FarmerId
END
