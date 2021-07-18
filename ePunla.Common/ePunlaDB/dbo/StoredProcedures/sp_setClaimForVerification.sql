CREATE PROCEDURE [dbo].[sp_setClaimForVerification]
  @claimId INT,
  @Validation INT OUTPUT
AS
BEGIN

  DECLARE @ClaimedLiteral NVARCHAR(30) = 'Claimed';
  DECLARE @DeniedLiteral NVARCHAR(30) = 'Denied';
 DECLARE @ForVerificationLiteral NVARCHAR(30) = 'ForVerification';

  DECLARE @claimStatus NVARCHAR(30);
  SELECT @claimStatus = [Status] FROM Claims WHERE ClaimId = @claimId

  -- CHECK IF UPDATING AND CLAIM EXIST
  IF NOT EXISTS (SELECT TOP 1 * FROM Claims WHERE ClaimId = @claimId)
    BEGIN 
      SET @Validation = 7001;
    END

  -- CHECK IF CLAIM STATUS IS ALREADY FOR VERIFICATION
  ELSE IF @claimStatus = @ForVerificationLiteral
    BEGIN
      SET @Validation = 7004;
    END

  -- CHECK IF CLAIM STATUS IS ALREADY CLAIMED
  ELSE IF @claimStatus = @ClaimedLiteral
    BEGIN
      SET @Validation = 7005;
    END

  -- CHECK IF CLAIM STATUS IS ALREADY DENIED
   ELSE IF @claimStatus = @DeniedLiteral
    BEGIN
      SET @Validation = 7006;
    END

  ELSE
    BEGIN
      UPDATE Claims SET 
        [ValidationDate] = GETDATE(),
        [Status] = @ForVerificationLiteral
      WHERE ClaimId = @claimId
    END
END
