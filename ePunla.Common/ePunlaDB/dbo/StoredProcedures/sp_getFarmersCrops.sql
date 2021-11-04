CREATE PROCEDURE [dbo].[sp_getFarmersCrops]
  @FarmerId INT,
  @Status NVARCHAR(200),
  @CropId INT,
  @PlantedFrom DATETIME,
  @PlantedTo DATETIME
AS
BEGIN
  SELECT  [FarmCropId] = FC.FarmCropId,
          [Crop] = C.Name,
          [CropId] = C.CropId,
          [CategoryId] = CA.CategoryId,
          [Category] = CA.Name,
          [FarmId] = F.FarmId,
          [Farm] = F.Name,
          [EstimatedHarvestDate] = FC.EstimatedHarvestDate,
          [PlantedDate] = FC.PlantedDate,
          [AreaSize] = FC.AreaSize,
          [Status] = FC.[Status],
          [ActionDate] = IIF(FC.[Status] = 'Damaged', FC.ClaimFilingDate,FC.HarvestDate)
  FROM FarmCrops FC
  LEFT JOIN Farms F ON F.FarmId = FC.FarmId
  LEFT JOIN Crops C on C.CropId = FC.CropId
  LEFT JOIN Categories CA on CA.CategoryId = C.CategoryId
  WHERE FarmerId = @FarmerId
        AND (@CropId IS NULL OR C.CropId = @CropId)
        AND (@Status IS NULL OR FC.[Status] = @Status)
        AND (@PlantedFrom IS NULL OR @PlantedTo IS NULL OR FC.PlantedDate BETWEEN @PlantedFrom AND @PlantedTo)
END