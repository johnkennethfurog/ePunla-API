CREATE PROCEDURE [dbo].[sp_getClaimDetail]
  @claimId INT,
  @Validation INT OUTPUT
AS
BEGIN

  -- CHECK IF UPDATING AND CLAIM EXIST
  IF @ClaimId IS NOT NULL AND NOT EXISTS (SELECT TOP 1 * FROM Claims WHERE ClaimId = @claimId)
    BEGIN 
      SET @Validation = 7001;
    END
  ELSE 
    BEGIN
      SELECT
          -- CLAIM DETAIL
          C.ClaimId,
          C.FilingDate,
          C.DamagedArea,
          C.[Status],
          C.[Description],
          C.PhotoUrl,
          C.Remarks,
          C.ValidationDate,

          -- CROP DETAIL
          [Crop] = CR.Name,
          [DatePlanted] = FC.PlantedDate,
          [CropAreaSize] = FC.AreaSize,

          -- FARM DETAIL
          [Farm] = F.Name,
          F.Address,
          [Barangay] = B.Name,
          [Area] = BA.Name,
          [FarmSize] = F.AreaSize,

          -- FARMER DETAIL
          FA.FirstName,
          FA.LastName,
          FA.MiddleName,
          FA.Avatar,
          FA.MobileNumber,
          [FarmerBarangay] = FAB.Name,
          [FarmerArea] = FABA.Name,
          [FarmerAddress] = FA.StreetAddress
      FROM Claims C
      LEFT JOIN Farms F ON F.FarmId = C.FarmId
      LEFT JOIN FarmCrops FC ON FC.FarmCropId = C.FarmCropId
      LEFT JOIN Crops CR ON CR.CropId = FC.CropId
      LEFT JOIN Farmers FA ON FA.FarmerId = F.FarmerId
      LEFT JOIN Barangays B ON B.BarangayId = F.BarangayId
      LEFT JOIN BarangayAreas BA ON BA.BarangayAreaId = F.BarangayAreaId
      LEFT JOIN Barangays FAB ON FAB.BarangayId = FA.BarangayId
      LEFT JOIN BarangayAreas FABA ON FABA.BarangayAreaId = FA.BarangayAreaId
      WHERE C.ClaimId = @claimId
    END
END