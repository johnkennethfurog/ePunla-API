CREATE PROCEDURE [dbo].[sp_farmCropDelete]
  @FarmCropId INT,
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
          DELETE FROM FarmCrops WHERE FarmCropId = @FarmCropId
      END
  END
