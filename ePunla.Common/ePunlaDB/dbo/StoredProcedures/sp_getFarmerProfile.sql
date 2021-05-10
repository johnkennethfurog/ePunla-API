CREATE PROCEDURE [dbo].[sp_getFarmerProfile]
  @farnerId int
AS
BEGIN
   IF @FarmId IS NOT NULL AND  NOT EXISTS ( SELECT TOP 1 * FROM Farms WHERE FarmId = @farmId AND FarmerId = @farmerId)
    BEGIN
      SET @Validation = 5001
    END
END
