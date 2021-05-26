CREATE PROCEDURE [dbo].[sp_deleteFarmerClaim]
  @ClaimId INT,
  @Validation   INT OUTPUT
AS
BEGIN
  DECLARE @ExistingFarmCropId INT = (SELECT [FarmCropId] FROM Claims WHERE ClaimId = @ClaimId)

  IF @ExistingFarmCropId IS NULL
    BEGIN 
      SET @Validation = 7001;
    END
  ELSE IF (SELECT [Status] FROM Claims WHERE ClaimId = @claimId) <> 'Pending'
    BEGIN
      SET @Validation = 7002;
    END
  ELSE
    BEGIN
      DELETE FROM ClaimCauses WHERE ClaimId = @ClaimId;
      DELETE FROM Claims WHERE ClaimId = @ClaimId;
      UPDATE FarmCrops SET [Status]='Planted' WHERE FarmCropId = @ExistingFarmCropId
    END
END