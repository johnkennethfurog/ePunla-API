CREATE PROCEDURE [dbo].[sp_farmCropSave]
  @farmCropId INT,
  @farmId INT,
  @cropId INT,
  @datePlanted DATETIME,
  @areaSize DECIMAL,
  @farmerId INT,
  @Validation INT OUTPUT
AS
BEGIN

  DECLARE @categoryId INT = (SELECT CategoryId FROM Crops WHERE CropId = @cropId)
  DECLARE @duration INT = (SELECT Duration FROM Crops WHERE CropId = @cropId) 
  DECLARE @esitmatedHarvestDate DATETIME = DATEADD(day,@duration,@datePlanted)

  IF @farmCropId IS NOT NULL AND NOT EXISTS ( SELECT TOP 1 * FROM FarmCrops WHERE FarmCropId = @farmCropId)
    BEGIN
      SET @Validation = 4002
    END
  ELSE IF @farmCropId IS NOT NULL AND (SELECT [Status] FROM FarmCrops WHERE FarmCropId = @farmCropId) <> 'Planted'
    BEGIN
        SET @Validation = 4001
    END
  ELSE IF EXISTS (SELECT TOP 1 * FROM FarmCrops WHERE FarmId = @farmId AND CropId = @cropId AND (@farmCropId IS NULL OR [FarmCropId] <> @farmCropId) AND [Status]='Planted')
    BEGIN
        SET @Validation = 4003
    END
  ELSE IF  NOT EXISTS ( SELECT TOP 1 * FROM Farms WHERE FarmId = @farmId AND FarmerId = @farmerId)
    BEGIN
      SET @Validation = 5001
    END
  ELSE IF  @categoryId IS NULL OR @duration IS NULL
    BEGIN
      SET @Validation = 6001
    END
  ELSE IF @farmCropId IS NULL
    BEGIN
      INSERT INTO FarmCrops
        ([CropId],[FarmId],[CategoryId],[EstimatedHarvestDate],[PlantedDate],[AreaSize],[Status])
      VALUES
        (@cropId, @farmId, @CategoryId,@esitmatedHarvestDate, @datePlanted, @areaSize, 'Planted')
    END
  ELSE
    BEGIN
      UPDATE FarmCrops
      SET
        [CropId] = @cropId,
        [FarmId] = @farmId,
        [CategoryId] = @CategoryId,
        [EstimatedHarvestDate] = @esitmatedHarvestDate,
        [PlantedDate] = @datePlanted,
        [AreaSize] = @areaSize
      WHERE
        FarmCropId = @farmCropId
    END

  SELECT ISNULL(ISNULL(SCOPE_IDENTITY(),@farmCropId),0);
END
