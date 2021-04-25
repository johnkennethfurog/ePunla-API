CREATE PROCEDURE [dbo].[sp_getFarmersCrops]
  @FarmerId INT
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
          [HarvestDate] = FC.HarvestDate
  FROM FarmCrops FC
  LEFT JOIN Farms F ON F.FarmId = FC.FarmId
  LEFT JOIN Crops C on C.CropId = FC.CropId
  LEFT JOIN Categories CA on CA.CategoryId = C.CategoryId
  WHERE FarmerId = @FarmerId
END