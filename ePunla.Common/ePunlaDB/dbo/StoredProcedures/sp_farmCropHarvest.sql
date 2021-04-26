CREATE PROCEDURE [dbo].[sp_farmCropHarvest]
  @FarmCropId INT,
  @HarvestDate DATETIME,
  @Validation   INT OUTPUT
AS
  BEGIN

    IF NOT EXISTS (SELECT TOP 1 *  FROM FarmCrops WHERE FarmCropId = @FarmCropId)
      BEGIN
          SET @Validation = 4002
      END 
    ELSE IF((SELECT [Status] FROM FarmCrops WHERE FarmCropId = @FarmCropId) <> 'Planted')
      BEGIN
          SET @Validation = 4001
      END
    ELSE
      BEGIN
          UPDATE FarmCrops 
          SET 
            [Status] = 'Harvested',
            [HarvestDate] = @HarvestDate
          WHERE FarmCropId = @FarmCropId
      END
  END
