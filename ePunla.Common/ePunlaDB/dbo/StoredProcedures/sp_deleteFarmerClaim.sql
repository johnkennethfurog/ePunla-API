CREATE PROCEDURE [dbo].[sp_deleteFarmerClaim]
  @ClaimId INT,
  @Validation   INT OUTPUT
AS
BEGIN
  IF NOT EXISTS (SELECT TOP 1 * FROM Claims WHERE ClaimId = @claimId)
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
    END
END