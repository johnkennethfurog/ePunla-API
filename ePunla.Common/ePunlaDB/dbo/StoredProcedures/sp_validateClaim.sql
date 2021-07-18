CREATE PROCEDURE [dbo].[sp_validateClaim]
  @claimId INT,
  @isApproved BIT,
  @remarks NVARCHAR(500),
  @Validation INT OUTPUT
AS
BEGIN

  DECLARE @ClaimedLiteral NVARCHAR(30) = 'Claimed';
  DECLARE @DeniedLiteral NVARCHAR(30) = 'Denied';
  DECLARE @PendingLiteral NVARCHAR(30) = 'Pending';

  DECLARE @claimStatus NVARCHAR(30);
  SELECT @claimStatus = [Status] FROM Claims WHERE ClaimId = @claimId

-- CHECK IF UPDATING AND CLAIM EXIST
  IF NOT EXISTS (SELECT TOP 1 * FROM Claims WHERE ClaimId = @claimId)
    BEGIN 
      SET @Validation = 7001;
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

  -- CHECK IF CLAIM STATUS IS STILL PENDING
  ELSE IF @claimStatus = @PendingLiteral AND @isApproved = 1
    BEGIN 
      SET @Validation = 7007;
    END
  ELSE
    BEGIN
      UPDATE Claims SET 
        [Remarks] = @remarks,
        [ValidationDate] = GETDATE(),
        [Status] =  CASE @isApproved 
                      WHEN 1 THEN @ClaimedLiteral
                      WHEN 0 THEN @DeniedLiteral
                    END
      WHERE ClaimId = @claimId
    END
END
